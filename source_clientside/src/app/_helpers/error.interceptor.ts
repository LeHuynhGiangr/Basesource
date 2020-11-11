import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthenService } from '../_core/services/authen.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor{

    constructor(private m_authenService:AuthenService){}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        //throw new Error('Method not implemented.');
        return next.handle(req).pipe(catchError(err=>{
            if([401, 403].includes(err.status) && this.m_authenService.currentUser){
                this.m_authenService.logout();
            }

            const error = (err && err.error && err.error.message) || err.statusText;
            console.error(err);
            return throwError(error);
        }));
    }
}