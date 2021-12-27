import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuariosRoutingModule } from './usuarios-routing.module';
import { UsuariosComponent } from './pages/usuarios/usuarios.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/Shared/shared.module';
import { IConfig, NgxMaskModule } from 'ngx-mask';
import { EditarUsuarioComponent } from './pages/editar-usuario/editar-usuario.component';
import { AgregarUsuarioComponent } from './pages/agregar-usuario/agregar-usuario.component';
import { DetalleUsuarioComponent } from './pages/detalle-usuario/detalle-usuario.component';


const maskConfig: Partial<IConfig> = {
  validation: false,
};

@NgModule({
  declarations: [
    UsuariosComponent,
    EditarUsuarioComponent,
    AgregarUsuarioComponent,
    DetalleUsuarioComponent
  ],
  imports: [
    CommonModule,
    UsuariosRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    NgxMaskModule.forRoot(maskConfig),
  ]
})
export class UsuariosModule { }
