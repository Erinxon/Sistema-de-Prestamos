import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Pagina } from 'src/app/Core/models/paginas/paginas.model';
import { UserAuth } from 'src/app/Core/models/userAuth.model';
import { AuthService } from 'src/app/Shared/services/auth.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  paginas: Pagina[] = [
    { titulo: 'Dashboard', url: 'dashboard', icono: 'fa-chart-line', toggled: false },
    { titulo: 'Cobrar', url: 'pagar-prestamos',  icono: 'fa-hand-holding-usd', toggled: false },
    { titulo: 'Prestar', url: 'crear-prestamos',  icono: 'fa-search-dollar', toggled: false},
    { titulo: 'Prestamos', url: 'prestamos',  icono: 'fa-money-bill', toggled: false },
    { titulo: 'Clientes', url: 'clientes',  icono: 'fa-address-card', toggled: false },
    { titulo: 'Usuarios', url: 'usuarios',  icono: 'fa-users', toggled: false },
    { titulo: 'Configuracion', url: 'configuracion',  icono: 'fa-cogs', toggled: false },
  ];
  titulo:string = 'Prestamos';
  user!: UserAuth;

  constructor(private auth: AuthService,
    private router: Router) { 
      this.auth.getUserAuth().subscribe(res => {
        this.user = res;
      });
  }

  ngOnInit(): void {
    
  }

  changeToggle(i: number){
    this.paginas[i].toggled = !this.paginas[i].toggled;
  }

  Logout(){
    this.auth.logout();
  }

}
