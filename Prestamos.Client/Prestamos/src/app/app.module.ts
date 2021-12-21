import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApiPrefixInterceptor } from './Core/interceptors/api-prefix.interceptor';
import { JwtInterceptor } from './Core/interceptors/jwt.interceptor';
import { LoandingInterceptor } from './Core/interceptors/loanding.interceptor';
import { TableComponent } from './Shared/components/table/table.component';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiPrefixInterceptor,
      multi: true,
    },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    {
      provide: HTTP_INTERCEPTORS, useClass: LoandingInterceptor, multi: true,
    }
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
