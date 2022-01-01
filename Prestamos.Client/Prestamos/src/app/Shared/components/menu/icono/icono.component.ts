import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-icono',
  templateUrl: './icono.component.html',
  styleUrls: ['./icono.component.scss']
})
export class IconoComponent {
  @Input() icono!: string;
  
  constructor() { }

}
