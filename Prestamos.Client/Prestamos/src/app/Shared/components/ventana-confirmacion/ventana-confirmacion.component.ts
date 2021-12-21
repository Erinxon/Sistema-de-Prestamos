import { ThrowStmt } from '@angular/compiler';
import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-ventana-confirmacion',
  templateUrl: './ventana-confirmacion.component.html',
  styleUrls: ['./ventana-confirmacion.component.scss']
})
export class VentanaConfirmacionComponent implements OnInit, OnDestroy {
  @Input() titulo!: string;
  @Output() confirmar = new EventEmitter<boolean>();
  
  constructor() { }
 
  ngOnInit(): void {
   
  }

  onConfirmar(value: boolean) {
    this.confirmar.emit(value)
  }

  ngOnDestroy(): void {
    this.confirmar.unsubscribe();
  }

}
