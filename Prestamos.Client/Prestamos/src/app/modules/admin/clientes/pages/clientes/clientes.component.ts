import { Component, OnInit } from '@angular/core';
import { Pagination } from 'src/app/Core/models/apiResponse/pagination/pagination.model';
import { Cliente } from 'src/app/Core/models/clientes/cliente.model';
import { ToastModel } from 'src/app/Core/models/toasts/toast.model';
import { ToastService } from 'src/app/Shared/services/toast.service';
import { ClienteService } from '../../services/cliente.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss']
})
export class ClientesComponent implements OnInit {
  clientes!: Cliente[];
  columnas: string[] = ['Nombres', 'Apellidos', 'Cedula', 'Telefono', 'Estatus Crediticio', 'Fecha Creado', 'Detalle', 'Editar', 'Eliminar'];

  showDialogo: boolean = false;
  idClenteAEliminar!: number;

  pagination: Pagination;

  listaPageSizes: number[] = [5, 10, 15, 20];

  totalPaginas: number = 1;
  
  constructor(private clienteService: ClienteService,
    private toastService: ToastService) { 
      this.pagination = {
        pageNumber: 1,
        pageSize: 5,
      };
     
  }

  ngOnInit(): void {
    this.getClientes();
  }

  getClientes(){
    this.clienteService.getClientes(this.pagination).subscribe((res) => {
      this.totalPaginas = Math.ceil(res.pagination.totalRegistros! / this.pagination.pageSize);
      this.clientes = res.data;
      this.pagination = res.pagination;
    });
  }

  searchCliente(text: string){
    if(text.length > 0){
      this.clienteService.search(text.trim(), this.pagination).subscribe((res) => {
        this.totalPaginas = Math.ceil(res.data.length! / this.pagination.pageSize);
        this.clientes = res.data;
        this.pagination = res.pagination;
      });
    }else{
      this.getClientes();
    }
  }

  onConfirmacion(event: boolean){
    if(event && this.idClenteAEliminar){
      this.clienteService.deleteCliente(this.idClenteAEliminar).subscribe(res => {
        this.showToast({
          title: 'Cliente Eliminado',
          body: 'El cliente se ha eliminado correctamente',
          tipo: 'success'
        })
        this.getClientes();    
      }, error => {
        this.showToast({
          title: 'Error',
          body: 'No se puede eliminar el cliente',
          tipo: 'error'
        })
      })
    }
    this.showOrHideDialog();
  }

  showOrHideDialog(){
    this.showDialogo = !this.showDialogo;
  }

  eliminarCliente(id: number){
    this.idClenteAEliminar = id;
    this.showOrHideDialog();
  }

  showToast(toast: ToastModel){
    this.toastService.show(toast)
    setTimeout(() => {
      this.toastService.hide();
    }, 2000)
  }
  
  pageChange(pagination: Pagination){
    this.pagination = pagination;
    this.getClientes();
  }


}
