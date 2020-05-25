import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


import { environment } from '../../environments/environment';
import { Balance } from '../_models/discounts/balance';
import { ScrollRequest } from '../_models/scrollPaginate/scroll';

@Injectable({
  providedIn: 'root'
})
export class BalanceService {

  private baseUrl = environment.apiUrl + 'discounts/';
  constructor(
    private http: HttpClient
  ) { }

  getBalancesPaged(scrollRequest: ScrollRequest): Observable<Balance[]> {
    return this.http.post<Balance[]>(this.baseUrl + 'getBalancesPaged', scrollRequest);
  }

}
