import { Pipe, PipeTransform } from '@angular/core';
import { EstatuCrediticioCliente } from 'src/app/Core/models/Enums/enums.model';

@Pipe({
  name: 'estatusCrediticioToString'
})
export class EstatusCrediticioToStringPipe implements PipeTransform {

  transform(value: EstatuCrediticioCliente, ...args: unknown[]): string {
    return EstatuCrediticioCliente[value].split(/(?=[A-Z])/).join(' ');
  }

}
