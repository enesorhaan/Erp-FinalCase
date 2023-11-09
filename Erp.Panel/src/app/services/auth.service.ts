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

export class AuthService {

  tokenData:any[] = []

  roleAs: number = 0;

  constructor(
    private http: HttpClient,
    private router: Router,
    private storage:StorageService
  ) { }

  register(){
    console.log("Register");
  }

  login(email: any, password: any):Observable<any>{
    return this.http.post(AUTH_API + 'login',{
      email,
      password
    }, httpOptions)
  }

  logOut(){
    this.storage.clean();
    this.router.navigate(['/login']);
  }

  isLoggin(){
    let user = this.storage.getUser();
    if(user){
      this.roleAs = user.response.role;
      return true;
    }else{
      return false;
    }
  }

  fetchExample():Observable<any>{
    return this.http.get(AUTH_API + 'companies', httpOptions)
  }
}
