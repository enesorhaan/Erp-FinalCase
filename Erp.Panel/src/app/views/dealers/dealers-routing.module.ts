import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './list/list.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';

const routes: Routes = [
  {
    path: 'list',
    component: ListComponent,
    data: {
      title: 'Dealer List'
    }
  },
  {
    path: 'add',
    component: AddComponent,
    data: {
      title: 'Add Dealer'
    }
  },
  {
    path: 'edit/:id',
    component: EditComponent,
    data: {
      title: 'Edit Dealer'
    }
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DealersRoutingModule {
}
