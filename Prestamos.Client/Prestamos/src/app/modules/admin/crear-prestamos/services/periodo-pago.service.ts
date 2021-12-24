import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/Core/models/apiResponse/api-response.model';
import { PeriodoPago } from 'src/app/Core/models/periodosPagos/periodoPago.model';

@Injectable({
  providedIn: 'root'
})
export class PeriodoPagoService {

  constructor(private http: HttpClient) { }

  getPeriodosDePagos(): Observable<ApiResponse<PeriodoPago[]>> {
    return this.http.get<ApiResponse<PeriodoPago[]>>('/PeriodosPagos');
  }
}
