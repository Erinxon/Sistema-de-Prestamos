import { Directive, ElementRef, HostListener, Input, OnInit } from '@angular/core';
import { EstatuCrediticioCliente } from 'src/app/Core/models/Enums/enums.model';

@Directive({
  selector: '[appColorFila]'
})
export class ColorFilaEstatusCrediticioClienteDirective implements OnInit {
  @Input() appColorFila!: EstatuCrediticioCliente;

  constructor(private readonly elRef: ElementRef) {
  
  }
  ngOnInit(): void {
    if(this.appColorFila){
      this.elRef.nativeElement.classList.add(this.getClassByEstatus(this.appColorFila));
    }
  }

  private getClassByEstatus(estatus: EstatuCrediticioCliente): string {
    return estatus === EstatuCrediticioCliente.Libre ? 'libre' :
    estatus === EstatuCrediticioCliente.CreditosOcupados ? 'creditosOcupados' :
    estatus === EstatuCrediticioCliente.Atrasados ?  'atrasados' : 
    estatus === EstatuCrediticioCliente.PrestamosVencidos ? 'prestamosVencidos' : '';
  }

}
