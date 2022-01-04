import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
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

  sidebarMini: boolean = false;
  constructor(private auth: AuthService,
    private router: Router,
    @Inject (DOCUMENT) private document: Document) { 
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

  getLetrasIniciales(nombres: string, apellidos: string): string {
    return  nombres.charAt(0) + apellidos.charAt(0);
  }

  ocultarOMostrarMenu(){
    this.sidebarMini = !this.sidebarMini;

    if(this.contains('sidebar-gone')){
     // this.document.body.classList.remove('sidebar-gone');
      //this.document.body.classList.add('sidebar-show');
      this.deleteClass('sidebar-gone');
      this.addClass('sidebar-show');
    }else{
      if(this.sidebarMini){
       // this.document.body.classList.add('sidebar-mini');
        this.addClass('sidebar-mini');
      }else{
        //this.document.body.classList.remove('sidebar-mini');
        this.deleteClass('sidebar-mini');
      }
    }
  }

  private contains(classCSS: string){
    return this.document.body.classList.contains(classCSS);
  }

  private addClass(classCSS: string){
    this.document.body.classList.add(classCSS);
  }

  private deleteClass(classCSS: string){
    this.document.body.classList.remove(classCSS);
  }



}
