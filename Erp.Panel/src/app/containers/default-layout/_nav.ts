import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    iconComponent: { name: 'cil-home' }
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
    ]
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
        name: 'Create Order',
        url: '/order/add'
      }
    ]
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
        name: 'Report Product',
        url: '/report/list/orderbyid'
      },
      {
        name: 'Create Order',
        url: '/report/list/product'
      }
    ]
  },
  {
    name: 'Components',
    title: true
  },
  {
    name: 'Base',
    url: '/base',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'Accordion',
        url: '/base/accordion'
      },
      {
        name: 'Breadcrumbs',
        url: '/base/breadcrumbs'
      },
      {
        name: 'Cards',
        url: '/base/cards'
      },
      {
        name: 'Carousel',
        url: '/base/carousel'
      },
      {
        name: 'Collapse',
        url: '/base/collapse'
      },
      {
        name: 'List Group',
        url: '/base/list-group'
      },
      {
        name: 'Navs & Tabs',
        url: '/base/navs'
      },
      {
        name: 'Pagination',
        url: '/base/pagination'
      },
      {
        name: 'Placeholder',
        url: '/base/placeholder'
      },
      {
        name: 'Popovers',
        url: '/base/popovers'
      },
      {
        name: 'Progress',
        url: '/base/progress'
      },
      {
        name: 'Spinners',
        url: '/base/spinners'
      },
      {
        name: 'Tables',
        url: '/base/tables'
      },
      {
        name: 'Tabs',
        url: '/base/tabs'
      },
      {
        name: 'Tooltips',
        url: '/base/tooltips'
      }
    ]
  },
  {
    name: 'Buttons',
    url: '/buttons',
    iconComponent: { name: 'cil-cursor' },
    children: [
      {
        name: 'Buttons',
        url: '/buttons/buttons'
      },
      {
        name: 'Button groups',
        url: '/buttons/button-groups'
      },
      {
        name: 'Dropdowns',
        url: '/buttons/dropdowns'
      }
    ]
  },
  {
    name: 'Forms',
    url: '/forms',
    iconComponent: { name: 'cil-notes' },
    children: [
      {
        name: 'Form Control',
        url: '/forms/form-control'
      },
      {
        name: 'Select',
        url: '/forms/select'
      },
      {
        name: 'Checks & Radios',
        url: '/forms/checks-radios'
      },
      {
        name: 'Range',
        url: '/forms/range'
      },
      {
        name: 'Input Group',
        url: '/forms/input-group'
      },
      {
        name: 'Floating Labels',
        url: '/forms/floating-labels'
      },
      {
        name: 'Layout',
        url: '/forms/layout'
      },
      {
        name: 'Validation',
        url: '/forms/validation'
      }
    ]
  },
  {
    name: 'Charts',
    url: '/charts',
    iconComponent: { name: 'cil-chart-pie' }
  },
  {
    name: 'Icons',
    iconComponent: { name: 'cil-star' },
    url: '/icons',
    children: [
      {
        name: 'CoreUI Free',
        url: '/icons/coreui-icons',
        badge: {
          color: 'success',
          text: 'FREE'
        }
      },
      {
        name: 'CoreUI Flags',
        url: '/icons/flags'
      },
      {
        name: 'CoreUI Brands',
        url: '/icons/brands'
      }
    ]
  },
  {
    name: 'Notifications',
    url: '/notifications',
    iconComponent: { name: 'cil-bell' },
    children: [
      {
        name: 'Alerts',
        url: '/notifications/alerts'
      },
      {
        name: 'Badges',
        url: '/notifications/badges'
      },
      {
        name: 'Modal',
        url: '/notifications/modal'
      },
      {
        name: 'Toast',
        url: '/notifications/toasts'
      }
    ]
  },
  {
    name: 'Widgets',
    url: '/widgets',
    iconComponent: { name: 'cil-calculator' },
    badge: {
      color: 'info',
      text: 'NEW'
    }
  }
];
