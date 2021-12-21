import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/Shared/services/auth.service';
import { UserAuth } from '../models/userAuth.model';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private auth: AuthService, private router: Router){

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let user!: UserAuth;
    this.auth.getUserAuth().subscribe(u => {
      user = u;
    });
    if(user){
      return true;
    }else{
      this.router.navigate(['/auth/login']);
      return false;  
    }
  }
  
}
