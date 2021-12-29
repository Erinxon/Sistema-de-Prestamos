import { Component, OnInit } from '@angular/core';
import { Pagination } from 'src/app/Core/models/apiResponse/pagination/pagination.model';
import { RolesUsuario } from 'src/app/Core/models/Enums/enums.model';
import { ToastModel } from 'src/app/Core/models/toasts/toast.model';
import { Usuario } from 'src/app/Core/models/usuarios/usuatio.model';
import { ToastService } from 'src/app/Shared/services/toast.service';
import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.scss']
})
export class UsuariosComponent implements OnInit {
  usuarios!: Usuario[];
  columnas: string[] = ['Nombres', 'Apellidos', 'Cedula', 'Telefono', 'Rol', 'Fecha Creado', 'Detalle', 'Editar', 'Eliminar'];

  showDialogo: boolean = false;
  idUsuarioAEliminar!: number;

  searchText: string = '';

  pagination: Pagination;

  listaPageSizes: number[] = [5, 10, 15, 20];

  totalPaginas: number = 1;
  
  rolUsuarioNoEliminar = RolesUsuario.Prestador;

  constructor(private usuarioService: UsuarioService, private toastService: ToastService) {
    this.pagination = {
      pageNumber: 1,
      pageSize: 5,
    };
    this.getUsuarios();
  }

  getUsuarios(): void {
    this.usuarioService.getUsuarios(this.pagination).subscribe(
      (response: any) => {
        this.totalPaginas = Math.ceil(response.pagination.totalRegistros! / this.pagination.pageSize);
        this.usuarios = response.data;
        this.pagination = response.pagination;
      }
    )
  }

  ngOnInit(): void {
  }

  pageChange(pagination: Pagination){
    this.pagination = pagination;
    this.getUsuarios();
  }

  showOrHideDialog(){
    this.showDialogo = !this.showDialogo;
  }

  eliminarUsuario(id: number){
    this.idUsuarioAEliminar = id;
    this.showOrHideDialog();
  }

  onConfirmacion(event: boolean){
    if(event && this.idUsuarioAEliminar){
      this.usuarioService.deleteUsuario(this.idUsuarioAEliminar).subscribe(res => {
        this.showToast({
          title: 'Usuario Eliminado',
          body: 'El usuario se ha eliminado correctamente',
          tipo: 'success'
        })
        this.getUsuarios();
      }, error => {
        this.showToast({
          title: 'Error',
          body: 'No se puede eliminar el usuario',
          tipo: 'error'
        })
      })
    }
    this.showOrHideDialog();
  }

  showToast(toast: ToastModel){
    this.toastService.show(toast)
    setTimeout(() => {
      this.toastService.hide();
    }, 2000)
  }

  searchUsuario(text: string){
    if(text.length > 0){
      this.usuarioService.search(text, this.pagination).subscribe((res) => {
        this.totalPaginas = Math.ceil(res.pagination.totalRegistros! / this.pagination.pageSize);
        this.usuarios = res.data;
        this.pagination = res.pagination;
      })
    }else{
      this.getUsuarios();
    }
  }

}
