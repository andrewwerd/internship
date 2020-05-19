import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../_models/category';

@Injectable( )

export class CategoryService {

  baseUrl = environment.apiUrl + 'categories/';
  constructor(
    private http: HttpClient
  ) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl);
  }
  getSubcategories(id: number): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl + 'getSubcategories/' + id);
  }
}
