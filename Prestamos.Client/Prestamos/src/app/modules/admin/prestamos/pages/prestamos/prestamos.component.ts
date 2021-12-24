import { Component, OnInit } from '@angular/core';
import { UserAuth } from 'src/app/Core/models/userAuth.model';
import { Usuario } from 'src/app/Core/models/usuarios/usuatio.model';
import { AuthService } from 'src/app/Shared/services/auth.service';
import { PrestamoService } from '../../../crear-prestamos/services/prestamo.service';

@Component({
  selector: 'app-prestamos',
  templateUrl: './prestamos.component.html',
  styleUrls: ['./prestamos.component.scss']
})
export class PrestamosComponent implements OnInit {
  usuario!:  UserAuth;
  constructor(private prestamoServices: PrestamoService,
    private auth: AuthService) {
      this.auth.getUserAuth().subscribe(res => {
        this.usuario = res;
      })
    }

  ngOnInit(): void {
    this.prestamoServices.getPrestamos(this.usuario.id).subscribe(res => {
      console.log(res)
    })
  }

}
