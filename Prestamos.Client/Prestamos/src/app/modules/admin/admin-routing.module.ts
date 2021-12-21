import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/Core/guards/auth.guard';
import { AdminComponent } from './admin.component';

const routes: Routes = [
  { 
    path: '', redirectTo: 'home', pathMatch: 'full'
  },
  {
    path: '',
    component: AdminComponent,
    children: [
      {
        path: 'home',
        loadChildren: () =>
          import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
      },
      {
        path: 'pagar-prestamos',
        loadChildren: () =>
          import('./pagar-prestamos/pagar-prestamos.module').then((m) => m.PagarPrestamosModule),
      },
      {
        path: 'clientes',
        loadChildren: () =>
          import('./clientes/clientes.module').then((m) => m.ClientesModule),
      },
      {
        path: 'crear-prestamos',
        loadChildren: () =>
          import('./crear-prestamos/crear-prestamos.module').then((m) => m.CrearPrestamosModule),
      },
      {
        path: 'prestamos',
        loadChildren: () =>
          import('./prestamos/prestamos.module').then((m) => m.PrestamosModule),
      },
      {
        path: 'usuarios',
        loadChildren: () =>
          import('./usuarios/usuarios.module').then((m) => m.UsuariosModule),
      },
    ],
    canActivate: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
