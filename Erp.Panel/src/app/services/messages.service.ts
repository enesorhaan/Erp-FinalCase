import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

interface IMessageAdmin {
  receiverId: number;
  transmitterMessage: string;
}

interface IMessageDealer {
  transmitterMessage: string;
}

@Injectable({
  providedIn: 'root'
})
export class MessagesService {

  constructor(private http: HttpClient) { }

  addAdmin(params: any): Observable<any>{
    return this.http.post(environment.apiUrl + 'messages/admin', params, environment.httpOptions)
  }

  addDealer(params: any): Observable<any>{
    return this.http.post(environment.apiUrl + 'messages/dealer', params, environment.httpOptions)
  }

  getAdmin(): Observable<any>{
    return this.http.get(environment.apiUrl + 'messages/admin', environment.httpOptions)
  }

  getDealer(): Observable<any>{
    return this.http.get(environment.apiUrl + 'messages/dealer', environment.httpOptions)
  }

  getById(id:number): Observable<any>{
    return this.http.get(`${environment.apiUrl}messages/${id}`, environment.httpOptions)
  }

  update(id:number, params:any): Observable<any>{
    return this.http.put(`${environment.apiUrl}messages/${id}`, params, environment.httpOptions)
  }

  delete(id:number): Observable<any>{
    return this.http.delete(`${environment.apiUrl}messages/${id}`, environment.httpOptions)
  }
}
