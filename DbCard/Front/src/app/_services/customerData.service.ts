import { Injectable } from '@angular/core';
import {  BehaviorSubject } from 'rxjs';
import { Customer } from '../_models/customer/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerDataService {
  private customerSource = new BehaviorSubject<Customer>(null);

  customer$ = this.customerSource.asObservable();

  setData(data: Customer) {
    this.customerSource.next(data);
  }
}
