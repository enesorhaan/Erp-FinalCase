import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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
    private toastr: ToastrService,
    private route: ActivatedRoute  
  ) { }

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.orderItemService.get().subscribe(  (data:any) => {
      this.orderItem = data.response;
      
      if(this.orderItem == null){
        this.router.navigate(['/orderitem/add']);
        this.toastr.warning('Basket is empty. Please Add Product!', 'Warning');
        return;
      }
    })
  }

  isDelete(orderItemId:number){
    this.orderItemService.delete(orderItemId).subscribe({
      next: data => {
        this.load();
        this.toastr.success('Product deleted!', 'Success');
        this.router.navigate(['/orderitem/list']);
      },
      error: error => {
        this.toastr.error(error.error.message, "Error");
      }
    })
  }

  ngOnDestroy(): void {
  }
}
