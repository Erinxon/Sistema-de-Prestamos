import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Cliente } from 'src/app/Core/models/clientes/cliente.model';
import { EstatuCrediticioCliente } from 'src/app/Core/models/Enums/enums.model';
import { ClienteService } from '../../services/cliente.service';

@Component({
  selector: 'app-detalle-cliente',
  templateUrl: './detalle-cliente.component.html',
  styleUrls: ['./detalle-cliente.component.scss']
})
export class DetalleClienteComponent implements OnInit {
  cliente!: Cliente;
  constructor(private clienteSvc: ClienteService,
    private route: ActivatedRoute,
    private router: Router) {
      this.getCliente();
     }

  ngOnInit(): void {
  }

  getCliente(){
    const id = +this.route.snapshot.params['id'];
    this.clienteSvc.getClienteById(id).subscribe(res => {
      this.cliente = res.data;
    }, error => {
      this.router.navigate(['admin/clientes'])
    });
  }
  
  getLetrasIniciales(nombre: string, apellido: string): string {
    return nombre.charAt(0) + apellido.charAt(0);
  }


}
