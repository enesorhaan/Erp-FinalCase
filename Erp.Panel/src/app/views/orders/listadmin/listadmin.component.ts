import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { OrderService } from 'src/app/services/order.service';
@Component({
  selector: 'app-listadmin',
  templateUrl: './listadmin.component.html',
  styleUrls: ['./listadmin.component.scss']
})
export class ListadminComponent implements OnInit, OnDestroy {
  orderId!:number;
  order:any[] = []

  constructor(
    private orderService: OrderService,
    private router: Router,
    private route: ActivatedRoute ,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.load();
  }

  onFilterChange(){
    this.load();
  }

  load(){
    this.orderService.getAdmin().subscribe(  (data:any) => {
      this.order = data.response;
      console.log(this.order);
    })
  }

  isDelete(productId:number){
    this.orderService.delete(productId).subscribe({
      next: data => {
        console.log(data);
        this.router.navigate(['/order/list/admin']);
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
