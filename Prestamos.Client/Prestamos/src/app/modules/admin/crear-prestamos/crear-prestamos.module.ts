import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CrearPrestamosRoutingModule } from './crear-prestamos-routing.module';
import { ConcederPrestamoComponent } from './pages/conceder-prestamo/conceder-prestamo.component';
import { SharedModule } from 'src/app/Shared/shared.module';
import { IConfig, NgxMaskModule } from 'ngx-mask';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FacturaComponent } from './pages/factura/factura.component';


const maskConfig: Partial<IConfig> = {
  validation: false,
};

@NgModule({
  declarations: [
    ConcederPrestamoComponent,
    FacturaComponent
  ],
  imports: [
    CommonModule,
    CrearPrestamosRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxMaskModule.forRoot(maskConfig),
  ]
})
export class CrearPrestamosModule { }
