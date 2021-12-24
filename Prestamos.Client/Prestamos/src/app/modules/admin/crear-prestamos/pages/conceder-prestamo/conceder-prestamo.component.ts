import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Cliente } from 'src/app/Core/models/clientes/cliente.model';
import { EstatuCrediticioCliente, PeriodoDePagos } from 'src/app/Core/models/Enums/enums.model';
import { PeriodoPago } from 'src/app/Core/models/periodosPagos/periodoPago.model';
import { AddPrestamo } from 'src/app/Core/models/prestamos/add-prestamo.model';
import { AddDetallePrestamo } from 'src/app/Core/models/prestamos/detallePrestamo/add-DetallePrestamo.model';
import { ToastModel } from 'src/app/Core/models/toasts/toast.model';
import { UserAuth } from 'src/app/Core/models/userAuth.model';
import { Usuario } from 'src/app/Core/models/usuarios/usuatio.model';
import { AuthService } from 'src/app/Shared/services/auth.service';
import { ToastService } from 'src/app/Shared/services/toast.service';
import { ClienteService } from '../../../clientes/services/cliente.service';
import { PeriodoPagoService } from '../../services/periodo-pago.service';
import { PrestamoService } from '../../services/prestamo.service';

interface ResultadoBusqueda {
  succeeded: boolean;
  message?: string;
}

@Component({
  selector: 'app-conceder-prestamo',
  templateUrl: './conceder-prestamo.component.html',
  styleUrls: ['./conceder-prestamo.component.scss']
})
export class ConcederPrestamoComponent implements OnInit {
  cliente!: Cliente;
  readonly columnas: string[] = ['Nombres', 'Apellidos', 'Cedula', 'Telefono', 'Estatus Crediticio'];
  cedula: string = '';
  resultadoBusqueda!: ResultadoBusqueda;

  form: FormGroup = new FormGroup({});
  periodoPagos!: PeriodoPago[];

  tablaAmortizacion!: any;
  columnasTablaAmortizacion = ['Numero Cuota', 'Pago', 'Interes', 'Amortizacion', 'Pendiente', 'Fecha'];

  usuario!: UserAuth;
  constructor(private clienteSvc: ClienteService,
    private fb: FormBuilder,
    private periodoPagoSve: PeriodoPagoService,
    private authsvc: AuthService,
    private prestamoService: PrestamoService,
    private toast: ToastService) {
      this.getPeriodosPrestamos();
      this.createForm();
      this.getUsuario();
    }

  ngOnInit(): void {

  }

  private getPeriodosPrestamos(){
    this.periodoPagoSve.getPeriodosDePagos().subscribe(res => {
      this.periodoPagos = res.data;
    });
  }

  private getUsuario(){
    this.authsvc.getUserAuth().subscribe(res => {
      this.usuario = res;
    });
  }


  private createForm(){
    this.form = this.fb.group({
      interes: [null, [Validators.required, Validators.min(1), Validators.max(100)]],
      capital: [null, [Validators.required, Validators.min(1)]],
      cuotas: [null, [Validators.required, Validators.min(1)]],
      periodoPago: [null, [Validators.required]],
    });
  }

  isInvalid(campo: string){
    return this.form.get(campo)!.invalid && (this.form.get(campo)!.dirty || this.form.get(campo)!.touched);
  }

  buscarCliente(){
    this.cliente = null!;
    if(this.cedula.length > 0){
      this.clienteSvc.getClienteByCedula(this.cedula.trim()).subscribe(res => {
        this.cliente = res.data;
        this.resultadoBusqueda = {
          succeeded: true,
        }
      }, error => {
        this.resultadoBusqueda = {
          succeeded: false,
          message: error.error.message
        }
      })
    }
  }

  getEstatusString(estatus: EstatuCrediticioCliente): string {
    return EstatuCrediticioCliente[estatus].split(/(?=[A-Z])/).join(' ');
  }

  getPeriodoDePagoString(periodo: PeriodoDePagos){
    return PeriodoDePagos[periodo];
  }

