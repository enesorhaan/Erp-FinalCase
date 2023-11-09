import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

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
    return this.http.post(environment.apiUrl + 'currentaccounts', params, environment.httpOptions)
  }

  get(): Observable<any>{
    return this.http.get(environment.apiUrl + 'currentaccounts', environment.httpOptions)
  }

  getById(id:number): Observable<any>{
    return this.http.get(`${environment.apiUrl}currentaccounts/${id}`, environment.httpOptions)
  }

  update(id:number, params:any): Observable<any>{
    return this.http.put(`${environment.apiUrl}currentaccounts/${id}`, params, environment.httpOptions)
  }

  delete(id:number): Observable<any>{
    return this.http.delete(`${environment.apiUrl}currentaccounts/${id}`, environment.httpOptions)
  }
}
