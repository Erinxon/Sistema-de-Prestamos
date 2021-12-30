import { Injectable, OnDestroy } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { AuthService } from 'src/app/Shared/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationGuard implements CanActivate, OnDestroy {
  subscription!: Subscription;

  constructor(private auth: AuthService, 
    private router: Router){

  }


  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    this.subscription = this.auth.getUserAuth().subscribe(user => {
      if(!user) {
        this.router.navigate(['/auth/login']);
        return false;
      }else{
        let isPermission = route.data['roles'].indexOf(user.rol.roles) > -1;      
        if(!isPermission) this.router.navigate(['/403']);
        return isPermission;
      }
 
    })
    return true;
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
  
}
