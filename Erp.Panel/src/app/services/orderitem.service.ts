import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const AUTH_API = "https://localhost:44319/api/v1/";
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

interface IOrderItem {
  productId: number;
  quantity: number;
}

@Injectable({
  providedIn: 'root'
})

export class OrderitemService {

  constructor(private http: HttpClient) { }

  add(params: any): Observable<any>{
    return this.http.post(AUTH_API + 'orderitems', params, httpOptions)
  }

  get(): Observable<any>{
    return this.http.get(AUTH_API + 'orderitems', httpOptions)
  }

  getById(id:number): Observable<any>{
    return this.http.get(`${AUTH_API}orderitems/${id}`, httpOptions)
  }

  update(id:number, params:any): Observable<any>{
    return this.http.put(`${AUTH_API}orderitems/${id}`, params, httpOptions)
  }

  delete(id:number): Observable<any>{
    return this.http.delete(`${AUTH_API}orderitems/${id}`, httpOptions)
  }
}
