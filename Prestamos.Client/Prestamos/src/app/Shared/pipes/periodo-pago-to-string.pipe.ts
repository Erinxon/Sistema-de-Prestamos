import { Pipe, PipeTransform } from '@angular/core';
import { PeriodoDePagos } from 'src/app/Core/models/Enums/enums.model';

@Pipe({
  name: 'periodoPagoToString'
})
export class PeriodoPagoToStringPipe implements PipeTransform {

  transform(value: PeriodoDePagos, ...args: unknown[]): unknown {
    return PeriodoDePagos[value];
  }

}
