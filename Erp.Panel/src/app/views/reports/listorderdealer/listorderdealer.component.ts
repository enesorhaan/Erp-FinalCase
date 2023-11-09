import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ReportService } from 'src/app/services/report.service';

@Component({
  selector: 'app-listorderdealer',
  templateUrl: './listorderdealer.component.html',
  styleUrls: ['./listorderdealer.component.scss']
})
export class ListorderdealerComponent implements OnInit, OnDestroy {
  order:any[] = []

  constructor(
    private reportService: ReportService,
    private router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute  
  ) { }

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.reportService.getOrderReportDealer().subscribe(  (data:any) => {
      if(data.response.length == 0){
        this.toastr.error('Order not found', 'Error');
      }
      this.order = data.response;
    })
  }

  ngOnDestroy(): void {
    console.log("Destroy");
  }
}
