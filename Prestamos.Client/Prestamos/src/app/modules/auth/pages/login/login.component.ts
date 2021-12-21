import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LoginModel } from 'src/app/Core/models/login.model';
import { UserAuth } from 'src/app/Core/models/userAuth.model';
import { AuthService } from 'src/app/Shared/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  form: FormGroup = new FormGroup({});
  loanding: boolean = false;
  private subscription!: Subscription;

  constructor(private fb: FormBuilder, private auth: AuthService,
    private router: Router) { 
    this.createForm();
    this.subscription = this.auth.getUserAuth().subscribe(u => {
      if(u){
        this.router.navigate(['/admin/dashboard'])
      }
    });
  }

  ngOnInit(): void {
    
  }

  createForm(): void {
    this.form = this.fb.group({
      email: ['prueba1@gmail.com', [Validators.required, Validators.email]],
      password: ['123456789', [Validators.required]]
    });
  }

  onSubmit(){
    this.loanding = true;
    const authModel: LoginModel = {...this.form.value}
    this.auth.login(authModel).subscribe(res => {
      if(res.succeeded){
        this.auth.setUserAuth(res.data);
        this.router.navigate(['/admin'])
      }
      this.loanding = false;
    }, error => {
      console.log(error)
      this.loanding = false;
    })
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }




}
