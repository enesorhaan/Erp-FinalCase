import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const AUTH_API = "https://localhost:44319/api/v1/";
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

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
    return this.http.post(AUTH_API + 'expenses', params, httpOptions)
  }

  get(): Observable<any>{
    return this.http.get(AUTH_API + 'expenses', httpOptions)
  }

  getById(id:number): Observable<any>{
    return this.http.get(`${AUTH_API}expenses/${id}`, httpOptions)
  }

  update(id:number, params:any): Observable<any>{
    return this.http.put(`${AUTH_API}expenses/${id}`, params, httpOptions)
  }

  delete(id:number): Observable<any>{
    return this.http.delete(`${AUTH_API}expenses/${id}`, httpOptions)
  }
}
