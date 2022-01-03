import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/Core/models/apiResponse/api-response.model';
import { Cliente } from 'src/app/Core/models/clientes/cliente.model';
import { EstatuCrediticioCliente, EstatusPrestamosClientes } from 'src/app/Core/models/Enums/enums.model';
import { EstatusCrediticio } from 'src/app/Core/models/estatusCrediticios/estatusCrediticio.model';
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

  IsPrestamoPagado(id: number): Observable<ApiResponse<boolean>> {
    return this.htttp.get<ApiResponse<boolean>>(`/Prestamos/IsPrestamoPagado/${id}`);
  }

  updateEstatus(id: number, estatus: EstatuCrediticioCliente){
    const params =  new HttpParams()
    .set('id', id).set('estatus', estatus);
    return this.htttp.put<ApiResponse<Cliente>>('/Clientes/UpdateEstatus','',{
      params
    });
  }

  updateEstatusPrestamo(id: number, estatus: EstatusPrestamosClientes){
    const params =  new HttpParams()
    .set('id', id).set('estatus', estatus);
    return this.htttp.put<ApiResponse<Cliente>>('/Prestamos/UpdateEstatusPrestamo','',{
      params
    });
  }
}
