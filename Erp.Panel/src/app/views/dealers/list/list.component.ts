import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DealerService } from 'src/app/services/dealer.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit, OnDestroy {
  dealer:any[] = []
  
  constructor(
    private dealerService: DealerService,
    private router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute  
  ) { }

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.dealerService.get().subscribe(  (data:any) => {
      this.dealer = data.response;
      if(this.dealer == null ){
        this.toastr.error('Dealer not found!', 'Error');
      }
    })
  }

  isDelete(dealerId:number){
    this.dealerService.delete(dealerId).subscribe({
      next: data => {
        this.router.navigate(['/dealer/list']);
      },
      error: error => {
        this.toastr.error(error.error.message, "Error");
      }
    })
    this.toastr.success('Dealer deleted!', 'Success');
  }

  ngOnDestroy(): void {
  }
}
