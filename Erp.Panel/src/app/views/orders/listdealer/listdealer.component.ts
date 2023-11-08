import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-listdealer',
  templateUrl: './listdealer.component.html',
  styleUrls: ['./listdealer.component.scss']
})
export class ListdealerComponent implements OnInit, OnDestroy {
  orderId!:number;
  order:any[] = []

  cancelForm = new FormGroup({
    orderStatus: new FormControl<number>(4)
  })

  constructor(
    private orderService: OrderService,
    private router: Router,
    private route: ActivatedRoute ,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.orderService.getDealer().subscribe(  (data:any) => {
      this.order = data.response;
      console.log(this.order);
    })
  }

  isCancel(orderId:number){
    this.orderService.updateDealer(orderId ,this.cancelForm.value).subscribe({
      next: data => {
        console.log(data);
        if(data.success === false){
          this.toastr.error(data.message, 'Error');
          return;
        }
        this.router.navigate(['/list/dealer']);
      },
      error: error => {
        console.log(error, "Error");
        this.toastr.error('Invalid informations!', 'Error');
      }
    })
    console.log("Cancel");
  }

  ngOnDestroy(): void {
    console.log("Destroy");
  }

}
