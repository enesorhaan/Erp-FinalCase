import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { StorageService } from './storage.service';
import { environment } from 'src/environments/environment';

interface IProduct {
  productName: string;
  productPrice: number;
  productStock: number;
}

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  add(params: any): Observable<any>{
    return this.http.post(environment.apiUrl + 'products', params, environment.httpOptions)
  }

  get(): Observable<any>{
    return this.http.get(environment.apiUrl + 'products', environment.httpOptions)
  }

  getById(id:number): Observable<any>{
    return this.http.get(`${environment.apiUrl}products/${id}`, environment.httpOptions)
  }

  update(id:number, params:any): Observable<any>{
    return this.http.put(`${environment.apiUrl}products/${id}`, params, environment.httpOptions)
  }

  delete(id:number): Observable<any>{
    return this.http.delete(`${environment.apiUrl}products/${id}`, environment.httpOptions)
  }
}
