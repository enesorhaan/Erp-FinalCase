import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit, OnDestroy {
  product:any[] = []
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.productService.get().subscribe(  (data:any) => {
      this.product = data.response;
      console.log(this.product);
    })
  }

  isDelete(){
    // this.productService.delete(1).subscribe({
    //   next: data => {
    //     console.log(data);
    //   },
    //   error: error => {
    //     console.log(error, "Error");
    //   }
    // })
    console.log("Delete");
  }

  ngOnDestroy(): void {
    console.log("Destroy");
  }
}
