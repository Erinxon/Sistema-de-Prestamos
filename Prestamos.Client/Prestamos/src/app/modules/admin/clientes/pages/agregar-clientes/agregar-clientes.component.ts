import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AddCliente } from 'src/app/Core/models/clientes/addCliente.model';
import { ToastModel } from 'src/app/Core/models/toasts/toast.model';
import { ToastService } from 'src/app/Shared/services/toast.service';
import { MyValidations } from 'src/app/Shared/validations/cedula.validation';
import { ClienteService } from '../../services/cliente.service';

@Component({
  selector: 'app-agregar-clientes',
  templateUrl: './agregar-clientes.component.html',
  styleUrls: ['./agregar-clientes.component.scss']
})
export class AgregarClientesComponent implements OnInit {
  form: FormGroup = new FormGroup({});

  constructor(private clienteService: ClienteService,
    private fb: FormBuilder, 
    private toastService: ToastService) {
      this.createForm();
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

  ngOnInit(): void {
  }

  onSubmit(){
    const cliente: AddCliente = {... this.form.value};
    this.clienteService.addCliente(cliente).subscribe((res) => {
      if(res.succeeded){
       this.showToast({
          title: 'Cliente Agregado',
          body: 'El cliente se ha agregado correctamente',
          tipo: 'success'
       });
       this.form.reset();
      }
    }, error => {
      this.showToast({
        title: 'Error',
        body: 'Ha ocurrido un error al agregar el cliente',
        tipo: 'error'
     });
     this.form.reset();
    });
  }
  
  get composForm() {
    return {
      nombres: this.form.get('nombres')!,
      apellidos: this.form.get('apellidos')!,
      cedula: this.form.get('cedula')!,
      telefono: this.form.get('telefono')!,
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
