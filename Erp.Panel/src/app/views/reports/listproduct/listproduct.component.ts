import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ReportService } from 'src/app/services/report.service';

@Component({
  selector: 'app-listproduct',
  templateUrl: './listproduct.component.html',
  styleUrls: ['./listproduct.component.scss']
})
export class ListproductComponent implements OnInit, OnDestroy {
  product:any[] = []
  checkProduct:any[] = []

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
    this.reportService.getProductReport().subscribe(  (data:any) => {
      if(data.response.length == 0){
        this.toastr.error('Product not found', 'Error');
      }
      this.product = data.response;
    })
    this.reportService.getProductCheckReport().subscribe(  (data:any) => {
      if(data.response.length == 0){
        this.toastr.success('The quantity of products is more than 10!', 'Success');
      }
      this.checkProduct = data.response;
    })
  }

  ngOnDestroy(): void {
    console.log("Destroy");
  }
}
