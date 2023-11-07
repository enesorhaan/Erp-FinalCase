import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ExpenseService } from 'src/app/services/expense.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent {

  expenseForm = new FormGroup({
    description: new FormControl(''),
    amount: new FormControl(''),
    expenseDate: new FormControl(''),
  })

  constructor(
    private expenseService: ExpenseService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  onSubmit(){
    this.expenseService.add(this.expenseForm.value).subscribe({
      next: data => {
        console.log(data);
        this.router.navigate(['/expense/list']);
      },
      error: error => {
        console.log(error, "Error");
        this.toastr.error('Invalid informations!', 'Error');
      }
    })
  }

}
