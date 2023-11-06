import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { DealerService } from '../../../services/dealer.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {
  dealerId!:number;
  dealerForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
    dealerName: new FormControl(''),
    address: new FormControl(''),
    billingAddress: new FormControl(''),
    taxOffice: new FormControl(''),
    taxNumber: new FormControl(''),
    marginPercentage: new FormControl('')
  })

  constructor(
    private dealerService: DealerService,
    private router: Router,
    private route: ActivatedRoute
  ) { }
  
  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id !== null) {
        this.dealerId = +id;
        this.load();
    }
  }

  load(){
    this.dealerService.getById(this.dealerId).subscribe((data:any) => {
      console.log(data.response);
      this.dealerForm.controls['email'].setValue(data.response.email);
      this.dealerForm.controls['password'].setValue(data.response.password);
      this.dealerForm.controls['dealerName'].setValue(data.response.dealerName);
      this.dealerForm.controls['address'].setValue(data.response.address);
      this.dealerForm.controls['billingAddress'].setValue(data.response.billingAddress);
      this.dealerForm.controls['taxOffice'].setValue(data.response.taxOffice);
      this.dealerForm.controls['taxNumber'].setValue(data.response.taxNumber);
      this.dealerForm.controls['marginPercentage'].setValue(data.response.marginPercentage);
    })
  }

  onSubmit(){
    this.dealerService.update(this.dealerId ,this.dealerForm.value).subscribe({
      next: data => {
        console.log(data);
        this.router.navigate(['/dealer/list']);
      },
      error: error => {
        console.log(error, "Error");
      }
    })
  }

}
