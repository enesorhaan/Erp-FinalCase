import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DefaultLayoutComponent } from './containers';
import { LoginComponent } from './views/pages/login/login.component';
import { AuthGuardService } from './services/authguard.service';  

const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  },
  {
    path: '',
    component: DefaultLayoutComponent,
    data: {
      title: 'Home'
    },
    children: [
      {
        path: 'dashboard',
        canActivate: [AuthGuardService],
        loadChildren: () =>
          import('./views/dashboard/dashboard.module').then((m) => m.DashboardModule)
      },
      {
        path: 'dealer',
        canActivate: [AuthGuardService],
        
        loadChildren: () =>
          import('./views/dealers/dealers.module').then((m) => m.DealersModule)
      },
      {
        path: 'currentaccount',
        canActivate: [AuthGuardService],
        loadChildren: () =>
          import('./views/currentaccounts/currentaccounts.module').then((m) => m.CurrentaccountsModule)
      },
      {
        path: 'product',
        canActivate: [AuthGuardService],
        loadChildren: () =>
          import('./views/products/products.module').then((m) => m.ProductsModule)
      },
      {
        path: 'expense',
        canActivate: [AuthGuardService],
        loadChildren: () =>
          import('./views/expenses/expenses.module').then((m) => m.ExpensesModule)
      },
      {
        path: 'message',
        canActivate: [AuthGuardService],
        loadChildren: () =>
          import('./views/messages/messages.module').then((m) => m.MessagesModule)
      },
      {
        path: 'orderitem',
        canActivate: [AuthGuardService],
        loadChildren: () =>
          import('./views/orderitems/orderitems.module').then((m) => m.OrderitemsModule)
      },
      {
        path: 'order',
        canActivate: [AuthGuardService],
        loadChildren: () =>
          import('./views/orders/orders.module').then((m) => m.OrdersModule)
      },
      {
        path: 'report',
        canActivate: [AuthGuardService],
        loadChildren: () =>
          import('./views/reports/reports.module').then((m) => m.ReportsModule)
      },
      {
        path: 'pages',
        loadChildren: () =>
          import('./views/pages/pages.module').then((m) => m.PagesModule)
      },
    ]
  },
  {
    path: 'login',
    component: LoginComponent,
    data: {
      title: 'Login Page'
    }
  },
  {path: '**', redirectTo: 'dashboard'}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      scrollPositionRestoration: 'top',
      anchorScrolling: 'enabled',
      initialNavigation: 'enabledBlocking'
      // relativeLinkResolution: 'legacy'
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
