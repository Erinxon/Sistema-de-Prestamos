import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PrestamosRoutingModule } from './prestamos-routing.module';
import { PrestamosComponent } from './pages/prestamos/prestamos.component';
import { SharedModule } from 'src/app/Shared/shared.module';
import { FormsModule } from '@angular/forms';
import { DetallePrestamoComponent } from './pages/detalle-prestamo/detalle-prestamo.component';
import { IConfig, NgxMaskModule } from 'ngx-mask';

const maskConfig: Partial<IConfig> = {
  validation: false,
};

@NgModule({
  declarations: [
    PrestamosComponent,
    DetallePrestamoComponent
  ],
  imports: [
    CommonModule,
    PrestamosRoutingModule,
    FormsModule,
    SharedModule,
    NgxMaskModule.forRoot(maskConfig),
  ]
})
export class PrestamosModule { }
