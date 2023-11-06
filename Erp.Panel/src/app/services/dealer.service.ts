import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { StorageService } from './storage.service';

const AUTH_API = "https://localhost:44319/api/v1/";
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

interface IDealer {
  email: string;
  password: string;
  dealerName: string;
  address: string;
  billingAddress: string;
  taxOffice: string;
  taxNumber: number;
  marginPercentage: number;
}

@Injectable({
  providedIn: 'root'
})
export class DealerService {

  constructor(private http: HttpClient) { }

  add(params: any): Observable<any>{
    return this.http.post(AUTH_API + 'dealers', params, httpOptions)
  }

  get(): Observable<any>{
    return this.http.get(AUTH_API + 'dealers', httpOptions)
  }

  getById(id:number): Observable<any>{
    return this.http.get(`${AUTH_API}dealers/${id}`, httpOptions)
  }

  update(id:number, params:any): Observable<any>{
    return this.http.put(`${AUTH_API}dealers/${id}`, params, httpOptions)
  }

  delete(id:number): Observable<any>{
    return this.http.delete(`${AUTH_API}dealers/${id}`, httpOptions)
  }
}
