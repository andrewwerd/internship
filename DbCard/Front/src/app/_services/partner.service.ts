import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Partner } from '../_models/partners/partner';
import { Observable } from 'rxjs';
import { Category } from '../_models/category';
import { ScrollRequest } from '../_models/scrollPaginate/scroll';
import { PartnerGridRow } from '../_models/partners/partnerGridRow';

@Injectable({
  providedIn: 'root'
})

export class PartnerService {
  baseUrl = environment.apiUrl + 'partners/';
  constructor(
    private http: HttpClient
  ) { }

  getPartnersPaged(scrollRequest: ScrollRequest): Observable<PartnerGridRow[]> {
    return this.http.post<PartnerGridRow[]>(this.baseUrl + 'GetPagedPartners', scrollRequest);
  }
  gerPartner(id: number): Observable<Partner> {
    return this.http.get<Partner>(this.baseUrl + 'partners/' + id);
  }
  savePartner(partner: Partner): Observable<Partner> {
    if (partner.Id > 0) {
      return this.updatePartner(partner);
    }
    return this.createPartner(partner);
  }
  deletePartner(id: number) {
    return this.http.delete(this.baseUrl + 'partner/' + id);
  }

  private updatePartner(partner: Partner): Observable<Partner> {
    return this.http.put<Partner>(this.baseUrl + 'partner/' + partner.Id, partner);
  }

  private createPartner(partner: Partner): Observable<Partner> {
    return this.http.post<Partner>(this.baseUrl + 'partner/', partner);
  }
}
