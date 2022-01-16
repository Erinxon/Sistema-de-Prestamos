import { Injectable, OnDestroy } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, Subscription, throwError } from 'rxjs';
import { AuthService } from 'src/app/Shared/services/auth.service';
import { UserAuth } from '../models/userAuth.model';
import { Router } from '@angular/router';
import { ErrorService } from 'src/app/Shared/services/error.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor, OnDestroy {
  private subscription!: Subscription;
  constructor(private auth: AuthService, private router: Router,
    private errorServices: ErrorService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let user!: UserAuth;
    this.subscription = this.auth.getUserAuth().subscribe(u => {
      user = u;
    })
    if(user){
      request = request.clone({
        setHeaders: {
            authorization: `Bearer ${ user.token }`
        }
    });
    }
    return next.handle(request).pipe(
      catchError((response: HttpErrorResponse) => {
        console.log(response)
        if (response.status === 401) {
          this.auth.logout();
        }
        if(response.status === 403){
          //this.router.navigate(['/403'])
          this.errorServices.setError({
            error: 403,
            errorMessage: 'Acceso denegado, no tiene permisos para realizar esta acción'
          })
        }
        if (response.status === 500) {
          this.errorServices.setError({
            error: 500,
            errorMessage: 'Ups, algo salió mal.'
          })
        }
        if(response.status === 0){
          this.errorServices.setError({
            error: 0,
            errorMessage: 'Ups, algo salió mal.'
          })
        }
        return throwError(response);
      }
  ));
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

}
