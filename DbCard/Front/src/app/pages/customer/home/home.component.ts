import { Component, Input, AfterViewInit, OnInit, OnDestroy } from '@angular/core';

import { MyDiscount } from '../../../_models/discounts/myDiscount';
import { DiscountService } from '../../../_services/discount.service';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';

import { BarcodeDialogComponent } from './barcode-dialog';
import { CustomerDataService } from 'src/app/_services/customerData.service';
import { Subscription } from 'rxjs';


@Component({
    selector: 'app-customer-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {
    myDiscounts: MyDiscount[] = [{
      Id: 1,
      PartnerId : 1,
      PartnerName : '№1',
      Logo : null,
      DiscountPercent : 1,
      AccumulationPercent : 2
    },
    {
      Id: 2,
      PartnerId : 2,
      PartnerName : 'Enter',
      Logo : null,
      DiscountPercent : 1,
      AccumulationPercent : 2
    },
    {
      Id: 3,
      PartnerId : 3,
      PartnerName : 'Darwin',
      Logo : null,
      DiscountPercent : 1,
      AccumulationPercent : 2
    },
    {
      Id: 4,
      PartnerId : 4,
      PartnerName : 'Frizerie',
      Logo : null,
      DiscountPercent : 1,
      AccumulationPercent : 2
    }];

    page = 0;
    customerGuid: string;
    subscription: Subscription;
    constructor(
                private discountService: DiscountService,
                public dialog: MatDialog,
                customerData: CustomerDataService
              )
              {
                this.subscription = customerData.customer$.subscribe(customer => this.customerGuid = customer.barcode);
              }

  ngOnInit(){
    this.loadMyDiscountsFromApi();
  }

  openDialog() {
    this.dialog.open(BarcodeDialogComponent, { data: this.customerGuid});
  }
  loadMyDiscountsFromApi() {
      this.discountService.getMyDiscountsScrolled(this.page).subscribe((myDiscounts: MyDiscount[]) => {this.myDiscounts = myDiscounts; });
  }
  hasLogo(discount: MyDiscount): boolean {
    return discount.Logo != null;
  }
  OnScroll(){
    this.page++;
    this.loadMyDiscountsFromApi();
  }
  ngOnDestroy(){
    this.subscription.unsubscribe();
  }
}
