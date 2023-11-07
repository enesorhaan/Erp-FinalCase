import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const AUTH_API = "https://localhost:44319/api/v1/";
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

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
    return this.http.post(AUTH_API + 'messages/admin', params, httpOptions)
  }

  addDealer(params: any): Observable<any>{
    return this.http.post(AUTH_API + 'messages/dealer', params, httpOptions)
  }

  getAdmin(): Observable<any>{
    return this.http.get(AUTH_API + 'messages/admin', httpOptions)
  }

  getDealer(): Observable<any>{
    return this.http.get(AUTH_API + 'messages/dealer', httpOptions)
  }

  getById(id:number): Observable<any>{
    return this.http.get(`${AUTH_API}messages/${id}`, httpOptions)
  }

  update(id:number, params:any): Observable<any>{
    return this.http.put(`${AUTH_API}messages/${id}`, params, httpOptions)
  }

  delete(id:number): Observable<any>{
    return this.http.delete(`${AUTH_API}messages/${id}`, httpOptions)
  }
}
