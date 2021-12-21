import { Component } from '@angular/core';
import { LoginModel } from './Core/models/login.model';
import { AuthService } from './Shared/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor() { 
    const xd = '23232323sdsd';
    //const result = xd.replaceAll('2','');
  }
}
