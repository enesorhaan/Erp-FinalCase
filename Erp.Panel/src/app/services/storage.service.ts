import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }

  clean(): void {
    window.sessionStorage.clear();
  }

  public saveUser(user: any): void {
    window.sessionStorage.removeItem('auth');
    window.sessionStorage.setItem('auth', JSON.stringify(user));
  }

  public getUser(): any {
    const user = window.sessionStorage.getItem('auth');
    if (user) {
      return JSON.parse(user);
    }
  }

  public isAdmin(): boolean{
    if(this.getUser().response.role == 0){
      return true;
    }else{
      return false;
    }
  }

  public getToken(): string {
    const stringifyUser:any = window.sessionStorage.getItem('auth');
    if (stringifyUser) {
      const user = JSON.parse(stringifyUser);
      const token = user.response.token;
      return token;
    }else{
      return '';
    }
  }
}
