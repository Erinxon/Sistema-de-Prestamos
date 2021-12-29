import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EstatuCrediticioCliente, EstatusPrestamosClientes, PeriodoDePagos, RolesUsuario } from 'src/app/Core/models/Enums/enums.model';
import { Prestamo } from 'src/app/Core/models/prestamos/prestamo.model';
import { PrestamoService } from '../../../crear-prestamos/services/prestamo.service';

@Component({
  selector: 'app-detalle-prestamo',
  templateUrl: './detalle-prestamo.component.html',
  styleUrls: ['./detalle-prestamo.component.scss']
})
export class DetallePrestamoComponent implements OnInit {
  prestamo!: Prestamo;
  columnasCliente: string[] =  ['Nombres', 'Apellidos', 'Cedula', 'Telefono', 'Estatus Crediticio'];
  columnasUsuario: string[] = ['Nombres', 'Apellidos', 'Cedula', 'Telefono', 'Rol'];
  columnasPrestamo: string[] = ['Periodo de pagos', 'Interes', 'Cuotas', 'Capital Prestado', 'Fecha de vencimiento'];
  columnasCronograma: string[]= ['Número Cuota', 'Pago', 'Interes', 'Amortización', 'Pagado', 'Pendiente', 'Estatus', 'Fecha de pago'];
  constructor(private prestamoSvc: PrestamoService,
    private route: ActivatedRoute,
    private router:  Router) {
      this.getPrestamo();
    }

  ngOnInit(): void {
  }

  getPrestamo(){
    const id = +this.route.snapshot.params['id'];
    this.prestamoSvc.getPrestamoById(id).subscribe(res => {
      this.prestamo = res.data;
    }, error => {
      this.router.navigate(['admin/prestamos']);
    });
  }

}
