import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RolesUsuario } from 'src/app/Core/models/Enums/enums.model';
import { Usuario } from 'src/app/Core/models/usuarios/usuatio.model';
import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'app-detalle-usuario',
  templateUrl: './detalle-usuario.component.html',
  styleUrls: ['./detalle-usuario.component.scss']
})
export class DetalleUsuarioComponent implements OnInit {
  usuario!: Usuario;
  constructor(private usuarioSvc: UsuarioService,
    private route: ActivatedRoute,
    private router: Router) { 
      this.getUsuario();
    }

  ngOnInit(): void {
  }

  getUsuario(){
    const id = +this.route.snapshot.params['id'];
    this.usuarioSvc.getUsuario(id).subscribe(res => {
      this.usuario = res.data;
    }, error => {
      this.router.navigate(['admin/usuarios']);
    });
  }

  getRolString(rol: RolesUsuario){
    return RolesUsuario[rol];
  }

  getLetrasIniciales(nombre: string, apellido: string): string {
    return nombre.charAt(0) + apellido.charAt(0);
  }



}
