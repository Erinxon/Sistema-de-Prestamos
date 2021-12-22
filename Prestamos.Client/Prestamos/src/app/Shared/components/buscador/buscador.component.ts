import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-buscador',
  templateUrl: './buscador.component.html',
  styleUrls: ['./buscador.component.scss']
})
export class BuscadorComponent implements OnInit {
  @Output() search: EventEmitter<string> = new EventEmitter<string>();
  constructor() { }

  ngOnInit(): void {
  }

  buscar(event: any) {
    this.search.emit(event.target.value);
  }

}
