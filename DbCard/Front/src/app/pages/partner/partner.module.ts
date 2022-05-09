import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatisticComponent } from './statistic/statistic.component';
import { PartnerComponent } from './partner/partner.component';

import { PartnerRoutingModule } from './partner.routing';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { NgChartsModule } from 'ng2-charts';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { IncrementComponent } from './statistic/increment/increment.component';

@NgModule({
  imports: [
    CommonModule,
    PartnerRoutingModule,
    MatToolbarModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    MatSidenavModule,
    MatListModule,
    MatGridListModule,
    NgChartsModule,
    MatProgressSpinnerModule],
  exports: [],
  providers: [],
  declarations: [
    IncrementComponent,
    StatisticComponent,
    PartnerComponent,
  ],
})
export class PartnerModule { }
