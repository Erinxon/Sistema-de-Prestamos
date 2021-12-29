import { Pipe, PipeTransform } from '@angular/core';
import { EstatusPrestamosClientes } from 'src/app/Core/models/Enums/enums.model';

@Pipe({
  name: 'estatusPrestamoToString'
})
export class EstatusPrestamoToStringPipe implements PipeTransform {

  transform(value: EstatusPrestamosClientes, ...args: unknown[]): string {
    return EstatusPrestamosClientes[value];
  }

}
