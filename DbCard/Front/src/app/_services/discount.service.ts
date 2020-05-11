import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { MyDiscount } from '../_models/Discounts/MyDiscount';
import { PremiumBalance } from '../_models/Discounts/PremiumBalance';
import { StandartBalance } from '../_models/Discounts/StandartBalance';
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
  getPremiumDiscounts(): Observable<PremiumBalance[]>{
    return this.http.get<PremiumBalance[]>(this.baseUrl + 'PremiumDiscounts');
  }
  getStandartDiscounts(): Observable<StandartBalance[]>{
    return this.http.get<StandartBalance[]>(this.baseUrl + 'StandartBalances');
  }
}
