import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/Core/models/apiResponse/api-response.model';
import { Empresa } from 'src/app/Core/models/empresa/empresa.model';
import { UpdateEmpresa } from 'src/app/Core/models/empresa/update-empresa.model';

@Injectable({
  providedIn: 'root'
})
export class ConfiguracionService {

  constructor(private http: HttpClient) { }

  getDatosEmpresa(): Observable<ApiResponse<Empresa>> {
    return this.http.get<ApiResponse<Empresa>>(`/Empresa`);
  }

  updateDatosEmpresa(id:number,empresa: UpdateEmpresa): Observable<ApiResponse<Empresa>>{
    return this.http.put<ApiResponse<Empresa>>(`/Empresa/${id}`, empresa);
  }

}
