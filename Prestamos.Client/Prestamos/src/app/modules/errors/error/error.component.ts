import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { ErrorModel } from 'src/app/Core/models/error/error.model';
import { ErrorService } from 'src/app/Shared/services/error.service';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss']
})
export class ErrorComponent implements OnInit, OnDestroy {
  errorModel!: ErrorModel;
  private subscription!: Subscription;

  constructor(private errorServices: ErrorService) {
    this.subscription = this.errorServices.getError.subscribe(e => {
      this.errorModel = e;
    })
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
   this.errorServices.setError(null!)
   this.subscription.unsubscribe();
  }


}
