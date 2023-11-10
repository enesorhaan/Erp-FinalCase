import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DealerService } from 'src/app/services/dealer.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent {

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
    private toastr: ToastrService
  ) { }

  onSubmit(){
    this.dealerService.add(this.dealerForm.value).subscribe({
      next: data => {
        this.router.navigate(['/dealer/list']);
      },
      error: error => {
        this.toastr.error('Invalid informations!', 'Error');
      }
    })
  }

}
