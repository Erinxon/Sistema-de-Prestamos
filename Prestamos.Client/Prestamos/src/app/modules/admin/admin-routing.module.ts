import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/Core/guards/auth.guard';
import { AuthorizationGuard } from 'src/app/Core/guards/authorization.guard';
import { RolesUsuario } from 'src/app/Core/models/Enums/enums.model';
import { Error403Component } from 'src/app/Shared/components/errors/error403/error403.component';
import { AdminComponent } from './admin.component';

const routes: Routes = [
  { 
    path: '', redirectTo: 'home', pathMatch: 'full',
  },
  {
    path: '',
    component: AdminComponent,
    children: [
      {
        path: 'home',
        loadChildren: () =>
          import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
          canActivate: [AuthorizationGuard],
          data: { roles: [RolesUsuario.Cobrador,RolesUsuario.Prestador] }
      },
      {
        path: 'pagar-prestamos',
        loadChildren: () =>
          import('./pagar-prestamos/pagar-prestamos.module').then((m) => m.PagarPrestamosModule),
          canActivate: [AuthorizationGuard],
          data: { roles: [RolesUsuario.Cobrador,RolesUsuario.Prestador] }
      },
      {
        path: 'clientes',
        loadChildren: () =>
          import('./clientes/clientes.module').then((m) => m.ClientesModule),
          canActivate: [AuthorizationGuard],
          data: { roles: [RolesUsuario.Prestador] }
      },
      {
        path: 'crear-prestamos',
        loadChildren: () =>
          import('./crear-prestamos/crear-prestamos.module').then((m) => m.CrearPrestamosModule),
          canActivate: [AuthorizationGuard],
          data: { roles: [RolesUsuario.Prestador] }
      },
      {
        path: 'prestamos',
        loadChildren: () =>
          import('./prestamos/prestamos.module').then((m) => m.PrestamosModule),
          canActivate: [AuthorizationGuard],
          data: { roles: [RolesUsuario.Prestador] }
      },
      {
        path: 'usuarios',
        loadChildren: () =>
          import('./usuarios/usuarios.module').then((m) => m.UsuariosModule),
          canActivate: [AuthGuard,AuthorizationGuard],
          data: { roles: [RolesUsuario.Prestador] }
      },
      {
        path: 'configuracion',
        loadChildren: () =>
          import('./configuracion/configuracion.module').then((m) => m.ConfiguracionModule),
          canActivate: [AuthGuard,AuthorizationGuard],
          data: { roles: [RolesUsuario.Prestador] }
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
