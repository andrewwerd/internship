import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './pages/login/login.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import { NotFoundPageComponent } from './pages/NotFoundPage/notFoundPage.component';
import { AuthGuard } from './_guards/auth.guard';
import { Role } from './_models/account/role';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'registration',
    component: RegistrationComponent
  },
  {
    path: 'customer',
    loadChildren: () => import('./pages/customer/customer.module').then(mod => mod.CustomerModule),
    canActivate: [AuthGuard],
    data: { role: Role.Customer}
  },
  {
    path: 'partner',
    loadChildren: () => import('./pages/partner/partner.module').then(mod => mod.PartnerModule),
    canActivate: [AuthGuard],
    data: {role: Role.Partner}
  },
  {
    path: 'admin',
    loadChildren: () => import('./pages/admin/admin.module').then(mod => mod.AdminModule),
    canActivate: [AuthGuard],
    data: {role: Role.Admin}
  },
  {
    path: '',
    redirectTo: `/login`,
    pathMatch: 'full',
  },
  {
    path: '**',
    component: NotFoundPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
