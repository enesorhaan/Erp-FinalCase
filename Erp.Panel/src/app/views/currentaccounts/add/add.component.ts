import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CurrentaccountsService } from 'src/app/services/currentaccounts.service';
import { DealerService } from 'src/app/services/dealer.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent implements OnInit, OnDestroy {
  currentAccountForm = new FormGroup({
    dealerId: new FormControl(''),
    creditLimit: new FormControl('')
  })

  dealer:any[] = []

  constructor(
    private currentAccountService: CurrentaccountsService,
    private dealerService: DealerService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  onSubmit(){
    this.currentAccountService.add(this.currentAccountForm.value).subscribe({
      next: data => {
        this.router.navigate(['/currentaccount/list']);
      },
      error: error => {
        this.toastr.error('Invalid informations!', 'Error');
      }
    })
  }

  ngOnInit(): void {
    this.getDealer();
  }

  getDealer(){
    this.dealerService.get().subscribe(  (data:any) => {
      this.dealer = data.response;
    })
  }
  
  ngOnDestroy(): void {
  }
}
