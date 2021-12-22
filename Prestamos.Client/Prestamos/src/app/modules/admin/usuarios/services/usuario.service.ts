import { HttpClient, HttpParams } from '@angular/common/http';
import { ReturnStatement } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/Core/models/apiResponse/api-response.model';
import { PagedResponse } from 'src/app/Core/models/apiResponse/pagination/pagedResponse.model';
import { Pagination } from 'src/app/Core/models/apiResponse/pagination/pagination.model';
import { UpdateCliente } from 'src/app/Core/models/clientes/update-cliente.model';
import { Rol } from 'src/app/Core/models/roles/rol.model';
import { UpdateUsuario } from 'src/app/Core/models/usuarios/update-usuario.model';
import { Usuario } from 'src/app/Core/models/usuarios/usuatio.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) { }


  addUsuario(usuario: Usuario): Observable<ApiResponse<Usuario>>{
    return this.http.post<ApiResponse<Usuario>>('/Usuarios', usuario);
  }

  updateUsuario(id: number,usuario: UpdateUsuario): Observable<ApiResponse<Usuario>> {
    return this.http.put<ApiResponse<Usuario>>(`/Usuarios/${id}`, usuario);
  }

  getUsuarios(pagination: Pagination): Observable<PagedResponse<Usuario[]>> {
    const params  = new HttpParams()
    .set('pageNumber', pagination.pageNumber)
    .set('pageSize', pagination.pageSize);
    return this.http.get<PagedResponse<Usuario[]>>('/Usuarios', {params});
  }

  getUsuario(id: number): Observable<ApiResponse<Usuario>> {
    return this.http.get<ApiResponse<Usuario>>(`/Usuarios/${id}`);
  }

  deleteUsuario(id: number): Observable<ApiResponse<Usuario>> {
    return this.http.delete<ApiResponse<Usuario>>(`/Usuarios/${id}`);
  }

  search(text: string,pagination: Pagination): Observable<PagedResponse<Usuario[]>> {
    const params  = new HttpParams()
    .set('pageNumber', pagination.pageNumber)
    .set('pageSize', pagination.pageSize);
    return this.http.get<PagedResponse<Usuario[]>>(`/Usuarios/search/${text}`, {params});
  }

  getRoles(): Observable<ApiResponse<Rol[]>> {
    return this.http.get<ApiResponse<Rol[]>>('/Roles');
  }

}
