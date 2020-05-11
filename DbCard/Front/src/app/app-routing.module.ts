import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './pages/login/Login.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import { NotFoundPageComponent } from './pages/NotFoundPage/notFoundPage.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent},
  // tslint:disable-next-line:max-line-length
  { path: 'customer', loadChildren: () => import('./pages/customer/customer.module').then(mod => mod.CustomerModule)},
  { path: 'partner', loadChildren: () => import('./pages/partner/partner.module').then(mod => mod.PartnerModule)},
  { path: 'admin', loadChildren: () => import('./pages/admin/admin.module').then(mod => mod.AdminModule)},
  { path: '', redirectTo: '/home', pathMatch: 'full'},
  { path: '**', component: NotFoundPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