  calcularTabla(){
    const cuotas = this.form.value.cuotas;
    const interes = this.form.value.interes;
    const periodoPago = this.form.value.periodoPago
    const capital = this.form.value.capital
    const fechaCulminacion = this.getFecha(periodoPago, new Date(), cuotas);
    let tabla = [{
      numeroCuota: 0,
      pago: 0,
      interes: 0,
      amortizacion: 0,
      saldo: capital,
      fecha: new Date()
    }];

    for(let i =1; i <= cuotas; i++){
      const pagoTable = this.getCuota(interes, capital, cuotas);
      const interesTabla = Number(( tabla[i-1].saldo * (interes / 100)).toFixed(2));
      const amortizacionTabla = Number((pagoTable - interesTabla).toFixed(2));
      const saldoTabla = Number(( tabla[i-1].saldo -  amortizacionTabla).toFixed(2));
      tabla = [...tabla, {
        numeroCuota: i,
        pago: this.getCuota(interes, capital, cuotas),
        interes: interesTabla,
        amortizacion: amortizacionTabla,
        saldo: saldoTabla,
        fecha: this.addDaysToDate(tabla[i-1].fecha, this.getDias(periodoPago))
      }]
    }
    this.tablaAmortizacion = tabla;
  }

  private getFecha(periodoPago: PeriodoDePagos, fechaInicio: Date, cuotas: number): Date  {
    const dias = periodoPago === PeriodoDePagos.Diario ? cuotas :
                 periodoPago === PeriodoDePagos.Semanal ? cuotas * 7 : 
                 periodoPago === PeriodoDePagos.Quincenal ? cuotas * 15 :
                 periodoPago === PeriodoDePagos.Mensual ? cuotas * 30 : cuotas * 365;

    return this.addDaysToDate(fechaInicio, dias);
  }

  private getDias(periodoPago: PeriodoDePagos): number {
    return periodoPago === PeriodoDePagos.Diario ? 1 :
           periodoPago === PeriodoDePagos.Semanal ? 7 : 
           periodoPago === PeriodoDePagos.Quincenal ? 15 :
           periodoPago === PeriodoDePagos.Mensual ? 30 : 365;
  }

  private addDaysToDate(date: Date, days: number): Date {
    var res = new Date(date);
    res.setDate(res.getDate() + days);
    return res;
  }

  private getCuota(interes: number, capital: number, cuotas: number): number {
    let resultado =  capital * ((interes / 100) / (1 - Math.pow((1 + (interes / 100)), - cuotas)));
    return Number(resultado.toFixed(2));
  }

  limpiarTabla(){
    this.form.reset();
  }

  confirmarPrestamo(){
    let detallePrestamo: AddDetallePrestamo[] = this.tablaAmortizacion.map((item:any) => {
      return {
        numeroCuota: item.numeroCuota,
        cuotaPagar: item.pago,
        interesPagar: item.interes,
        capitalAmortizado: item.amortizacion,
        pagado: 0,
        capitalPendiente: item.saldo,
        fechaPago: item.fecha
      }
    })

    const prestamo: AddPrestamo = {
      interes: (this.form.value.interes / 100),
      cuotas: this.form.value.cuotas,
      capital: this.form.value.capital,
      idPeriodoPago: Number(this.periodoPagos.find(p => p.periodoDePagos === this.form.value.periodoPago)?.id),
      fechaCreado: new Date(),
      fechaCulminacion: this.getFecha(this.form.value.periodoPago, new Date(), this.form.value.cuotas),
      idUsuarioUtorizador: this.usuario.id,
      idCliente: this.cliente.id,
      detallePrestamo: detallePrestamo,
    }

    this.prestamoService.addPrestamo(prestamo).subscribe(res => {
      this.showToast({
        title: 'Prestamo',
        body: 'Prestamo registrado correctamente',
        tipo: 'success'
      });
      this.cliente = null!;
      this.tablaAmortizacion = null!;
      this.cedula = null!;
      this.form.reset();
      console.log(res);
    }, error => {
      this.showToast({
        title: 'Eror',
        body: 'Ocurio un error',
        tipo: 'error'
      });
    })
  }

  showToast(toast: ToastModel){
    this.toast.show(toast)
    setTimeout(() => {
      this.toast.hide();
    }, 2000)
  }

}
