import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ToastModel } from 'src/app/Core/models/toasts/toast.model';


@Injectable({
  providedIn: 'root'
})
export class ToastService {
  private showToast = new BehaviorSubject<boolean>(false);
  private cuerpo!: ToastModel;

  constructor() { }

  getCuerpo(){
    return this.cuerpo;
  }

  getToast(){
    return this.showToast.asObservable();
  }

  show(cuerpo: ToastModel){
    this.cuerpo = cuerpo;
    this.showToast.next(true);
  }

  hide(){
    this.cuerpo = null!;
    this.showToast.next(false);
  }

}
