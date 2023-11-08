import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderService } from 'src/app/services/order.service';
import { OrderitemService } from 'src/app/services/orderitem.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr'

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent implements OnInit, OnDestroy {
  orderItem:any[] = []
  totalPrice:number = 0;

  orderForm = new FormGroup({
    paymentMethod: new FormControl('1'),
  })

  
  constructor(
    private orderService: OrderService,
    private orderItemService: OrderitemService,
    private router: Router,
    private toastr: ToastrService
  ) {
  }
  
  onSubmit(){
    this.orderService.add(this.orderForm.value).subscribe({
      next: data => {
        console.log(data);
        if(data.success === false){
          this.toastr.error(data.message, 'Error');
          return;
        }
        this.router.navigate(['/order/list/dealer']);
      },
      error: error => {
        console.log(this.orderForm.value);
        console.log(error, "Error");
        this.toastr.error('Invalid informations!', 'Error');
      }
    })
  }

  ngOnInit(): void {
    this.load();
  }

  setPaymentMethod(method: string) {
    this.orderForm.setValue({
      paymentMethod: method
    });
    this.load();
  }

  load(){
    this.orderItemService.get().subscribe(  (data:any) => {
      this.orderItem = data.response;
      console.log(this.orderItem);
      
      this.totalPrice = 0;
      this.orderItem.forEach((item: any) => {
        this.totalPrice += item.marginPrice;
      });

      console.log("Toplam Fiyat: " + this.totalPrice);
    })
  }

  ngOnDestroy(): void {
    console.log("Destroy");
  }
}
