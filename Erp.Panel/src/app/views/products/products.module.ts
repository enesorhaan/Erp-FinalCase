import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsRoutingModule } from './products-routing.module';
import { AddComponent } from './add/add.component';
import { ListComponent } from './list/list.component';
import { EditComponent } from './edit/edit.component';
import { ButtonModule, CardModule, FormModule, TableModule } from '@coreui/angular';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AddComponent,
    ListComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    CardModule,
    TableModule,
    ButtonModule,
    FormModule,
    HttpClientModule,
    ReactiveFormsModule
  ]
})
export class ProductsModule { }
