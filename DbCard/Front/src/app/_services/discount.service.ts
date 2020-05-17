import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { MyDiscount } from '../_models/discounts/myDiscount';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DiscountService {

  baseUrl = environment.apiUrl;

  constructor(
    private http: HttpClient
  ) { }

  getMyDiscounts(): Observable<MyDiscount[]> {
    return this.http.get<MyDiscount[]>(this.baseUrl + 'MyDiscounts');
  }
  getMyDiscountsScrolled(page: number): Observable<MyDiscount[]> {
    return this.http.post<MyDiscount[]>(this.baseUrl + 'MyDiscounts', page);
  }
}

