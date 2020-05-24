import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../_models/customer/customer';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { CustomerForRegistration } from '../_models/customer/customerForRegistration';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  baseUrl = environment.apiUrl + 'customer/';

  constructor(private http: HttpClient) { }

  getCustomer(): Observable<Customer>{
    return this.http.get<Customer>(this.baseUrl + 'currentCustomer');
  }
  editCustomer(customer: Customer): Observable<Customer>{
    return this.http.put<Customer>(this.baseUrl, customer);
  }
  createCustomer(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.baseUrl, customer);
  }
}
