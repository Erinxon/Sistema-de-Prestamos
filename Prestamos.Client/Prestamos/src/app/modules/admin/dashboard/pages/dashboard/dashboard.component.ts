import { Component, OnInit } from '@angular/core';
import { Dashboard } from 'src/app/Core/models/dashboard/dashboard.model';
import { DashboardService } from '../../services/dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  dashboard!: Dashboard;
  constructor(private dashboardService: DashboardService) { 
    this.getDatos();
  }

  ngOnInit(): void {
  }

  getDatos(){
    this.dashboardService.getDatos().subscribe(res => {
      this.dashboard = res.data;
    })
  }
  

}
