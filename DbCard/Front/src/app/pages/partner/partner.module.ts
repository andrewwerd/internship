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
import { HomeComponent } from './home/home.component';
import { MatTableModule } from '@angular/material/table';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { FilialDialog } from './home/filial-dialog/filial-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule,
    PartnerRoutingModule,
    MatToolbarModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    MatSidenavModule,
    MatListModule,
    MatGridListModule,
    NgChartsModule,
    MatProgressSpinnerModule,
    MatTableModule,
    MatDialogModule
  ],
  exports: [],
  providers: [],
  declarations: [
    HomeComponent,
    FilialDialog,
    IncrementComponent,
    StatisticComponent,
    PartnerComponent,
  ],
})
export class PartnerModule { }
