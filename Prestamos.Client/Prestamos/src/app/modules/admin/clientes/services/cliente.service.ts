import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/Core/models/apiResponse/api-response.model';
import { PagedResponse } from 'src/app/Core/models/apiResponse/pagination/pagedResponse.model';
import { Pagination } from 'src/app/Core/models/apiResponse/pagination/pagination.model';
import { AddCliente } from 'src/app/Core/models/clientes/addCliente.model';
import { Cliente } from 'src/app/Core/models/clientes/cliente.model';
import { UpdateCliente } from 'src/app/Core/models/clientes/update-cliente.model';
import { Estatus } from 'src/app/Core/models/estatus/estatus.model';
import { EstatusCrediticio } from 'src/app/Core/models/estatusCrediticios/estatusCrediticio.model';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private http: HttpClient) { }

  getClientes(pagination: Pagination): Observable<PagedResponse<Cliente[]>> {
    const params  = new HttpParams()
    .set('pageNumber', pagination.pageNumber)
    .set('pageSize', pagination.pageSize);
    return this.http.get<PagedResponse<Cliente[]>>('/Clientes', { params });
  }

  getClienteById(id: number): Observable<ApiResponse<Cliente>>{
    return this.http.get<ApiResponse<Cliente>>(`/Clientes/${id}`);
  }

  getClienteByCedula(cedula: string): Observable<ApiResponse<Cliente>>{
    return this.http.get<ApiResponse<Cliente>>(`/Clientes/cedula/${cedula}`);
  }

  getEstatus(): Observable<ApiResponse<Estatus[]>>{
    return this.http.get<ApiResponse<Estatus[]>>('/Estatus');
  }

  getEstatusCrediticios(): Observable<ApiResponse<EstatusCrediticio[]>>{
    return this.http.get<ApiResponse<EstatusCrediticio[]>>('/EstatusCrediticios');
  }

  search(text: string, pagination: Pagination): Observable<PagedResponse<Cliente[]>>{
    const params  = new HttpParams()
    .set('pageNumber', pagination.pageNumber)
    .set('pageSize', pagination.pageSize);
    return this.http.get<PagedResponse<Cliente[]>>(`/Clientes/search/${text}`, {params});
  }

  deleteCliente(id: number): Observable<ApiResponse<any>>{
    return this.http.delete<ApiResponse<any>>(`/Clientes/${id}`);
  }

  addCliente(Cliente: AddCliente): Observable<ApiResponse<Cliente>>{
    return this.http.post<ApiResponse<Cliente>>('/Clientes', Cliente);
  }

  updateCliente(id:number,Cliente: UpdateCliente): Observable<ApiResponse<Cliente>>{
    return this.http.put<ApiResponse<Cliente>>(`/Clientes/${id}`, Cliente);
  }
  
}
