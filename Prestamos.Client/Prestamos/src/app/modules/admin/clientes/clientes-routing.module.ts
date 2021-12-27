import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgregarClientesComponent } from './pages/agregar-clientes/agregar-clientes.component';
import { ClientesComponent } from './pages/clientes/clientes.component';
import { DetalleClienteComponent } from './pages/detalle-cliente/detalle-cliente.component';
import { EditarClientesComponent } from './pages/editar-clientes/editar-clientes.component';

const routes: Routes = [
  {
    path: '',
    component: ClientesComponent,
  },
  {
    path: 'agregar',
    component: AgregarClientesComponent,
  },
  {
    path: 'editar/:id',
    component: EditarClientesComponent,
  },
  {
    path: 'detalle/:id',
    component: DetalleClienteComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientesRoutingModule { }
