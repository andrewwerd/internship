import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Partner } from '../_models/partners/partner';
import { Observable } from 'rxjs';
import { Category } from '../_models/category';
import { ScrollRequest } from '../_models/scrollPaginate/scroll';
import { PartnerGridRow } from '../_models/partners/partnerGridRow';
import { Filial } from '../_models/filial/filial';
import { News } from '../_models/news/news';

@Injectable({
  providedIn: 'root'
})

export class PartnerService {
  baseUrl = environment.apiUrl + 'partners/';
  constructor(
    private http: HttpClient
  ) { }

  getPartnersPaged(scrollRequest: ScrollRequest): Observable<PartnerGridRow[]> {
    return this.http.post<PartnerGridRow[]>(this.baseUrl + 'getPagedPartners', scrollRequest);
  }
  getPartner(id: number): Observable<Partner> {
    return this.http.get<Partner>(this.baseUrl + id);
  }
  loadFilials(id: number): Observable<Filial[]> {
    return this.http.get<Filial[]>(this.baseUrl + 'getFilials/' + id);
  }
  loadNews(id: number): Observable<News[]> {
    return this.http.get<News[]>(this.baseUrl + 'getNews/' + id);
  }
  deletePartner(id: number) {
    return this.http.delete(this.baseUrl);
  }
}
