import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddComponent } from './add/add.component';
import { ListComponent } from './list/list.component';
import { EditComponent } from './edit/edit.component';
import { DealersRoutingModule } from './dealers-routing.module';


@NgModule({
  declarations: [
    AddComponent,
    ListComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    DealersRoutingModule
  ]
})
export class DealersModule { }
