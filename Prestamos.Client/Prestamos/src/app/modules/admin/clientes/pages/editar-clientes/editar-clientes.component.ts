import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Cliente } from 'src/app/Core/models/clientes/cliente.model';
import { UpdateCliente } from 'src/app/Core/models/clientes/update-cliente.model';
import { EstatusCrediticio } from 'src/app/Core/models/estatusCrediticios/estatusCrediticio.model';
import { ToastModel } from 'src/app/Core/models/toasts/toast.model';
import { ToastService } from 'src/app/Shared/services/toast.service';
import { MyValidations } from 'src/app/Shared/validations/cedula.validation';
import { ClienteService } from '../../services/cliente.service';

@Component({
  selector: 'app-editar-clientes',
  templateUrl: './editar-clientes.component.html',
  styleUrls: ['./editar-clientes.component.scss']
})
export class EditarClientesComponent implements OnInit {
  form: FormGroup = new FormGroup({});
  cliente!: Cliente;
  estatusCrediticios$: Observable<EstatusCrediticio[]>;

  constructor(private clienteService: ClienteService,
    private fb: FormBuilder, 
    private toastService: ToastService,
    private route: ActivatedRoute,
    private router: Router) {
      this.estatusCrediticios$ = this.clienteService.getEstatusCrediticios()
      .pipe(
        map((res) => res.data)
      );
      this.createForm();
  }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.clienteService.getClienteById(id).subscribe((res) => {
      this.cliente = {... res.data};
      this.form.patchValue({
        ...res.data,
        idEstatusCrediticio: res.data.estatusCrediticio.id
      });
    })
  }

  createForm(){
    this.form = this.fb.group({
      nombres: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      apellidos: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      cedula: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11), 
                    MyValidations.isCedulaInvalid]],
      telefono: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      direccion: this.fb.group({
        provincia: ['', [Validators.required]],
        calle: ['', [Validators.required]],
        numero: ['', [Validators.required]],
      })
    });
  }

  onSubmit(){
    const cliente: UpdateCliente = {
      ...this.form.value,
      direccion: {
        id: this.cliente.direccion.id,
        ...this.form.value.direccion
      }
    };
    this.clienteService.updateCliente(this.cliente.id, cliente).subscribe((res) => {
      if(res.succeeded){
       this.showToast({
          title: 'Cliente Actualizado',
          body: 'El cliente se actualizo correctamente',
          tipo: 'success'
       });
       this.form.reset();
       this.router.navigate(['/admin/clientes']);
      }
    }, error => {
      this.showToast({
        title: 'Error',
        body: 'Ocurrio un error al actualizar el cliente',
        tipo: 'error'
     });
     
    });
  }
  
  get composForm() {
    return {
      nombres: this.form.get('nombres')!,
      apellidos: this.form.get('apellidos')!,
      cedula: this.form.get('cedula')!,
      telefono: this.form.get('telefono')!,
      idEstatus: this.form.get('idEstatus')!,
      provincia: this.form.get('direccion.provincia')!,
      calle: this.form.get('direccion.calle')!,
      numero: this.form.get('direccion.numero')!
    }
  }

  isInvalid(campo: string){
    return this.form.get(campo)!.invalid && (this.form.get(campo)!.dirty || this.form.get(campo)!.touched);
  }

  showToast(toast: ToastModel){
    this.toastService.show(toast)
    setTimeout(() => {
      this.toastService.hide();
    }, 2000)
  }


}