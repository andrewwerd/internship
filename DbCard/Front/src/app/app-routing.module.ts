import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './Login/Login.component';
import { NotFoundPageComponent } from './shared/NotFoundPage/notFoundPage.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'customer', loadChildren: () => import('./Customer/customer.module').then(mod => mod.CustomerModule)},
  { path: '', redirectTo: '/customer/home', pathMatch: 'full' },
  { path: '**', component: NotFoundPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
