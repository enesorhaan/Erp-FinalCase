import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductService } from 'src/app/services/product.service';
import { StorageService } from 'src/app/services/storage.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit, OnDestroy {
  product:any[] = []
  
  constructor(
    private productService: ProductService,
    private storageService: StorageService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute  
  ) { }

  ngOnInit(): void {
    this.load();
  }

  isAdmin(): boolean{
    return this.storageService.isAdmin();
  }

  load(){
    this.productService.get().subscribe(  (data:any) => {
      this.product = data.response;
      if(this.product == null ){
        this.toastr.warning('Product is empty. Please Add Product!', 'Warning');
        this.router.navigate(['/product/add']);
      }
    })
  }

  isDelete(productId:number){
    this.productService.delete(productId).subscribe({
      next: data => {
        this.toastr.success('Product deleted!', 'Success');
        this.load();
        this.router.navigate(['/product/list']);
      },
      error: error => {
        this.toastr.error(error.error.message, "Error");
      }
    })
  }

  ngOnDestroy(): void {
  }
}
