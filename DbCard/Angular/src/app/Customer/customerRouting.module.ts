import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CustomerComponent} from './customer/customer.component';
import { HomeComponent } from './home/home.component';
import { PartnerListComponent } from './partnerList/partnerList.component';
import { PartnerPageComponent } from './partnerPage/partnerPage.component';
import { AccountListComponent } from './accountList/accountList.component';
import { NewsListComponent } from './newsList/newsList.component';
import { NewsPageComponent } from './newsPage/newsPage.component';
import { StatisticComponent } from './statistic/statistic.component';
import { AuthGuard } from '../_guards/auth.guard';


const customerRoutes: Routes = [
    {
      path: '',
      component: CustomerComponent,
      children: [
        {
          path: '',
          children: [
            { path: 'home', component: HomeComponent },
            { path: 'partners', component: PartnerListComponent },
            { path: 'partner/:id', component: PartnerPageComponent },
            { path: 'accounts', component: AccountListComponent},
            { path: 'news', component: NewsListComponent},
            { path: 'news/:id', component: NewsPageComponent},
            { path: 'statistic', component: StatisticComponent},
            { path: '', redirectTo: '/customer/home', pathMatch: 'full'}
          ]
        }
      ]
    }
  ];

@NgModule({
    declarations: [],
    imports: [
      RouterModule.forChild(customerRoutes)
    ],
    exports: [RouterModule]
  })
  export class CustomerRoutingModule { }
