import { formatDate } from '@angular/common';
import { Injectable } from '@angular/core';
import {  ITable, PdfMakeWrapper, Table, Txt } from 'pdfmake-wrapper';

import * as pdfFonts from "pdfmake/build/vfs_fonts";
import { Cliente } from 'src/app/Core/models/clientes/cliente.model';
import { Empresa } from 'src/app/Core/models/empresa/empresa.model';
import { PeriodoDePagos } from 'src/app/Core/models/Enums/enums.model';
import { DetallePrestamo } from 'src/app/Core/models/prestamos/detallePrestamo/detalle-Prestamos.model';
import { Prestamo } from 'src/app/Core/models/prestamos/prestamo.model';
import { ConfiguracionService } from '../../configuracion/services/configuracion.service';

PdfMakeWrapper.setFonts(pdfFonts);


@Injectable({
  providedIn: 'root',
})
export class CronogramprestamoPdfService {
  private empresa!: Empresa;
  private detalleprestamo!: DetallePrestamo[];
  private prestamo!: Prestamo;
  private cliente!: Cliente;
  private pdf: PdfMakeWrapper;

  constructor(private empresaSvc: ConfiguracionService) {
    this.pdf = new PdfMakeWrapper();
    this.empresaSvc.getDatosEmpresa().subscribe(e => {
      this.empresa = e.data;
    })
  }

  setData(prestamo: Prestamo){
    this.prestamo = prestamo;
    this.detalleprestamo = prestamo.detallePrestamos;
    this.cliente = prestamo.cliente;
  }

  generatePdf() {  
    this.datosEmpresa();
    this.createTableDataCliente();
    this.createTableInfoPrestamo();
    this.createTableAmorticacion();
    this.footer();
  }

  private datosEmpresa(){
    this.pdf.add(
      new Txt(this.empresa.nombre)
     .fontSize(14)
     .color('#2f4f4f')
     .bold()
     .alignment('center').end
   )
   this.pdf.add(
     new Txt(`
      ${this.empresa.direccion.provincia} /  ${this.empresa.direccion.calle} /  ${this.empresa.direccion.numero}

      Telefono: ${this.empresa.telefono} Email: ${this.empresa.email}

      RNC: ${this.empresa.rnc}
     `)
     .fontSize(12)
     .alignment('center')
     .end
   )
  }

  private setEncabezadoTable(titulo: string){
    this.pdf.add(
      new Txt(titulo)
      .fontSize(15)
      .margin([0,15,0,5])
      .alignment('center')
      .color('#2f4f4f')
      .end
    );
  }

  private getTable(columnas: string[], filas: any[]): ITable{
    const table: ITable = new Table([columnas,filas])
    .widths('*')
    .fontSize(12)
    .layout('lightHorizontalLines')
    .end;
    return table;
  }

  private createTableAmorticacion(){
    const table: ITable = new Table([
      ['Cuota #', 'Cuota a Pagar', 'Interes' ,'Amortización', 'Pendiente', 'Fecha de pago'],
      ...this.detalleprestamo.map(p => [
        p.numeroCuota,
        p.cuotaPagar,
        p.interesPagar,
        p.capitalAmortizado,
        p.capitalPendiente,
        formatDate(p.fechaPago, 'dd/MM/yyyy', 'en-US')
      ])
    ])
    .widths('*')
    .fontSize(12)
    .layout('lightHorizontalLines')
    .end;
    this.setEncabezadoTable('Cronograma de pagos');
    this.pdf.add(table);
  }

  private createTableDataCliente() {
    const table = this.getTable(['Nombre del cliente', 'Cedula', 'Telefono', 'Direccion'],
    [
      `${this.cliente.nombres} ${this.cliente.apellidos}`,
      this.cliente.cedula,
      this.cliente.telefono,
      `${this.cliente.direccion.provincia} / ${this.cliente.direccion.calle} / ${this.cliente.direccion.numero}`,
    ]);
    this.setEncabezadoTable('Datos del cliente');
    this.pdf.add(table);
  }

  private createTableInfoPrestamo(){
    const table = this.getTable( ['Periodo de pago', 'Interes', 'Cuotas', 'Capital Prestado', 'Cuota fija', 'Fecha vencimiento'],
    [
      PeriodoDePagos[this.prestamo.periodoPago.periodoDePagos],`${this.prestamo.interes*100}%`,
      this.prestamo.cuotas,this.prestamo.capital, this.detalleprestamo[1].cuotaPagar, 
      formatDate(this.prestamo.fechaCulminacion, 'dd/MM/yyy', 'en-US')
    ]);
    this.setEncabezadoTable('Información del prestamo');
    this.pdf.add(table);
  }

  private footer(){
    const totalIntereses = this.detalleprestamo.reduce((prev, current) => prev + current.interesPagar, 0);
    const total = this.detalleprestamo.reduce((prev, current) => prev + current.cuotaPagar, 0);
    this.pdf.add(
      new Txt(`Intereses: ${totalIntereses.toFixed(2)}`)
     .fontSize(13)
     .bold()
     .margin([0,5,0,5])
     .alignment('left').end
   );
   this.pdf.add(
    new Txt(`Total de pagar: ${total.toFixed(2)}`)
   .fontSize(13)
   .bold()
   .alignment('left').end
   );
  }

  open(){
    this.pdf.create().open();
  }

  download(fileName: string){
    this.pdf.create().download(`${fileName}.pdf`);
  }

  print(){
    this.pdf.create().print();
  }

  clear(){
    this.pdf = new PdfMakeWrapper();
  }
 
}