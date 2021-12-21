import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ToastService } from '../../services/toast.service';

@Component({
  selector: 'app-toastr',
  templateUrl: './toastr.component.html',
  styleUrls: ['./toastr.component.scss']
})
export class ToastrComponent implements OnInit {
  toast$: Observable<boolean> = this.toastService.getToast();
  constructor(public toastService: ToastService) { }

  ngOnInit(): void {
   
  }

  hide(){
    this.toastService.hide();
  }

  getIcon(tipo: string){
    return `ico-${tipo}`;
  }

  getClassColor(tipo: string){
    return tipo == 'success' ? `iziToast-color-green` : 'iziToast-color-red';
  }

}
