import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PartnerComponent } from './partner/partner.component';

import { StatisticComponent } from './statistic/statistic.component';


const partnerRoutes: Routes = [
    {
      path: '',
      component: PartnerComponent,
      children: [
        {
          path: '',
          children: [
            { path: 'home', component: StatisticComponent},
            { path: '', redirectTo: '/partner/home', pathMatch: 'full'}
          ]
        }
      ]
    }
  ];

@NgModule({
    declarations: [],
    imports: [
      RouterModule.forChild(partnerRoutes)
    ],
    exports: [RouterModule]
  })
  export class PartnerRoutingModule { }
