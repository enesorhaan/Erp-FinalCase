import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
    private route: ActivatedRoute  
  ) { }

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.currentAccountService.get().subscribe(  (data:any) => {
      this.currentAccount = data.response;
      console.log(this.currentAccount);
    })
  }

  isDelete(dealerId:number){
    this.currentAccountService.delete(dealerId).subscribe({
      next: data => {
        console.log(data);
        this.router.navigate(['/currentaccount/list']);
      },
      error: error => {
        console.log(error, "Error");
      }
    })
    console.log("Delete");
  }

  ngOnDestroy(): void {
    console.log("Destroy");
  }
}
