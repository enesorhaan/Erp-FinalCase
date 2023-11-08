import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListorderComponent } from './listorder/listorder.component';
import { ListorderdealerComponent } from './listorderdealer/listorderdealer.component';
import { ListorderbyidComponent } from './listorderbyid/listorderbyid.component';
import { ListproductComponent } from './listproduct/listproduct.component';

const routes: Routes = [
  {
    path: 'list/order/admin',
    component: ListorderComponent,
    data: {
      title: 'Report Order Admin'
    }
  }, 
  {
    path: 'list/order/dealer',
    component: ListorderdealerComponent,
    data: {
      title: 'Report Order'
    }
  }, 
  {
    path: 'list/orderbyid',
    component: ListorderbyidComponent,
    data: {
      title: 'Report Order By Id'
    }
  },
  {
    path: 'list/product',
    component: ListproductComponent,
    data: {
      title: 'Report Product'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReportsRoutingModule {
}
