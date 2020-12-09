import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiUrlConstants } from '../_core/common/api-url.constants';
import { SystemConstants } from '../_core/common/system.constants';
import { AuthenService } from '../_core/services/authen.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private m_authenService: AuthenService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        //throw new Error('Method not implemented.');
        //const l_user = this.m_authenService.currentUser;
        const l_authorBearer = localStorage.getItem(SystemConstants.LOCAL_STORED_JWT_Key)
        const l_isApiUrl = req.url.startsWith(ApiUrlConstants.API_URL);
        if (l_authorBearer && l_isApiUrl) {
            req = req.clone({
                headers: req.headers.set('Authorization', `Bearer ${l_authorBearer}`)
            });
        }

        return next.handle(req);
    }

}