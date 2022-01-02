import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { RolesUsuario } from 'src/app/Core/models/Enums/enums.model';
import { Rol } from 'src/app/Core/models/roles/rol.model';
import { ToastModel } from 'src/app/Core/models/toasts/toast.model';
import { UpdateUsuario } from 'src/app/Core/models/usuarios/update-usuario.model';
import { Usuario } from 'src/app/Core/models/usuarios/usuatio.model';
import { ToastService } from 'src/app/Shared/services/toast.service';
import { MyValidations } from 'src/app/Shared/validations/cedula.validation';
import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'app-editar-usuario',
  templateUrl: './editar-usuario.component.html',
  styleUrls: ['./editar-usuario.component.scss']
})
export class EditarUsuarioComponent implements OnInit {
  form: FormGroup = new FormGroup({});
  roles!: Rol[];
  private usuario!: Usuario;
  constructor(private usuarioService: UsuarioService,
    private fb: FormBuilder, 
    private toastService: ToastService,
    private route: ActivatedRoute,private router: Router) {
      this.getRoles();
      this.createForm();
      const id = +this.route.snapshot.params['id'];
      this.usuarioService.getUsuario(id).subscribe(res => {
        this.usuario = {...res.data};
        this.form.patchValue({
          ...res.data,
          idRol: res.data.rol.id
        });
        this.form.markAllAsTouched();
      });
     
  }

  ngOnInit(): void {
    
  }

  getRoles(){
    this.usuarioService.getRoles()
    .subscribe(res => {
      this.roles = res.data;
    });
  }

  createForm(){
    this.form = this.fb.group({
      nombres: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      apellidos: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      cedula: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11), 
                    MyValidations.isCedulaInvalid]],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(100)]],
      telefono: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      direccion: this.fb.group({
        provincia: ['', [Validators.required]],
        calle: ['', [Validators.required]],
        numero: ['', [Validators.required]],
      }),
      idRol: ['', [Validators.required]]
    });
  }

  get composForm() {
    return {
      nombres: this.form.get('nombres')!,
      apellidos: this.form.get('apellidos')!,
      cedula: this.form.get('cedula')!,
      email: this.form.get('email')!,
      telefono: this.form.get('telefono')!,
      provincia: this.form.get('direccion.provincia')!,
      calle: this.form.get('direccion.calle')!,
      numero: this.form.get('direccion.numero')!,
      idRol: this.form.get('idRol')!,
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

  onSubmit(){
    const usuario: UpdateUsuario = {...this.form.value};
    this.usuarioService.updateUsuario(this.usuario.id,usuario).subscribe((res) => {
      this.showToast({
        title: 'Usuario actualizado correctamente',
        body: 'El usuario se ha actualizado correctamente',
        tipo: 'success'
     });
     this.reset();
    }, error => {
      this.showToast({
        title: 'Error',
        body: 'Ha ocurrido un error al actualizar el usuario',
        tipo: 'error'
     });
    });
  }

  reset(){
    this.router.navigate(['/admin/usuarios'])
  }


}
