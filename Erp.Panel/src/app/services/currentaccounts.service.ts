import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const AUTH_API = "https://localhost:44319/api/v1/";
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

interface ICurrentAccount {
  dealerId: number;
  creditLimit: number;
}

@Injectable({
  providedIn: 'root'
})
export class CurrentaccountsService {

  constructor(private http: HttpClient) { }

  add(params: any): Observable<any>{
    return this.http.post(AUTH_API + 'currentaccounts', params, httpOptions)
  }

  get(): Observable<any>{
    return this.http.get(AUTH_API + 'currentaccounts', httpOptions)
  }

  getById(id:number): Observable<any>{
    return this.http.get(`${AUTH_API}currentaccounts/${id}`, httpOptions)
  }

  update(id:number, params:any): Observable<any>{
    return this.http.put(`${AUTH_API}currentaccounts/${id}`, params, httpOptions)
  }

  delete(id:number): Observable<any>{
    return this.http.delete(`${AUTH_API}currentaccounts/${id}`, httpOptions)
  }
}
