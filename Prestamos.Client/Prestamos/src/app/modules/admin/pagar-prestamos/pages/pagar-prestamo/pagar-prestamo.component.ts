import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Cliente } from 'src/app/Core/models/clientes/cliente.model';
import { EstatuCrediticioCliente, EstatusPrestamosClientes } from 'src/app/Core/models/Enums/enums.model';
import { EstatusCrediticio } from 'src/app/Core/models/estatusCrediticios/estatusCrediticio.model';
import { EstatusPrestamo } from 'src/app/Core/models/estatusPrestamos/estatusPrestamo.model';
import { DetallePrestamo } from 'src/app/Core/models/prestamos/detallePrestamo/detalle-Prestamos.model';
import { Prestamo } from 'src/app/Core/models/prestamos/prestamo.model';
import { ToastModel } from 'src/app/Core/models/toasts/toast.model';
import { ToastService } from 'src/app/Shared/services/toast.service';
import { PagarPrestamoService } from '../../services/pagar-prestamo.service';

interface ResultadoBusqueda {
  succeeded: boolean;
  message?: string;
}

@Component({
  selector: 'app-pagar-prestamo',
  templateUrl: './pagar-prestamo.component.html',
  styleUrls: ['./pagar-prestamo.component.scss']
})
export class PagarPrestamoComponent implements OnInit {
  readonly columnas: string[] = ['Nombre', 'Monto', 'Fecha de Vencimiento', 'Estatus'];
  cedula: string = '';
  prestamo!: Prestamo;
  resultadoBusqueda!: ResultadoBusqueda;
  form!: FormGroup;
  detallePrestamo: DetallePrestamo[] = [];
  showDialogo: boolean = false;
  readonly columnasDetallePrestamo = ['Numero Cuota', 'Cuota a Pagar', 'Interes a Pagar', 'Capital Amortizado', 'Pagado', 'Estatus'];
  estatusPrestamos!: EstatusPrestamo[];

  constructor(private pagarPrestamoService: PagarPrestamoService,
    private fb: FormBuilder,
    private toast: ToastService) {
      this.pagarPrestamoService.getEstatusPrestamos().subscribe(res => {
        this.estatusPrestamos = res.data;
      })
      this.makeForm();
  }

  ngOnInit(): void {
  }

  makeForm(){
    this.form = this.fb.group({
      monto: [null, [Validators.required]],
    })
  }

  buscarCliente(){
    this.prestamo = null!;
    if(this.cedula.length > 0){
      this.pagarPrestamoService.getPrestamosByCliente(this.cedula.trim()).subscribe(res => {
        this.prestamo = res.data;
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

  showOrHideDialog(){
    this.showDialogo = !this.showDialogo;
  }

  onSubmit(){
    this.showOrHideDialog();
  }


  private getDataPrestamoForm(){
    const detalle: DetallePrestamo[] = [...this.prestamo.detallePrestamos];
    let montoOriginal = this.form.value.monto;
    let monto = montoOriginal;
    detalle.forEach((d, index) => {
      if(index > 0 && d.pagado < d.cuotaPagar && monto > 0){
        if(montoOriginal === monto && d.estatusPrestamo.estatusPrestamos === EstatusPrestamosClientes.Pendiente){
          monto -= d.cuotaPagar;
          d.pagado = d.cuotaPagar;  
        }
        else if(d.estatusPrestamo.estatusPrestamos === EstatusPrestamosClientes.Abono){
          let restanteAPagar = this.redondear(d.cuotaPagar - d.pagado);
          if(monto > restanteAPagar){
            monto -= restanteAPagar;
            d.pagado = this.redondear(d.pagado + restanteAPagar);
          }
          else{
            d.pagado = this.redondear(d.pagado + monto);
            monto = 0;
          }
        }
        else{
          if(monto < d.cuotaPagar){
            d.pagado = monto;
            monto -= d.pagado;
          }else{
            d.pagado = d.cuotaPagar;
            monto -= d.cuotaPagar;
          }     
        }
        monto = Math.abs(this.redondear(monto));     
        d.idEstatusPrestamo = d.pagado === d.cuotaPagar ? EstatusPrestamosClientes.Pagado 
                              : EstatusPrestamosClientes.Abono;
        d.estatusPrestamo = d.pagado === d.cuotaPagar ? this.getEstatus(EstatusPrestamosClientes.Pagado)
                              : this.getEstatus(EstatusPrestamosClientes.Abono);
        this.detallePrestamo = [...this.detallePrestamo, {...d}]
      }
    })
    return this.detallePrestamo;
  }
  

  pagarPrestamo(){
    this.prestamo.detallePrestamos = [...this.getDataPrestamoForm()]; 
    this.updatePrestamo();
    this.resetForm();
  }

  private UpdateEstatusCliente(id: number){
    this.pagarPrestamoService.updateEstatus(id, EstatuCrediticioCliente.Libre)
      .subscribe(res => {
      }, error => {
        console.log(error);
      })
  }

  private updatePrestamo(){
    this.pagarPrestamoService.pagarPrestamo(this.prestamo).subscribe(res => {
      this.showToast({
        title: 'Prestamo',
        body: 'Pago realizado con exito',
        tipo: 'success'
      });
      this.verificarPagoCompleto(res.data);
    }, error => {
      console.log(error.error.message);
      this.showToast({
        title: 'Eror',
        body: 'Ocurrio un error al realizar el pago',
        tipo: 'error'
      });
    });
  }

  getEstatus(estatus: EstatusPrestamosClientes){
    return this.estatusPrestamos.find(e => e.estatusPrestamos === estatus)!;
  }
  private redondear(numero: number): number {
    return Number(numero.toFixed(3));
  }

  resetForm(){
    this.form.reset();
    this.cedula = '';
    this.prestamo = null!;
    this.detallePrestamo = [];
  }

  onConfirmacion(event: boolean){
    if(event){
      this.pagarPrestamo();
      this.showOrHideDialog();
    }else{
      this.showOrHideDialog();
    }
  }

  showToast(toast: ToastModel){
    this.toast.show(toast)
    setTimeout(() => {
      this.toast.hide();
    }, 2000)
  }

  private updateEstatusPrestamo(id: number){
    this.pagarPrestamoService.updateEstatusPrestamo(id, EstatusPrestamosClientes.Pagado)
    .subscribe(res => {

    });
  }

  private verificarPagoCompleto(prestamo: Prestamo){
    this.pagarPrestamoService.IsPrestamoPagado(prestamo.id)
    .subscribe(res => {
       if(res.data){
         this.UpdateEstatusCliente(prestamo.cliente.id);
         this.updateEstatusPrestamo(prestamo.id);
       }
       console.log(res)
    }, error => {
      console.log(error);
    });
  }

}
