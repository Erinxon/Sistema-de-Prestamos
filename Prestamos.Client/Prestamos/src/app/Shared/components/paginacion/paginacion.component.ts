import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Pagination } from 'src/app/Core/models/apiResponse/pagination/pagination.model';

@Component({
  selector: 'app-paginacion',
  templateUrl: './paginacion.component.html',
  styleUrls: ['./paginacion.component.scss']
})
export class PaginacionComponent implements OnInit {
  @Input() paginacion!: Pagination;
  @Input() totalPaginas!: number;
  @Output() pageChange = new EventEmitter<Pagination>();
  constructor() { }

  ngOnInit(): void {
  }

  anterior(): void {
    this.paginacion.pageNumber--;
    this.pageChange.emit(this.paginacion);
  }

  siguiente(): void {
    this.paginacion.pageNumber++;
    this.pageChange.emit(this.paginacion);
  }

}
