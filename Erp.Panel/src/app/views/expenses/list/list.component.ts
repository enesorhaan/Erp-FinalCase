import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ExpenseService } from 'src/app/services/expense.service';
import { ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit, OnDestroy {
  expense:any[] = []
  selectedValue: any;
  
  constructor(
    private expenseService: ExpenseService,
    private router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute  
  ) { }

  ngOnInit(): void {
    this.load();
  }

  onFilterChange(){
    this.load();
  }

  load(){
    this.expenseService.get().subscribe(  (data:any) => {
      if(this.selectedValue == 1){
        this.expense = data.response;
      }else if(this.selectedValue == 2){
        this.expense = data.response.filter((item:any) => item.isActive == true);
      }else if(this.selectedValue == 3){
        this.expense = data.response.filter((item:any) => item.isActive == false);
      }
    })
  }

  isDelete(productId:number){
    this.expenseService.delete(productId).subscribe({
      next: data => {
        this.toastr.success('Expense deleted!', 'Success');
        this.router.navigate(['/expense/list']);
      },
      error: error => {
        this.toastr.error(error.error.message, "Error");
      }
    })
  }

  ngOnDestroy(): void {
  }
}
