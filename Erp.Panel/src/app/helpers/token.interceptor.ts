import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest, HTTP_INTERCEPTORS, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { StorageService } from '../services/storage.service';
import { Observable } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { LoaderService } from '../services/loader.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor{
    constructor(
        private storage: StorageService, 
        private loaderService : LoaderService
    ) {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.loaderService.requestStarted();
        const token = this.storage.getToken();
        if(token){
            req = req.clone({
                setHeaders: {
                    Authorization: `Bearer ${token}`
                }
            })
        }
        return next.handle(req).pipe(
            finalize(() => {
                this.loaderService.requestFinished();
            })
        )
    }
}

export const httpInterceptorProviders = [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }
]