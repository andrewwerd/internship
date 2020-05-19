import { Component, OnInit } from '@angular/core';
import { Customer } from '../../../_models/customer/customer';
import { CustomerService } from '../../../_services/customer.service';
import { AccountService } from 'src/app/_services/account.service';
import { CustomerDataService } from 'src/app/_services/customerData.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
})
export class CustomerComponent implements  OnInit {
  customer: Customer;
  constructor(private accountService: AccountService,
              private customerService: CustomerService,
              private customerData: CustomerDataService) {
  }
  ngOnInit(){
    this.loadCustomer();
  }
  logout() {
    this.accountService.logout();
  }
  // hasAvatar(): boolean{
  //   return this.customer.Avatar != null;
  // }
  loadCustomer() {
    this.customerService.getCustomer().subscribe((customer: Customer) => {
      this.customer = customer;
      this.customerData.setData(this.customer);
    });
  }
}
