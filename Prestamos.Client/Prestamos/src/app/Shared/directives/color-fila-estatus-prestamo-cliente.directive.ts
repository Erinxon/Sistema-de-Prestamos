import { Directive, ElementRef, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { EstatusPrestamosClientes } from 'src/app/Core/models/Enums/enums.model';

@Directive({
  selector: '[appColorFilaEstatusPrestamo]'
})
export class ColorFilaEstatusPrestamoClienteDirective implements OnChanges {
  @Input() appColorFilaEstatusPrestamo!: EstatusPrestamosClientes;

  constructor(private readonly elRef: ElementRef) {
  
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.elRef.nativeElement.classList.add(this.getClassByEstatus(this.appColorFilaEstatusPrestamo));
  }

  private getClassByEstatus(estatus: EstatusPrestamosClientes): string {
    return estatus === EstatusPrestamosClientes.Pendiente ? 'pendiente' :
    estatus === EstatusPrestamosClientes.Pagado ? 'pagado' :
    estatus === EstatusPrestamosClientes.Abono ?  'abono' : 
    estatus === EstatusPrestamosClientes.Atraso ? 'atraso' : '';
  }

}
