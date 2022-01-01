import { Component, Input, OnInit } from '@angular/core';
import { Pagina } from 'src/app/Core/models/paginas/paginas.model';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  @Input() paginas!: Pagina[];
  @Input() titulo!: string;
  constructor() { }

  ngOnInit(): void {
  }

  changeToggle(i: number){
    this.paginas[i].toggled = !this.paginas[i].toggled;
  }

}
