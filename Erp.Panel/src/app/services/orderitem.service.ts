import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


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
    return this.http.post(environment.apiUrl + 'orderitems', params, environment.httpOptions)
  }

  get(): Observable<any>{
    return this.http.get(environment.apiUrl + 'orderitems', environment.httpOptions)
  }

  getById(id:number): Observable<any>{
    return this.http.get(`${environment.apiUrl}orderitems/${id}`, environment.httpOptions)
  }

  update(id:number, params:any): Observable<any>{
    return this.http.put(`${environment.apiUrl}orderitems/${id}`, params, environment.httpOptions)
  }

  delete(id:number): Observable<any>{
    return this.http.delete(`${environment.apiUrl}orderitems/${id}`, environment.httpOptions)
  }
}
