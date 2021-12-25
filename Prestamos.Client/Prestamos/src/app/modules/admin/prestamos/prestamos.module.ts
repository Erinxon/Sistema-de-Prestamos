import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PrestamosRoutingModule } from './prestamos-routing.module';
import { PrestamosComponent } from './pages/prestamos/prestamos.component';
import { SharedModule } from 'src/app/Shared/shared.module';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PrestamosComponent
  ],
  imports: [
    CommonModule,
    PrestamosRoutingModule,
    FormsModule,
    SharedModule
  ]
})
export class PrestamosModule { }
