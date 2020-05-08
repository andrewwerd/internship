import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './Login/Login.component';
import { RegistrationComponent } from './Registration/registration.component';
import { NotFoundPageComponent } from './shared/NotFoundPage/notFoundPage.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent},
  { path: 'customer', loadChildren: () => import('./Customer/customer.module').then(mod => mod.CustomerModule), canActivate: [AuthGuard]},
  { path: 'partner', loadChildren: () => import('./Partner/partner.module').then(mod => mod.PartnerModule), canActivate: [AuthGuard]},
  { path: 'admin', loadChildren: () => import('./Admin/admin.module').then(mod => mod.AdminModule), canActivate: [AuthGuard]},
  { path: '', redirectTo: '/home', pathMatch: 'full', canActivate: [AuthGuard]},
  { path: '**', component: NotFoundPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
