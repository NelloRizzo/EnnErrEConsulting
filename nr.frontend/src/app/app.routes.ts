import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AdminComponent } from './components/admin/admin.component';
import { CustomersComponent } from './components/customers/customers.component';

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'admin/customers', component: CustomersComponent },
  { path: '**', pathMatch: 'full', redirectTo: '/home' }
];
