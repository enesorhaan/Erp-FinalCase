import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListorderbyidComponent } from './listorderbyid/listorderbyid.component';
import { ListorderComponent } from './listorder/listorder.component';
import { ListproductComponent } from './listproduct/listproduct.component';
import { ListorderdealerComponent } from './listorderdealer/listorderdealer.component';
import { ReportsRoutingModule } from './reports-routing.module';
import { ButtonModule, CardModule, FormModule, TableModule } from '@coreui/angular';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IconModule } from '@coreui/icons-angular';



@NgModule({
  declarations: [
    ListorderbyidComponent,
    ListorderComponent,
    ListproductComponent,
    ListorderdealerComponent
  ],
  imports: [
    CommonModule,
    ReportsRoutingModule,
    CardModule,
    TableModule,
    ButtonModule,
    FormModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    IconModule
  ]
})
export class ReportsModule { }
