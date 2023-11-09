import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


interface IOrder {
  paymentMethod: number;
}

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  add(params: any): Observable<any>{
    return this.http.post(environment.apiUrl + 'orders', params, environment.httpOptions)
  }

  getAdmin(): Observable<any>{
    return this.http.get(environment.apiUrl + 'orders/admin', environment.httpOptions)
  }

  getDealer(): Observable<any>{
    return this.http.get(environment.apiUrl + 'orders/dealer', environment.httpOptions)
  }

  getById(id:number): Observable<any>{
    return this.http.get(`${environment.apiUrl}orders/${id}`, environment.httpOptions)
  }

  updateAdmin(id:number, params:any): Observable<any>{
    return this.http.put(`${environment.apiUrl}orders/admin/${id}`, params, environment.httpOptions)
  }

  updateDealer(id:number, params:any): Observable<any>{
    return this.http.put(`${environment.apiUrl}orders/dealer/${id}`, params, environment.httpOptions)
  }

  delete(id:number): Observable<any>{
    return this.http.delete(`${environment.apiUrl}orders/${id}`, environment.httpOptions)
  }
}
