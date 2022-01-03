import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/Core/models/apiResponse/api-response.model';
import { Dashboard } from 'src/app/Core/models/dashboard/dashboard.model';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor(private http: HttpClient) { }

  getDatos(): Observable<ApiResponse<Dashboard>> {
    return this.http.get<ApiResponse<Dashboard>>('/Dashboard');
  }

}
