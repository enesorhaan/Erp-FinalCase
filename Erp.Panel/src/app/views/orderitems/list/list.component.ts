import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderitemService } from 'src/app/services/orderitem.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit, OnDestroy {
  orderItem:any[] = []
  
  constructor(
    private orderItemService: OrderitemService,
    private router: Router,
    private route: ActivatedRoute  
  ) { }

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.orderItemService.get().subscribe(  (data:any) => {
      this.orderItem = data.response;
      console.log(this.orderItem);
    })
  }

  isDelete(orderItemId:number){
    this.orderItemService.delete(orderItemId).subscribe({
      next: data => {
        console.log(data);
        this.router.navigate(['/orderitem/list']);
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
