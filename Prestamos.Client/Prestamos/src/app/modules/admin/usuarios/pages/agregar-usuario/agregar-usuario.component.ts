import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { RolesUsuario } from 'src/app/Core/models/Enums/enums.model';
import { Rol } from 'src/app/Core/models/roles/rol.model';
import { ToastModel } from 'src/app/Core/models/toasts/toast.model';
import { ToastService } from 'src/app/Shared/services/toast.service';
import { MyValidations } from 'src/app/Shared/validations/cedula.validation';
import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'app-agregar-usuario',
  templateUrl: './agregar-usuario.component.html',
  styleUrls: ['./agregar-usuario.component.scss']
})
export class AgregarUsuarioComponent implements OnInit {
  form: FormGroup = new FormGroup({});
  roles: Observable<Rol[]>;

  constructor(private usuarioService: UsuarioService,
    private fb: FormBuilder, 
    private toastService: ToastService) {
      this.roles = this.usuarioService.getRoles()
      .pipe(
        map(roles => roles.data)
      );
      this.createForm();
  }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  createForm(){
    this.form = this.fb.group({
      nombres: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      apellidos: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      cedula: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11), 
                    MyValidations.isCedulaInvalid]],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(100)]],
      telefono: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      password: ['', [Validators.required]],
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
      password: this.form.get('password')!,
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
    const usuario = {...this.form.value};
    this.usuarioService.addUsuario(usuario).subscribe((res) => {
      this.showToast({
        title: 'Usuario Agregado',
        body: 'El usuario se ha agregado correctamente',
        tipo: 'success'
     });
     this.form.reset();
    }, error => {
      this.showToast({
        title: 'Error',
        body: 'Ha ocurrido un error al agregar el usuario',
        tipo: 'error'
     });
     this.form.reset();
    });
  }

  reset(){
    this.form.reset();
  }

}
