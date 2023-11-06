import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddComponent } from './add/add.component';
import { ListComponent } from './list/list.component';
import { EditComponent } from './edit/edit.component';
import { CurrentAccountsRoutingModule } from './currentaccounts-routing.module';


@NgModule({
  declarations: [
    AddComponent,
    ListComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    CurrentAccountsRoutingModule
  ]
})
export class CurrentaccountsModule { }
