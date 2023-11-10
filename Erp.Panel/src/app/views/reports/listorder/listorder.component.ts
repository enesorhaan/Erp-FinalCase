import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ReportService } from 'src/app/services/report.service';

@Component({
  selector: 'app-listorder',
  templateUrl: './listorder.component.html',
  styleUrls: ['./listorder.component.scss']
})
export class ListorderComponent implements OnInit, OnDestroy {
  report:any[] = []
  selectedValue: any;

  constructor(
    private reportService: ReportService,
    private router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute  
  ) { }

  ngOnInit(): void {
    this.load();
  }

  onFilterChange(){
    this.load();
  }

  load(){
    if(this.selectedValue == 1){
      this.reportService.getDailyOrderReport().subscribe(  (data:any) => {
        if(data.response.length == 0){
          this.toastr.error('Record not found!', 'Error');
        }
        this.report = data.response;
      });
    }else if(this.selectedValue == 2){
      this.reportService.getWeeklyOrderReport().subscribe(  (data:any) => {
        if(data.response.length == 0){
          this.toastr.error('Record not found!', 'Error');
        }
        this.report = data.response;
      });
    }else if(this.selectedValue == 3){
      this.reportService.getMonthlyOrderReport().subscribe(  (data:any) => {
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
