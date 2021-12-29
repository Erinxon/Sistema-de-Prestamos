import { Component, OnInit } from '@angular/core';
import { Pagination } from 'src/app/Core/models/apiResponse/pagination/pagination.model';
import { PeriodoDePagos } from 'src/app/Core/models/Enums/enums.model';
import { Prestamo } from 'src/app/Core/models/prestamos/prestamo.model';
import { UserAuth } from 'src/app/Core/models/userAuth.model';
import { Usuario } from 'src/app/Core/models/usuarios/usuatio.model';
import { AuthService } from 'src/app/Shared/services/auth.service';
import { PrestamoService } from '../../../crear-prestamos/services/prestamo.service';

@Component({
  selector: 'app-prestamos',
  templateUrl: './prestamos.component.html',
  styleUrls: ['./prestamos.component.scss']
})
export class PrestamosComponent implements OnInit {
  prestamos!: Prestamo[];
  columnas: string[] = ['Cliente', 'Periodo de pagos', 'Interes', 'Cuotas', 'Capital Prestado', 'Fecha de vencimiento', 'Imprimir Factura' ,'Detalle'];

  pagination: Pagination;

  listaPageSizes: number[] = [5, 10, 15, 20];

  totalPaginas: number = 1;
  constructor(private prestamoServices: PrestamoService) {
    this.pagination = {
      pageNumber: 1,
      pageSize: 5,
    };
    this.getPrestamos();
  }

  getPrestamos(){
    this.prestamoServices.getPrestamos(this.pagination).subscribe(res => {
      this.totalPaginas = Math.ceil(res.pagination.totalRegistros! / this.pagination.pageSize);
      this.prestamos = [...res.data];
      this.pagination = res.pagination;
    })
  }

  ngOnInit(): void {
    
  }

  pageChange(event: Pagination){
    this.pagination = event;
    this.getPrestamos();
  }

}
