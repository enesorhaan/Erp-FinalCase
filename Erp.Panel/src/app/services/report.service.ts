import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { StorageService } from './storage.service';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ReportService {

  constructor(private http: HttpClient) { }

  getDailyOrderReportById(id:number): Observable<any>{
    return this.http.get(`${environment.apiUrl}reports/orders/daily/report/${id}`, environment.httpOptions)
  }

  getWeeklyOrderReportById(id:number): Observable<any>{
    return this.http.get(`${environment.apiUrl}reports/orders/weekly/report/${id}`, environment.httpOptions)
  }

  getMonthlyOrderReportById(id:number): Observable<any>{
    return this.http.get(`${environment.apiUrl}reports/orders/monthly/report/${id}`, environment.httpOptions)
  }

  getDailyOrderReport(): Observable<any>{
    return this.http.get(`${environment.apiUrl}reports/orders/daily/report`, environment.httpOptions)
  }

  getWeeklyOrderReport(): Observable<any>{
    return this.http.get(`${environment.apiUrl}reports/orders/weekly/report`, environment.httpOptions)
  }

  getMonthlyOrderReport(): Observable<any>{
    return this.http.get(`${environment.apiUrl}reports/orders/monthly/report`, environment.httpOptions)
  }

  getProductReport(): Observable<any>{
    return this.http.get(`${environment.apiUrl}reports/products`, environment.httpOptions)
  }

  getProductCheckReport(): Observable<any>{
    return this.http.get(`${environment.apiUrl}reports/products/checkstock`, environment.httpOptions)
  }

  getOrderReportDealer(): Observable<any>{
    return this.http.get(`${environment.apiUrl}reports/orders/dealer`, environment.httpOptions)
  }
}
