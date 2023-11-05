import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ProductService } from '../../../services/product.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {
  productId!:number;
  productForm = new FormGroup({
    productName: new FormControl(''),
    productPrice: new FormControl(''),
    productStock: new FormControl('')
  })

  constructor(
    private productService: ProductService,
    private router: Router,
    private route: ActivatedRoute
  ) { }
  
  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id !== null) {
        this.productId = +id;
        this.load();
    }
  }

  load(){
    this.productService.getById(this.productId).subscribe((data:any) => {
      console.log(data.response);
      this.productForm.controls['productName'].setValue(data.response.productName);
      this.productForm.controls['productPrice'].setValue(data.response.productPrice);
      this.productForm.controls['productStock'].setValue(data.response.productStock);
    })
  }

  onSubmit(){
    this.productService.update(this.productId ,this.productForm.value).subscribe({
      next: data => {
        console.log(data);
        this.router.navigate(['/product/list']);
      },
      error: error => {
        console.log(error, "Error");
      }
    })
  }
}
