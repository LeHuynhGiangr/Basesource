import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { delay, dematerialize, materialize, mergeMap } from 'rxjs/operators';

const g_usersKey="123-456-789-abc-def";
const g_users=JSON.parse(localStorage.getItem(g_usersKey)) || [];


if(!g_users.length){
    g_users.push({ id: '1',  firstName: 'Test', lastName: 'User', username: 'test', password: 'test', refreshTokens: [] });
    localStorage.setItem(g_usersKey, JSON.stringify(g_users));
}

@Injectable()
export class FakeBackendInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        //throw new Error('Method not implemented.');
        const { url, method, headers, body } = req;

        return of(null)
            .pipe(mergeMap(handleRoute))
            .pipe(materialize())
            .pipe(delay(500))
            .pipe(dematerialize());

        function handleRoute() {
            switch (true) {
                case url.endsWith('/user/authenticate') && method === 'POST':
                    return authenticate();
                case url.endsWith('/user/refresh-token') && method === 'POST':
                    return refreshToken();
                case url.endsWith('/user/revoke-token') && method === 'POST':
                    return revokeToken();
                case url.endsWith('/user') && method === 'GET':
                    return getUsers();
                default:
                    // pass through any requests not handled above
                    return next.handle(req);
            }
        }

        function authenticate() {
            //const {username, password} = body;
            const {username, password} = {username:'test', password:'test'};
            const l_user = g_users.find(x =>x.username === username && x.password===password);
            alert(l_user.password);
            if(!l_user){
                return error({username:username, password:password}); 
            } 

            l_user.refreshTokens.push(generateRefreshToken());

            localStorage.setItem(g_usersKey, JSON.stringify(g_users));

            return ok({
                id: l_user.id,
                username:l_user.username,
                firstName:l_user.firstName,
                lastName:l_user.lastName,
                jwtToken: generateJwtToken(),
            });
        }

        function refreshToken() {
            const l_refreshToken = getRefreshToken();
            
            if (!l_refreshToken) return unauthorized();

            const l_user = g_users.find(x => x.refreshTokens.includes(l_refreshToken));
            
            if (!l_user) return unauthorized();

            // replace old refresh token with a new one and save
            l_user.refreshTokens = l_user.refreshTokens.filter(x => x !== l_refreshToken);
            l_user.refreshTokens.push(generateRefreshToken());
            localStorage.setItem(g_usersKey, JSON.stringify(g_users));

            return ok({
                id: l_user.id,
                username: l_user.username,
                firstName: l_user.firstName,
                lastName: l_user.lastName,
                jwtToken: generateJwtToken()
            });
        }

        function revokeToken() {
            if (!isLoggedIn()) return unauthorized();
            
            const l_refreshToken = getRefreshToken();
            const l_user = g_users.find(x => x.refreshTokens.includes(l_refreshToken));
            
            // revoke token and save
            l_user.refreshTokens = l_user.refreshTokens.filter(x => x !== l_refreshToken);
            localStorage.setItem(g_usersKey, JSON.stringify(g_users));

            return ok();
        }

        function getUsers() {
            if (!isLoggedIn()) return unauthorized();
            return ok(g_users);
        }

        function ok(body?) {
            return of(new HttpResponse({ status: 200, body }))
        }

        function error(message) {
            return throwError({ error: { message } });
        }

        function unauthorized() {
            return throwError({ status: 401, error: { message: 'Unauthorized' } });
        }

        function isLoggedIn() {
            // check if jwt token is in auth header
            const l_authHeader = headers.get('Authorization');
            if (!l_authHeader.startsWith('Bearer fake-jwt-token')) return false;

            // check if token is expired
            const l_jwtToken = JSON.parse(atob(l_authHeader.split('.')[1]));
            const l_tokenExpired = Date.now() > (l_jwtToken.exp * 1000);
            if (l_tokenExpired) return false;

            return true;
        }

        function generateJwtToken(){
            const tokenPayload = { exp: Math.round(new Date(Date.now() + 15*60*1000).getTime() / 1000) }
            return `fake-jwt-token.${btoa(JSON.stringify(tokenPayload))}`;
        }

        function generateRefreshToken() {
            const token = new Date().getTime().toString();

            // add token cookie that expires in 7 days
            const expires = new Date(Date.now() + 7*24*60*60*1000).toUTCString();
            document.cookie = `fakeRefreshToken=${token}; expires=${expires}; path=/`;

            return token;
        }

        function getRefreshToken() {
            // get refresh token from cookie
            return (document.cookie.split(';').find(x => x.includes('fakeRefreshToken')) || '=').split('=')[1];
        }
    }
}

export let fakeBackendProvider={
    provide:HTTP_INTERCEPTORS,
    useClass: FakeBackendInterceptor,
    multi: true,
};