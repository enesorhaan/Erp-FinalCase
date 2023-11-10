import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { CurrentaccountsService } from 'src/app/services/currentaccounts.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DealerService } from 'src/app/services/dealer.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {
  currentAccountId!:number;

  currentAccountForm = new FormGroup({
    creditLimit: new FormControl('')
  })

  dealer:any[] = []

  constructor(
    private currentAccountService: CurrentaccountsService,
    private dealerService: DealerService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id !== null) {
        this.currentAccountId = +id;
        this.load();
    }
  }

  load(){
    this.currentAccountService.getById(this.currentAccountId).subscribe((data:any) => {
      this.currentAccountForm.controls['creditLimit'].setValue(data.response.creditLimit);
    })
  }

  onSubmit(){
    this.currentAccountService.update(this.currentAccountId ,this.currentAccountForm.value).subscribe({
      next: data => {
        this.router.navigate(['/currentaccount/list']);
      },
      error: error => {
        this.toastr.error(error.error.message, "Error");
      }
    })
  }

}
