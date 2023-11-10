import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { OrderitemService } from 'src/app/services/orderitem.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit  {
  orderItemId!:number;
  orderItemForm = new FormGroup({
    quantity: new FormControl(''),
  })

  constructor(
    private orderItemService: OrderitemService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id !== null) {
        this.orderItemId = +id;
        this.load();
    }
  }

  load(){
    this.orderItemService.getById(this.orderItemId).subscribe((data:any) => {
      this.orderItemForm.controls['quantity'].setValue(data.response.quantity);
    })
  }

  onSubmit(){
    this.orderItemService.update(this.orderItemId ,this.orderItemForm.value).subscribe({
      next: data => {
        if(data.success === false){
          this.toastr.error(data.message, 'Error');
          return;
        }
        this.router.navigate(['/orderitem/list']);
      },
      error: error => {
        this.toastr.error('Invalid informations!', 'Error');
      }
    })
  }
}
