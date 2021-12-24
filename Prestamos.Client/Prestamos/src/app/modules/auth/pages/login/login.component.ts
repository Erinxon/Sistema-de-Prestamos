import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LoginModel } from 'src/app/Core/models/login.model';
import { ToastModel } from 'src/app/Core/models/toasts/toast.model';
import { UserAuth } from 'src/app/Core/models/userAuth.model';
import { AuthService } from 'src/app/Shared/services/auth.service';
import { ToastService } from 'src/app/Shared/services/toast.service';

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
    private router: Router,
    private toast: ToastService) { 
    this.createForm();
    this.subscription = this.auth.getUserAuth().subscribe(u => {
      if(u){
        this.router.navigate(['/admin/home'])
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

  isInvalid(campo: string){
    return this.form.get(campo)!.invalid && (this.form.get(campo)!.dirty || this.form.get(campo)!.touched);
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
      this.showToast(
        {
          title: 'Usuario invalido',
          body: error.error.message,
          tipo: 'error'
        }
      )
      this.loanding = false;
    })
  }

  get composForm() {
    return {
      email: this.form.get('email')!,
      password: this.form.get('password')!
    }
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }


  showToast(toast: ToastModel){
    this.toast.show(toast)
    setTimeout(() => {
      this.toast.hide();
    }, 2000)
  }


}
