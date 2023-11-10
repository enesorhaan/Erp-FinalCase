import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DealerService } from 'src/app/services/dealer.service';
import { ReportService } from 'src/app/services/report.service';

@Component({
  selector: 'app-listorderbyid',
  templateUrl: './listorderbyid.component.html',
  styleUrls: ['./listorderbyid.component.scss']
})
export class ListorderbyidComponent implements OnInit, OnDestroy {
  report:any[] = []
  selectedFilter: any;
  selectedDealer: any;

  dealer:any[] = []

  constructor(
    private reportService: ReportService,
    private dealerService: DealerService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute  
  ) { }
  
  ngOnInit(): void {
    this.load();
    this.getDealer();
  }

  onFilterChange(){
    this.load();
  }

  getDealer(){
    this.dealerService.get().subscribe(  (data:any) => {
      this.dealer = data.response;
    })
  }

  load(){
    if(this.selectedFilter == 1){
      this.reportService.getDailyOrderReportById(this.selectedDealer).subscribe(  (data:any) => {
        if(data.response.length == 0){
          this.toastr.error('Record not found!', 'Error');
        }
        this.report = data.response;
      });
    }else if(this.selectedFilter == 2){
      this.reportService.getWeeklyOrderReportById(this.selectedDealer).subscribe(  (data:any) => {
        if(data.response.length == 0){
          this.toastr.error('Record not found!', 'Error');
        }
        this.report = data.response;
      });
    }else if(this.selectedFilter == 3){
      this.reportService.getMonthlyOrderReportById(this.selectedDealer).subscribe(  (data:any) => {
        if(data.response.length == 0){
          this.toastr.error('Record not found!', 'Error');
        }
        this.report = data.response;
      });
    }
  }

  ngOnDestroy(): void {
  }

}
