import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListadminComponent } from './listadmin/listadmin.component';
import { ListdealerComponent } from './listdealer/listdealer.component';
import { AddadminComponent } from './addadmin/addadmin.component';
import { AdddealerComponent } from './adddealer/adddealer.component';
import { EditComponent } from './edit/edit.component';

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
    path: 'add/admin',
    component: AddadminComponent,
    data: {
      title: 'Add Message'
    }
  },
  {
    path: 'add/dealer',
    component: AdddealerComponent,
    data: {
      title: 'Add Message'
    }
  },
  {
    path: 'edit/:id',
    component: EditComponent,
    data: {
      title: 'Edit Message'
    }
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MessagesRoutingModule {
}
