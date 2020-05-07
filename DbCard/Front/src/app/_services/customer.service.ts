import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../_models/customer';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCustomer(id: number): Observable<Customer>{
    return this.http.get<Customer>(this.baseUrl + 'customers/' + id);
  }
  editCustomer(customer: Customer): Observable<Customer>{
    return this.http.put<Customer>(this.baseUrl + 'customers/' + customer.Id, customer);
  }
  createCustomer(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.baseUrl + 'customers/', customer);
  }
}
