import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Empresa } from 'src/app/Core/models/empresa/empresa.model';
import { UpdateEmpresa } from 'src/app/Core/models/empresa/update-empresa.model';
import { ToastModel } from 'src/app/Core/models/toasts/toast.model';
import { ToastService } from 'src/app/Shared/services/toast.service';
import { ConfiguracionService } from './services/configuracion.service';

@Component({
  selector: 'app-configuracion',
  templateUrl: './configuracion.component.html',
  styleUrls: ['./configuracion.component.scss']
})
export class ConfiguracionComponent implements OnInit {
   form: FormGroup = new FormGroup({});
  empresa!: Empresa;
  constructor(private configuracionService: ConfiguracionService,
    private fb: FormBuilder, private toast: ToastService) {
      this.makeForm();
      this.patchValueForm();
  }

  ngOnInit(): void {

  }

  makeForm(){
    this.form = this.fb.group({
       nombre: ['', [Validators.required, Validators.maxLength(100)]],
       rnc: ['', [Validators.required, Validators.minLength(9), Validators.maxLength(9)]],
       telefono: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
       email: ['', [Validators.required,Validators.email,Validators.maxLength(100)]],
       direccion: this.fb.group({
          provincia: ['', Validators.required],
          calle: ['', Validators.required],
          numero: ['', Validators.required],
       })
    });
  }

  patchValueForm(){
    this.configuracionService.getDatosEmpresa().subscribe(res => {
      this.empresa = res.data;
      this.form.patchValue({...this.empresa});
      this.form.markAllAsTouched();
    })
  }

  onSubmit(){
    const empresa: UpdateEmpresa = {
      ...this.form.value
    };
    this.configuracionService.updateDatosEmpresa(this.empresa.id, empresa).subscribe(res => {
      this.showToast(
        {
          title: 'Datos actualizados',
          body: 'Los datos de la empresa han sido actualizados',
          tipo: 'success'
        }
      );
    }, error => {
      this.showToast(
        {
          title: 'Error',
          body: 'No se pudo actualizar los datos de la empresa',
          tipo: 'error'
        }
      )
    })
  }

  isInvalid(campo: string){
    return this.form.get(campo)!.invalid && (this.form.get(campo)!.dirty || this.form.get(campo)!.touched);
  }

  get composForm() {
    return {
      nombre: this.form.get('nombre')!,
      rnc: this.form.get('rnc')!,
      telefono: this.form.get('telefono')!,
      email: this.form.get('email')!,
      provincia: this.form.get('direccion.provincia')!,
      calle: this.form.get('direccion.calle')!,
      numero: this.form.get('direccion.numero')!,
    }
  }

  showToast(toast: ToastModel){
    this.toast.show(toast)
    setTimeout(() => {
      this.toast.hide();
    }, 2300)
  }



}
