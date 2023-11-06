import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { StorageService } from './storage.service';

const AUTH_API = "https://localhost:44319/api/v1/";
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

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
    return this.http.post(AUTH_API + 'products', params, httpOptions)
  }

  get(): Observable<any>{
    return this.http.get(AUTH_API + 'products', httpOptions)
  }

  getById(id:number): Observable<any>{
    return this.http.get(`${AUTH_API}products/${id}`, httpOptions)
  }

  update(id:number, params:any): Observable<any>{
    return this.http.put(`${AUTH_API}products/${id}`, params, httpOptions)
  }

  delete(id:number): Observable<any>{
    return this.http.delete(`${AUTH_API}products/${id}`, httpOptions)
  }
}
