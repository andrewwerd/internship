import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


import { environment } from '../../environments/environment';
import { Transaction } from '../_models/transaction/transactions';
import { PaginatedRequest } from '../_models/tablePaginate/paginatedRequest';
import { PagedResult } from '../_models/tablePaginate/pagedResult';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  private baseUrl = environment.apiUrl + 'transactions/';
  constructor(
    private http: HttpClient
  ) { }

  getTransactionsPaged(paginatedRequest: PaginatedRequest): Observable<PagedResult<Transaction>> {
    return this.http.post<PagedResult<Transaction>>(this.baseUrl + 'paginatedSearch', paginatedRequest);
  }
  deleteTransaction(id: number) {
    return this.http.delete(this.baseUrl + id);
  }
}
