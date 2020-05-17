import { Component, OnInit } from '@angular/core';
import { Balance } from '../../../_models/discounts/balance';

@Component({
  selector: 'app-balances-list',
  templateUrl: './balancesList.component.html',
  styleUrls: ['./balancesList.component.css']
})
export class BalancesListComponent implements OnInit {
  Balances: Balance[] = [{
    id: 3,
    partnerLogo: null,
    partnerId: 3,
    partnerName: 'Darwin',
    discountPercent: 1,
    accumulationPercent: 2,
    currentAmount: 100,
    nextAmount: 1000,
    discounts: [{
      amount: 1001,
      discountPercent: 2,
      accumulatingPercent: 1
    },
    {
      amount: 1500,
      discountPercent: 5,
      accumulatingPercent: 3
    },
    {
      amount: 2000,
      discountPercent: 10,
      accumulatingPercent: 5
    }
    ],
    partnerCategory: 'Магазин',
    partnerSubcategory: 'Электроника',
    isPremium: true
  },
  {
    id: 4,
    partnerLogo: null,
    partnerId: 4,
    partnerName: 'Enter',
    discountPercent: 1,
    currentAmount: 100,
    nextAmount: 500,
    discounts: [{
      amount: 1000,
      discountPercent: 2
    },
    {
      amount: 1500,
      discountPercent: 5
    },
    {
      amount: 2000,
      discountPercent: 10
    }
    ],
    partnerCategory: 'Магазин',
    partnerSubcategory: 'Электроника',
    resetDate: new Date(2020, 12, 31),
    isPremium: false
  }];
  constructor() { }

  ngOnInit(): void { }
  OnScroll() { }
  getAll() { }
  getPremium() { }
  getStandart() { }
  progress(): number {
    return 40;
  }
}
