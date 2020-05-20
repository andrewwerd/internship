import { Component, OnInit, OnDestroy, AfterViewInit } from '@angular/core';

import { MyDiscount } from '../../../_models/discounts/myDiscount';
import { DiscountService } from '../../../_services/discount.service';
import { MatDialog } from '@angular/material/dialog';

import { BarcodeDialogComponent } from './barcodeDialog/barcodeDialog.component';
import { CustomerDataService } from 'src/app/_services/customerData.service';
import { Subscription } from 'rxjs';


@Component({
    selector: 'app-customer-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnDestroy, AfterViewInit {
    myDiscounts: MyDiscount[] = [{
      Id: 1,
      PartnerId : 1,
      PartnerName : '№1',
      DiscountPercent : 1,
      AccumulationPercent : 2
    },
    {
      Id: 2,
      PartnerId : 2,
      PartnerName : 'Enter',
      DiscountPercent : 1,
      AccumulationPercent : 2
    },
    {
      Id: 3,
      PartnerId : 3,
      PartnerName : 'Darwin',
      DiscountPercent : 1,
      AccumulationPercent : 2
    },
    {
      Id: 4,
      PartnerId : 4,
      PartnerName : 'Frizerie',

      DiscountPercent : 1,
      AccumulationPercent : 2
    }];

    page = 0;
    customerGuid: string;
    subscription: Subscription;
    constructor(
                private discountService: DiscountService,
                public dialog: MatDialog,
                private customerData: CustomerDataService
              )
              {
                this.subscription = customerData.customer$.subscribe(customer => this.customerGuid = customer?.barcode);
              }

  ngAfterViewInit() {
    this.loadMyDiscounts();
  }

  openDialog() {
    this.dialog.open(BarcodeDialogComponent, { data: this.customerGuid});
  }
  loadMyDiscounts() {
      this.discountService.getMyDiscounts(this.customerGuid).subscribe((myDiscounts: MyDiscount[]) => {this.myDiscounts = myDiscounts; });
  }
  OnScroll(){
    this.page++;
    this.loadMyDiscounts();
  }
  ngOnDestroy(){
    this.subscription.unsubscribe();
  }
}
