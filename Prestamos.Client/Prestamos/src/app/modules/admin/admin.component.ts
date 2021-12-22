import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserAuth } from 'src/app/Core/models/userAuth.model';
import { AuthService } from 'src/app/Shared/services/auth.service';

export interface Paginas{
  titulo: string;
  url: string;
  icono: string;
  toggled: boolean;
}


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  paginas: Paginas[] = [
    { titulo: 'Dashboard', url: 'dashboard', icono: 'dashboard', toggled: false },
    { titulo: 'Pagar Prestamos', url: 'pagar-prestamos',  icono: 'dashboard', toggled: false },
    { titulo: 'Dar prestamos', url: 'crear-prestamos',  icono: 'dashboard', toggled: false},
    { titulo: 'Prestamos', url: 'prestamos',  icono: 'dashboard', toggled: false },
    { titulo: 'Clientes', url: 'clientes',  icono: 'dashboard', toggled: false },
    { titulo: 'Usuarios', url: 'usuarios',  icono: 'dashboard', toggled: false },
  ];
  user!: UserAuth;
  constructor(private auth: AuthService,
    private router: Router) { 
  
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
