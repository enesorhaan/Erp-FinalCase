import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
    private route: ActivatedRoute  
  ) { }

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.dealerService.get().subscribe(  (data:any) => {
      this.dealer = data.response;
      console.log(this.dealer);
    })
  }

  isDelete(dealerId:number){
    this.dealerService.delete(dealerId).subscribe({
      next: data => {
        console.log(data);
        this.router.navigate(['/dealer/list']);
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
