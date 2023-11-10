import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CurrentaccountsService } from 'src/app/services/currentaccounts.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit, OnDestroy {
  currentAccount:any[] = []
  
  constructor(
    private currentAccountService: CurrentaccountsService,
    private router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute  
  ) { }

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.currentAccountService.get().subscribe(  (data:any) => {
      this.currentAccount = data.response;
      if(this.currentAccount == null ){
        this.router.navigate(['/currentaccount/add']);
      }
    })
  }

  isDelete(dealerId:number){
    this.currentAccountService.delete(dealerId).subscribe({
      next: data => {
        this.router.navigate(['/currentaccount/list']);
      },
      error: error => {
        this.toastr.error(error.error.message, "Error");
      }
    })
    this.toastr.success('Current Account deleted!', 'Success');
  }

  ngOnDestroy(): void {
  }
}
