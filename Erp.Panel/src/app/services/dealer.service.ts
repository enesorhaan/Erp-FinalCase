import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


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
    return this.http.post(environment.apiUrl + 'dealers', params, environment.httpOptions)
  }

  get(): Observable<any>{
    return this.http.get(environment.apiUrl + 'dealers', environment.httpOptions)
  }

  getById(id:number): Observable<any>{
    return this.http.get(`${environment.apiUrl}dealers/${id}`, environment.httpOptions)
  }

  update(id:number, params:any): Observable<any>{
    return this.http.put(`${environment.apiUrl}dealers/${id}`, params, environment.httpOptions)
  }

  delete(id:number): Observable<any>{
    return this.http.delete(`${environment.apiUrl}dealers/${id}`, environment.httpOptions)
  }
}
