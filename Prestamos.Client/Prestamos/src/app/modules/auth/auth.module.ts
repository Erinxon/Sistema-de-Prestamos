import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { LoginRoutingModule } from './pages/login/login-routing.module';
import { LoginModule } from './pages/login/login.module';


@NgModule({
  declarations: [
    
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    LoginModule
  ]
})
export class AuthModule { }
