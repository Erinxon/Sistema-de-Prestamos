import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagarPrestamosRoutingModule } from './pagar-prestamos-routing.module';
import { PagarPrestamoComponent } from './pages/pagar-prestamo/pagar-prestamo.component';
import { SharedModule } from 'src/app/Shared/shared.module';
import { IConfig, NgxMaskModule } from 'ngx-mask';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const maskConfig: Partial<IConfig> = {
  validation: false,
};
@NgModule({
  declarations: [
    PagarPrestamoComponent,
  ],
  imports: [
    CommonModule,
    PagarPrestamosRoutingModule,
    SharedModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot(maskConfig),
  ]
})
export class PagarPrestamosModule { }
