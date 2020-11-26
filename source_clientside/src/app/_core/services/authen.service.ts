import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
//import 'rxjs/add/operator/map'; //working with asynchronous javascript
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../domain/user';
import { Router } from '@angular/router';
import { ApiUrlConstants } from '../common/api-url.constants';
import { UrlConstants } from '../common/url.constants';

@Injectable({
  providedIn: 'root'
})
export class AuthenService {
  private m_userSubject: BehaviorSubject<User>;
  public m_user: Observable<User>;

  constructor(private m_router: Router, private m_http: HttpClient) {
    this.m_userSubject = new BehaviorSubject<User>(null);
    this.m_user = this.m_userSubject.asObservable();
  }

  public get currentUser():User{
    return this.m_userSubject.value;
  }

  //using for login/logout,
  //checking session
  login(l_username: string, l_password: string) {
    // let l_headers = new HttpHeaders();
    //l_headers.append
    // let l_body = "userName=" + encodeURIComponent(username) + "&password" + encodeURIComponent(password) + "&grant_type=password";
    // //let l_option = new RequestO
    // // return this.m_http.post(SystemConstants.BASE_API + '/api/authen/token', l_body, {}).map((response:Response)=>{

    // });
    return this.m_http.post<any>(ApiUrlConstants.API_URL + '/user/authenticate', { l_username, l_password }, { withCredentials: true })
      .pipe(map(user => {
        this.m_userSubject.next(user);
        //start auto refresh token *******************
        this.startRefreshTokenTimer();
        return user;
      }));//For versions of RxJS 6.x.x and above, you will have to use pipeable operators
  }

  logout() {
    this.m_http.post<any>(ApiUrlConstants.API_URL + '/user/revoke-token', {}, { withCredentials: true }).subscribe();
    //stop auto refresh token ********************
    this.stopRefreshTokenTimer();
    this.m_userSubject.next(null);
    this.m_router.navigate([UrlConstants.LOGIN_URL]);
  }

  refreshToken() {
    return this.m_http.post<any>(ApiUrlConstants.API_URL + '/user/refresh-token', {}, { withCredentials: true })
      .pipe(map(user => {
        this.m_userSubject.next(user);
        //start auto refresh token *******************
        this.startRefreshTokenTimer();
        return user;
      }));
  }

  //helper methods
  private m_refreshTokenTimeout:any;

  public startRefreshTokenTimer() {
    // parse json object from base64 encoded jwt token
    const jwtToken = JSON.parse(atob(this.currentUser.jwtToken.split('.')[1]));

    // set a timeout to refresh the token a minute before it expires
    const expires = new Date(jwtToken.exp * 1000);
    const timeout = expires.getTime() - Date.now() + (60 * 50000);
    this.m_refreshTokenTimeout = setTimeout(() => this.refreshToken().subscribe(), timeout);
  }

  private stopRefreshTokenTimer() {
    clearTimeout(this.m_refreshTokenTimeout);
  }
  /* isUserAuthenticated(): boolean {
    return true;
  }
  getLoggedInUser(): any {
    return null;
  } */
}
