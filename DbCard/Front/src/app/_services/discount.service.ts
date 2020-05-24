import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { MyDiscount } from '../_models/discounts/myDiscount';
import { Observable } from 'rxjs';
import { Customer } from '../_models/customer/customer';
import { PagedResult } from '../_models/tablePaginate/pagedResult';
import { PaginatedRequest } from '../_models/tablePaginate/paginatedRequest';
import { ScrollRequest } from '../_models/scrollPaginate/scroll';

@Injectable({
  providedIn: 'root'
})
export class DiscountService {

  baseUrl = environment.apiUrl + 'discounts/';

  constructor(
    private http: HttpClient
  ) { }

  getMyDiscountsScrollPaged(scrollRequest: ScrollRequest): Observable<MyDiscount[]> {
    return this.http.post<MyDiscount[]>(this.baseUrl + 'myDiscounts', scrollRequest);
  }
}



