import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConcederPrestamoComponent } from './pages/conceder-prestamo/conceder-prestamo.component';
import { FacturaComponent } from './pages/factura/factura.component';

const routes: Routes = [
 {
   path: '',
   component: ConcederPrestamoComponent
 },
 {
  path: 'factura/:id',
  component: FacturaComponent
},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CrearPrestamosRoutingModule { }
