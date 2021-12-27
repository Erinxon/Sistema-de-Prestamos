import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetallePrestamoComponent } from './pages/detalle-prestamo/detalle-prestamo.component';
import { PrestamosComponent } from './pages/prestamos/prestamos.component';

const routes: Routes = [
  {
    path: '',
    component: PrestamosComponent
  },
  {
    path: 'detalle/:id',
    component: DetallePrestamoComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PrestamosRoutingModule { }
