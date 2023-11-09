import { INavData } from '@coreui/angular';
import { StorageService } from 'src/app/services/storage.service';

const isAdmin = (storageService: StorageService) => storageService.isAdmin();

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    iconComponent: { name: 'cil-home' }
  },
  {
    name: 'Dealer',
    title: true
  },
  {
    name: 'Dealers',
    url: '/dealer',
    iconComponent: { name: 'cil-description' },
    children: [
      {
        name: 'Dealer List',
        url: '/dealer/list'
      },
      {
        name: 'Add Dealer',
        url: '/dealer/add'
      }
    ],
  },
  {
    name: 'Current Accounts',
    url: '/currentaccount',
    iconComponent: { name: 'cil-description' },
    children: [
      {
        name: 'Current Account List',
        url: '/currentaccount/list'
      },
      {
        name: 'Add Current Account',
        url: '/currentaccount/add'
      }
    ]
  },
  {
    name: 'Expense',
    title: true
  },
  {
    name: 'Expenses',
    url: '/expense',
    iconComponent: { name: 'cil-description' },
    children: [
      {
        name: 'Expense List',
        url: '/expense/list'
      },
      {
        name: 'Add Expense',
        url: '/expense/add'
      }
    ]
  },
  {
    name: 'Message',
    title: true
  },
  {
    name: 'Messages',
    url: '/message',
    iconComponent: { name: 'cil-description' },
    children: [
      {
        name: 'Admin Message List',
        url: '/message/list/admin'
      },
      {
        name: 'Message List',
        url: '/message/list/dealer'
      },
      {
        name: 'Add Admin Message',
        url: '/message/add/admin'
      },
      {
        name: 'Add Message',
        url: '/message/add/dealer'
      }
    ]
  },
  {
    name: 'Product-Order',
    title: true
  },
  {
    name: 'Products',
    url: '/product',
    iconComponent: { name: 'cil-description' },
    children: [
      {
        name: 'Product List',
        url: '/product/list'
      },
      {
        name: 'Add Product',
        url: '/product/add'
      }
    ]
  },
  {
    name: 'Order Items',
    url: '/orderitem',
    iconComponent: { name: 'cil-description' },
    children: [
      {
        name: 'Order Item List',
        url: '/orderitem/list'
      },
      {
        name: 'Add Order Item',
        url: '/orderitem/add'
      }
    ]
  },
  {
    name: 'Orders',
    url: '/order',
    iconComponent: { name: 'cil-description' },
    children: [
      {
        name: 'Admin Order List',
        url: '/order/list/admin'
      },
      {
        name: 'Order List',
        url: '/order/list/dealer'
      },
      {
        name: 'Order Payment',
        url: '/order/add'
      }
    ]
  },
  {
    name: 'Reports',
    title: true
  },
  {
    name: 'Reports',
    url: '/report',
    iconComponent: { name: 'cil-description' },
    children: [
      {
        name: 'Report Order Admin',
        url: '/report/list/order/admin'
      },
      {
        name: 'Report Order',
        url: '/report/list/order/dealer'
      },
      {
        name: 'Report Order By Id',
        url: '/report/list/orderbyid'
      },
      {
        name: 'Report Product',
        url: '/report/list/product'
      }
    ]
  }
];
