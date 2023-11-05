import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit, OnDestroy {
  product:any[] = []
  
  constructor(
    private productService: ProductService,
    private router: Router,
    private route: ActivatedRoute  
  ) { }

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.productService.get().subscribe(  (data:any) => {
      this.product = data.response;
      console.log(this.product);
    })
  }

  isDelete(productId:number){
    this.productService.delete(productId).subscribe({
      next: data => {
        console.log(data);
        this.router.navigate(['/product/list']);
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
