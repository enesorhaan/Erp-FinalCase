import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { StorageService } from './storage.service';

const AUTH_API = "https://localhost:44319/api/v1/";
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  constructor(private http: HttpClient) { }

  getDailyOrderReportById(id:number): Observable<any>{
    return this.http.get(`${AUTH_API}reports/orders/daily/report/${id}`, httpOptions)
  }

  getWeeklyOrderReportById(id:number): Observable<any>{
    return this.http.get(`${AUTH_API}reports/orders/weekly/report/${id}`, httpOptions)
  }

  getMonthlyOrderReportById(id:number): Observable<any>{
    return this.http.get(`${AUTH_API}reports/orders/monthly/report/${id}`, httpOptions)
  }

  getDailyOrderReport(): Observable<any>{
    return this.http.get(`${AUTH_API}reports/orders/daily/report`, httpOptions)
  }

  getWeeklyOrderReport(): Observable<any>{
    return this.http.get(`${AUTH_API}reports/orders/weekly/report`, httpOptions)
  }

  getMonthlyOrderReport(): Observable<any>{
    return this.http.get(`${AUTH_API}reports/orders/monthly/report`, httpOptions)
  }

  getProductReport(): Observable<any>{
    return this.http.get(`${AUTH_API}reports/products`, httpOptions)
  }

  getProductCheckReport(): Observable<any>{
    return this.http.get(`${AUTH_API}reports/products/checkstock`, httpOptions)
  }

  getOrderReportDealer(): Observable<any>{
    return this.http.get(`${AUTH_API}reports/orders/dealer`, httpOptions)
  }
}
