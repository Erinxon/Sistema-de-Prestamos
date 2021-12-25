import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/Core/models/apiResponse/api-response.model';
import { AddPrestamo } from 'src/app/Core/models/prestamos/add-prestamo.model';
import { Prestamo } from 'src/app/Core/models/prestamos/prestamo.model';

@Injectable({
  providedIn: 'root'
})
export class PrestamoService {

  constructor(private http: HttpClient) { }

  addPrestamo(prestamo: AddPrestamo): Observable<ApiResponse<Prestamo>>{
    return this.http.post<ApiResponse<Prestamo>>('/prestamos', prestamo);
  }

  getPrestamos(idUsuarioConsultor: number): Observable<ApiResponse<Prestamo[]>>{
    let params = new HttpParams().set('idUsuario', idUsuarioConsultor);
    return this.http.get<ApiResponse<Prestamo[]>>('/Prestamos', {
      params
    });
  }

  getPrestamoById(idPrestamo: number): Observable<ApiResponse<Prestamo>>{
    return this.http.get<ApiResponse<Prestamo>>(`/Prestamos/GetByid/${idPrestamo}`);
  }

}
