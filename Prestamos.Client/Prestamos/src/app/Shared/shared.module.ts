import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableComponent } from './components/table/table.component';
import { VentanaConfirmacionComponent } from './components/ventana-confirmacion/ventana-confirmacion.component';
import { FooterComponent } from './components/footer/footer.component';
import { MenuComponent } from './components/menu/menu.component';
import { HeaderComponent } from './components/header/header.component';
import { RouterModule } from '@angular/router';
import { PaginacionComponent } from './components/paginacion/paginacion.component';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { ToastrComponent } from './components/toastr/toastr.component';
import { Error403Component } from './components/errors/error403/error403.component';
import { BuscadorComponent } from './components/buscador/buscador.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    TableComponent,
    VentanaConfirmacionComponent,
    FooterComponent,
    MenuComponent,
    HeaderComponent,
    PaginacionComponent,
    SpinnerComponent,
    ToastrComponent,
    Error403Component,
    BuscadorComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  exports: [
    TableComponent,
    VentanaConfirmacionComponent,
    FooterComponent,
    MenuComponent,
    HeaderComponent,
    PaginacionComponent,
    SpinnerComponent,
    ToastrComponent,
    Error403Component,
    BuscadorComponent
  ]
})
export class SharedModule { }
