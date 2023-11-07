import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { OrderitemService } from 'src/app/services/orderitem.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent implements OnInit, OnDestroy {
  orderItemForm = new FormGroup({
    productId: new FormControl(''),
    quantity: new FormControl(''),
  })

  product:any[] = []
  productPrice: any;

  constructor(
    private orderitemService: OrderitemService,
    private productService: ProductService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  onSubmit(){
    this.orderitemService.add(this.orderItemForm.value).subscribe({
      next: data => {
        console.log(data);
        if(data.success === false){
          this.toastr.error(data.message, 'Error');
          return;
        }
        this.router.navigate(['/orderitem/list']);
      },
      error: error => {
        console.log(error, "Error");
        this.toastr.error('Invalid informations!', 'Error');
      }
    })
  }

  ngOnInit(): void {
    this.getProduct();
    this.getPrice(this.orderItemForm.value.productId);
  }

  getProduct(){
    this.productService.get().subscribe(  (data:any) => {
      this.product = data.response;
      console.log(this.product);
    })
  }

  getPrice(productId:any){
    this.productService.getById(productId).subscribe(  (data:any) => {
      this.productPrice = data.response.productPrice;
      console.log(this.productPrice);
    })
  }
  
  ngOnDestroy(): void {
    console.log("Destroy");
  }
}
