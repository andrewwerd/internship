import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Partner } from '../_models/partners/partner';
import { Observable } from 'rxjs';
import { Category } from '../_models/category';

@Injectable({
    providedIn: 'root'
})

export class PartnerService{
    baseUrl = environment.apiUrl;
    constructor(
        private http: HttpClient
    ){ }

    getPartners(): Observable<Partner[]>{
    return this.http.get<Partner[]>(this.baseUrl + 'partners');
    }
    gerPartner(id: number): Observable<Partner> {
        return this.http.get<Partner>(this.baseUrl + 'partners/' + id);
    }
    getCategories(): Observable<Category[]>{
      return this.http.get<Category[]>(this.baseUrl + 'categories/');
    }
    getSubcategories(id: number): Observable<Category[]>{
      return this.http.get<Category[]>(this.baseUrl + 'categories/' + id);
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
