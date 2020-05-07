import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { Customer } from '../../_models/customer';
import { CustomerService } from '../../_services/customer.service';

@Component({
    selector: 'app-customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit, AfterViewInit{
    customer: Customer = {
      Id: 1,
      FirstName: 'Андрей',
      LastName: 'Тырсына',
      Age: 20,
      UserId: 1,
      Gender: 'Male',
      PhoneNumber: '067729269',
      Avatar: null
    };
    constructor(private router: Router,
                private customerService: CustomerService){}
    ngOnInit(): void {
    }
    logout(): void {
        localStorage.removeItem('accessToken');
        this.router.navigate(['login']);
    }
    hasAvatar(): boolean{
      return this.customer.Avatar != null;
    }
    ngAfterViewInit(){}
    /* ngAfterViewInit()  {
      this.loadCustomerFromApi();
    }
    loadCustomerFromApi(){
        this.customerService.getCustomer().subscribe((customer: Customer) => {this.customer = customer; });
    } */
}
