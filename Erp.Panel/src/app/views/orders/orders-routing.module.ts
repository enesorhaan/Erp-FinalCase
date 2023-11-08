import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListadminComponent } from './listadmin/listadmin.component';
import { ListdealerComponent } from './listdealer/listdealer.component';
import { AddComponent } from './add/add.component';
import { EditadminComponent } from './editadmin/editadmin.component';
import { EditdealerComponent } from './editdealer/editdealer.component';

const routes: Routes = [
  {
    path: 'list/admin',
    component: ListadminComponent,
    data: {
      title: 'Message List'
    }
  },
  {
    path: 'list/dealer',
    component: ListdealerComponent,
    data: {
      title: 'Message List'
    }
  },
  {
    path: 'add',
    component: AddComponent,
    data: {
      title: 'Add Message'
    }
  },
  {
    path: 'edit/admin/:id',
    component: EditadminComponent,
    data: {
      title: 'Edit Message'
    }
  },
  {
    path: 'edit/dealer/:id',
    component: EditdealerComponent,
    data: {
      title: 'Edit Message'
    }
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrdersRoutingModule {
}
