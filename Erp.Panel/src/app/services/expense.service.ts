import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

interface IExpense {
  description: string;
  amount: number;
  expenseDate: Date;
}

@Injectable({
  providedIn: 'root'
})

export class ExpenseService {

  constructor(private http: HttpClient) { }

  add(params: any): Observable<any>{
    return this.http.post(environment.apiUrl + 'expenses', params, environment.httpOptions)
  }

  get(): Observable<any>{
    return this.http.get(environment.apiUrl + 'expenses', environment.httpOptions)
  }

  getById(id:number): Observable<any>{
    return this.http.get(`${environment.apiUrl}expenses/${id}`, environment.httpOptions)
  }

  update(id:number, params:any): Observable<any>{
    return this.http.put(`${environment.apiUrl}expenses/${id}`, params, environment.httpOptions)
  }

  delete(id:number): Observable<any>{
    return this.http.delete(`${environment.apiUrl}expenses/${id}`, environment.httpOptions)
  }
}
