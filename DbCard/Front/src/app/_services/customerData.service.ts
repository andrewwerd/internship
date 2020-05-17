import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Customer } from '../_models/customer';

@Injectable()
export class CustomerDataService {
  private customerSource = new Subject<Customer>();

  customer$ = this.customerSource.asObservable();

  setData(data: Customer) {
    this.customerSource.next(data);
  }
}
