import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersRoutingModule } from './orders-routing.module';
import { ListadminComponent } from './listadmin/listadmin.component';
import { ListdealerComponent } from './listdealer/listdealer.component';
import { AddComponent } from './add/add.component';
import { EditadminComponent } from './editadmin/editadmin.component';
import { EditdealerComponent } from './editdealer/editdealer.component';
import { AccordionModule, ButtonModule, CardModule, FormModule, GridModule, ListGroupModule, SharedModule, TableModule } from '@coreui/angular';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    ListadminComponent,
    ListdealerComponent,
    AddComponent,
    EditadminComponent,
    EditdealerComponent
  ],
  imports: [
    CommonModule,
    OrdersRoutingModule,
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
    GridModule,
    AccordionModule
  ]
})
export class OrdersModule { }
