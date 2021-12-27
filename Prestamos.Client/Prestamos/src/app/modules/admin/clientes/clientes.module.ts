import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientesRoutingModule } from './clientes-routing.module';
import { ClientesComponent } from './pages/clientes/clientes.component';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from 'src/app/Shared/shared.module';
import { AgregarClientesComponent } from './pages/agregar-clientes/agregar-clientes.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule, IConfig } from 'ngx-mask';
import { EditarClientesComponent } from './pages/editar-clientes/editar-clientes.component';
import { DetalleClienteComponent } from './pages/detalle-cliente/detalle-cliente.component'

const maskConfig: Partial<IConfig> = {
  validation: false,
};

@NgModule({
  declarations: [
    ClientesComponent,
    AgregarClientesComponent,
    EditarClientesComponent,
    DetalleClienteComponent
  ],
  imports: [
    CommonModule,
    ClientesRoutingModule,
    HttpClientModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot(maskConfig),
  ]
})
export class ClientesModule { }
