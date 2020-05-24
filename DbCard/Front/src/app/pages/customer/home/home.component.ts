import { Component, OnDestroy, OnInit } from '@angular/core';

import { MyDiscount } from '../../../_models/discounts/myDiscount';
import { DiscountService } from '../../../_services/discount.service';
import { MatDialog } from '@angular/material/dialog';

import { BarcodeDialogComponent } from './barcodeDialog/barcodeDialog.component';
import { CustomerDataService } from 'src/app/_services/customerData.service';
import { Subscription } from 'rxjs';
import { ScrollRequest } from 'src/app/_models/scrollPaginate/scroll';


@Component({
  selector: 'app-customer-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnDestroy, OnInit {
  myDiscounts: MyDiscount[] = [];
  pageSize = 6;
  pageIndex = 0;
  customerGuid: string;
  subscription: Subscription;
  constructor(
    private discountService: DiscountService,
    public dialog: MatDialog,
    customerData: CustomerDataService
  ) {
    this.subscription = customerData.customer$.subscribe(customer => this.customerGuid = customer?.barcode);
  }

  ngOnInit() {
    this.loadMyDiscounts();
  }

  openDialog() {
    this.dialog.open(BarcodeDialogComponent, { data: this.customerGuid });
  }
  loadMyDiscounts() {
    const scrollRequest = new ScrollRequest(this.pageIndex, this.pageSize);
    this.discountService.getMyDiscountsScrollPaged(scrollRequest)
      .subscribe((pagedDiscounts: MyDiscount[]) => {
        if (pagedDiscounts) {
          this.addItems(pagedDiscounts);
        }
      });
  }
  addItems(discounts: MyDiscount[]) {
    discounts.forEach(element => {
      this.myDiscounts.push(element);
    });
  }
  onScroll() {
    this.pageIndex++;
    this.loadMyDiscounts();
  }
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
