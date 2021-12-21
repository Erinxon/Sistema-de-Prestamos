import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { LoandingService } from '../../services/loanding.service';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.scss']
})
export class SpinnerComponent implements OnInit {
  isLoanding$: Observable<boolean> = this.loandingService.getLoanding();
  
  constructor(private loandingService: LoandingService) { }

  ngOnInit(): void {

  }


}
