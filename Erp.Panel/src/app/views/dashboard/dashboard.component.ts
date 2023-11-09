import { Component, OnInit } from '@angular/core';
import { StorageService } from 'src/app/services/storage.service';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  templateUrl: 'dashboard.component.html',
  styleUrls: ['dashboard.component.scss']
})


export class DashboardComponent implements OnInit {
  constructor(
    private storage: StorageService,
    private auth: AuthService
  ) {
  }


  ngOnInit(): void {
    this.load();
  }

  load(): void {
  }
}
