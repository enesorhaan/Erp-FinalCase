import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ProductService } from '../../../services/product.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent {

  productForm = new FormGroup({
    productName: new FormControl(''),
    productPrice: new FormControl(''),
    productStock: new FormControl('')
  })

  constructor(
    private productService: ProductService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  onSubmit(){
    this.productService.add(this.productForm.value).subscribe({
      next: data => {
        console.log(data);
        this.router.navigate(['/product/list']);
      },
      error: error => {
        console.log(error, "Error");
        this.toastr.error('Invalid informations!', 'Error');
      }
    })
  }
}
