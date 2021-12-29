import { Directive, ElementRef, HostListener, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { EstatuCrediticioCliente } from 'src/app/Core/models/Enums/enums.model';

@Directive({
  selector: '[appColorFila]'
})
export class ColorFilaEstatusCrediticioClienteDirective implements OnChanges {
  @Input() appColorFila!: EstatuCrediticioCliente;

  constructor(private readonly elRef: ElementRef) {
  
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.elRef.nativeElement.classList.add(this.getClassByEstatus(this.appColorFila));
  }

  private getClassByEstatus(estatus: EstatuCrediticioCliente): string {
    return estatus === EstatuCrediticioCliente.Libre ? 'libre' :
    estatus === EstatuCrediticioCliente.CreditosOcupados ? 'creditosOcupados' :
    estatus === EstatuCrediticioCliente.Atrasados ?  'atrasados' : 
    estatus === EstatuCrediticioCliente.PrestamosVencidos ? 'prestamosVencidos' : '';
  }

}
