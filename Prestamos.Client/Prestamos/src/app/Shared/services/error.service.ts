import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { ErrorModel } from 'src/app/Core/models/error/error.model';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {
  private currentError: BehaviorSubject<ErrorModel> = new BehaviorSubject<ErrorModel>(null!);

  constructor(private router: Router) { }

  setError(error: ErrorModel){
    this.currentError.next(error);
    this.handleError();
  }

  get getError(){
    return this.currentError.asObservable();
  }

  private handleError() {
    this.router.navigate(['/error']);
  }

}
