import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './Core/guards/auth.guard';
import { Error403Component } from './Shared/components/errors/error403/error403.component';

const routes: Routes = [
  { 
    path: '', redirectTo: 'admin', pathMatch: 'full', 
  },
  {
    path: 'admin',
    loadChildren: () => import('./modules/admin/admin.module').then((m) => m.AdminModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.module').then((m) => m.AuthModule)
  },
  {
    path: '403',
    component: Error403Component
  },
  {
    path: '**',
    redirectTo: 'admin'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
