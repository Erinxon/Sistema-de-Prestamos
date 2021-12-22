import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgregarUsuarioComponent } from './pages/agregar-usuario/agregar-usuario.component';
import { EditarUsuarioComponent } from './pages/editar-usuario/editar-usuario.component';
import { UsuariosComponent } from './pages/usuarios/usuarios.component';

const routes: Routes = [
  {
    path: '',
    component: UsuariosComponent,
  },
  {
    path: 'agregar',
    component: AgregarUsuarioComponent,
  },
  {
    path: 'editar/:id',
    component: EditarUsuarioComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuariosRoutingModule { }
