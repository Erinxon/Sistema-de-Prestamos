import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PagarPrestamoComponent } from './pages/pagar-prestamo/pagar-prestamo.component';

const routes: Routes = [
  {
    path: '',
    component: PagarPrestamoComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagarPrestamosRoutingModule { }
