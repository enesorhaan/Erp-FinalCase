import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const AUTH_API = "https://localhost:44319/api/v1/";
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

interface IOrder {
  paymentMethod: number;
}

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  add(params: any): Observable<any>{
    return this.http.post(AUTH_API + 'orders', params, httpOptions)
  }

  getAdmin(): Observable<any>{
    return this.http.get(AUTH_API + 'orders/admin', httpOptions)
  }

  getDealer(): Observable<any>{
    return this.http.get(AUTH_API + 'orders/dealer', httpOptions)
  }

  getById(id:number): Observable<any>{
    return this.http.get(`${AUTH_API}orders/${id}`, httpOptions)
  }

  updateAdmin(id:number, params:any): Observable<any>{
    return this.http.put(`${AUTH_API}orders/admin/${id}`, params, httpOptions)
  }

  updateDealer(id:number, params:any): Observable<any>{
    return this.http.put(`${AUTH_API}orders/dealer/${id}`, params, httpOptions)
  }

  delete(id:number): Observable<any>{
    return this.http.delete(`${AUTH_API}orders/${id}`, httpOptions)
  }
}
