import { Injectable, OnDestroy } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { map, Observable, Subscription } from 'rxjs';
import { ErrorService } from 'src/app/Shared/services/error.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorGuard implements CanActivate {
  
  constructor(private errorServices: ErrorService, private router: Router) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      return this.errorServices.getError.pipe(
        map(error => error ? true : this.router.parseUrl('/'))
      )
  }

  
}
