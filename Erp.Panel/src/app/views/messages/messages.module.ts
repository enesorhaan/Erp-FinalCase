import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListadminComponent } from './listadmin/listadmin.component';
import { ListdealerComponent } from './listdealer/listdealer.component';
import { AddadminComponent } from './addadmin/addadmin.component';
import { AdddealerComponent } from './adddealer/adddealer.component';
import { EditComponent } from './edit/edit.component';
import { MessagesRoutingModule } from './messages-routing.module';
import { ButtonModule, CardModule, FormModule, GridModule, ListGroupModule, SharedModule, TableModule } from '@coreui/angular';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    ListadminComponent,
    ListdealerComponent,
    AddadminComponent,
    AdddealerComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    MessagesRoutingModule,
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
export class MessagesModule { }
