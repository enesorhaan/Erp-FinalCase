import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ExpenseService } from 'src/app/services/expense.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {
  expenseId!:number;
  expenseForm = new FormGroup({
    description: new FormControl(''),
    amount: new FormControl(''),
    expenseDate: new FormControl(''),
  })

  constructor(
    private expenseService: ExpenseService,
    private router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id !== null) {
        this.expenseId = +id;
        this.load();
    }
  }

  load(){
    this.expenseService.getById(this.expenseId).subscribe((data:any) => {
      this.expenseForm.controls['description'].setValue(data.response.description);
      this.expenseForm.controls['amount'].setValue(data.response.amount);
      this.expenseForm.controls['expenseDate'].setValue(data.response.expenseDate);
    })
  }

  onSubmit(){
    this.expenseService.update(this.expenseId ,this.expenseForm.value).subscribe({
      next: data => {
        this.toastr.success('Expense updated!', 'Success');
        this.router.navigate(['/expense/list']);
      },
      error: error => {
        this.toastr.error('Invalid informations!', 'Error');
      }
    })
  }

}
