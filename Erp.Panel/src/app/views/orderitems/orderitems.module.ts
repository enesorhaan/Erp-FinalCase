import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderItemsRoutingModule } from './orderitems-routing.module';
import { AddComponent } from './add/add.component';
import { ListComponent } from './list/list.component';
import { EditComponent } from './edit/edit.component';
import { ButtonModule, CardModule, FormModule, GridModule, ListGroupModule, SharedModule, TableModule } from '@coreui/angular';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    AddComponent,
    ListComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    OrderItemsRoutingModule,
    CardModule,
    TableModule,
    ButtonModule,
    FormModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    IconModule,
    SharedModule,
    ListGroupModule,
    GridModule
  ]
})
export class OrderitemsModule { }
