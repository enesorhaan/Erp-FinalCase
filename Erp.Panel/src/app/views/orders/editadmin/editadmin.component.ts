import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-editadmin',
  templateUrl: './editadmin.component.html',
  styleUrls: ['./editadmin.component.scss']
})
export class EditadminComponent implements OnInit {
  orderId!:number;
  orderStatus:number = 0;

  orderForm = new FormGroup({
    orderStatus: new FormControl<number>(2)
  })

  order:any[] = []

  constructor(
    private orderService: OrderService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id !== null) {
        this.orderId = +id;
        this.load();
    }
  }

  setOrderStatus(method: number) {
    this.orderForm.setValue({
      orderStatus: method
    });
    this.load();
  }

  load(){
    this.orderService.getById(this.orderId).subscribe((data:any) => {
      this.order = data.response;
      console.log(data.response);
      this.orderForm.controls['orderStatus'].setValue(data.response.orderStatus);
    })
  }

  onSubmit(){
    this.orderForm.setValue({
      orderStatus: this.orderStatus
    });

    this.orderService.updateAdmin(this.orderId ,this.orderForm.value).subscribe({
      next: data => {
        console.log(data);
        if(data.success === false){
          this.toastr.error(data.message, 'Error');
          return;
        }
        this.router.navigate(['/order/list/admin']);
      },
      error: error => {
        console.log(error, "Error");
      }
    })
  }
}
