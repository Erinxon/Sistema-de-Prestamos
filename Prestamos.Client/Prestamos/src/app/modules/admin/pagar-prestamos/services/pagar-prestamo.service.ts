import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/Core/models/apiResponse/api-response.model';
import { EstatusPrestamo } from 'src/app/Core/models/estatusPrestamos/estatusPrestamo.model';
import { Prestamo } from 'src/app/Core/models/prestamos/prestamo.model';

@Injectable({
  providedIn: 'root'
})
export class PagarPrestamoService {

  constructor(private htttp: HttpClient) { }

  getPrestamosByCliente(cedula: string): Observable<ApiResponse<Prestamo>>{
    return this.htttp.get<ApiResponse<Prestamo>>(`/Prestamos/GetByCliente/${cedula}`);
  }

  getEstatusPrestamos(): Observable<ApiResponse<EstatusPrestamo[]>>{
    return this.htttp.get<ApiResponse<EstatusPrestamo[]>>('/EstatusPrestamos');
  }

  pagarPrestamo(prestamo: Prestamo): Observable<ApiResponse<Prestamo>>{
    return this.htttp.put<ApiResponse<Prestamo>>(`/Prestamos/Pagar/${prestamo.id}`, prestamo);
  }
}
