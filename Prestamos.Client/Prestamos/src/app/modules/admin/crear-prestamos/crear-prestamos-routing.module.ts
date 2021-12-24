import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConcederPrestamoComponent } from './pages/conceder-prestamo/conceder-prestamo.component';

const routes: Routes = [
 {
   path: '',
   component: ConcederPrestamoComponent
 }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CrearPrestamosRoutingModule { }
