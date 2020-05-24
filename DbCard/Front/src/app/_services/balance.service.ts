import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


import { environment } from '../../environments/environment';
import { Balance } from '../_models/discounts/balance';

@Injectable({
  providedIn: 'root'
})
export class BalanceService {

  private baseUrl = environment.apiUrl + 'balances/';
  constructor(
    private http: HttpClient
  ) { }

  getBalancesPaged(): Observable<Balance[]> {
    return this.http.get<Balance[]>(this.baseUrl);
  }

}
