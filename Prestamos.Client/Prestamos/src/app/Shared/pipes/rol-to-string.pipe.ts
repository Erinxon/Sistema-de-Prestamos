import { Pipe, PipeTransform } from '@angular/core';
import { RolesUsuario } from 'src/app/Core/models/Enums/enums.model';

@Pipe({
  name: 'rolToString'
})
export class RolToStringPipe implements PipeTransform {

  transform(value: RolesUsuario, ...args: unknown[]): unknown {
    return RolesUsuario[value];
  }

}
