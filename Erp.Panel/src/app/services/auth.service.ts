import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { StorageService } from './storage.service';
import { environment } from 'src/environments/environment';


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
  }

  login(email: any, password: any):Observable<any>{
    return this.http.post(environment.apiUrl + 'login',{
      email,
      password
    }, environment.httpOptions)
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
}
