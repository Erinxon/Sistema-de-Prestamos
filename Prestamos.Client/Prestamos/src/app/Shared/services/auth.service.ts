
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiResponse } from 'src/app/Core/models/apiResponse/api-response.model';
import { LoginModel } from 'src/app/Core/models/login.model';
import { UserAuth } from 'src/app/Core/models/userAuth.model';
import { LocalStorageService } from './local-storage.service';

@Injectable({providedIn: 'root'})
export class AuthService {
    private currentUser: UserAuth = this.LocalStorageSve.getItem("user");
    private userAuth: BehaviorSubject<UserAuth> = new BehaviorSubject<UserAuth>(this.currentUser);

    constructor(private http: HttpClient, 
        private LocalStorageSve: LocalStorageService, 
        private router: Router) { }
    
    login(loginModel: LoginModel): Observable<ApiResponse<UserAuth>> {
        return this.http.post<ApiResponse<UserAuth>>('/auth', loginModel);
    }

    isAutehticated(): Observable<boolean> {
        return this.userAuth.asObservable()
        .pipe(
            map(user => user != null)
        );
    }

    setUserAuth(user: UserAuth): void {
        this.LocalStorageSve.setItem('user', user);
        this.userAuth.next(user);
    }

    getUserAuth(): Observable<UserAuth> {
        return this.userAuth.asObservable();
    }

    logout(): void {
        this.LocalStorageSve.removeItem("user");
        this.userAuth.next(null!);
        this.router.navigate(['/auth/login']);
    }
}