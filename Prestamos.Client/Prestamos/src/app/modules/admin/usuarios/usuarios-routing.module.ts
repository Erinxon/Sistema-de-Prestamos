import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizationGuard } from 'src/app/Core/guards/authorization.guard';
import { RolesUsuario } from 'src/app/Core/models/Enums/enums.model';
import { AgregarUsuarioComponent } from './pages/agregar-usuario/agregar-usuario.component';
import { DetalleUsuarioComponent } from './pages/detalle-usuario/detalle-usuario.component';
import { EditarUsuarioComponent } from './pages/editar-usuario/editar-usuario.component';
import { UsuariosComponent } from './pages/usuarios/usuarios.component';

const routes: Routes = [
  {
    path: '',
    component: UsuariosComponent,
    canActivate: [AuthorizationGuard],
    data: { roles: [RolesUsuario.Admin] }
  },
  {
    path: 'agregar',
    component: AgregarUsuarioComponent,
  },
  {
    path: 'editar/:id',
    component: EditarUsuarioComponent,
  },
  {
    path: 'detalle/:id',
    component: DetalleUsuarioComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuariosRoutingModule { }
