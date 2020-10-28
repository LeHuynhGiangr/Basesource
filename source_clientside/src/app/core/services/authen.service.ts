import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { SystemConstants } from '../common/system.constants'
import 'rxjs/add/operator/map' //working with asynchronous javascript

@Injectable({
  providedIn: 'root'
})
export class AuthenService {

  constructor(private m_http: HttpClient) { }

  //using for login/logout,
  //checking session
  login(username: string, password: string) {
    let l_headers = new HttpHeaders();
    //l_headers.append
    let l_body = "userName=" + encodeURIComponent(username) + "&password" + encodeURIComponent(password) + "&grant_type=password";
    //let l_option = new RequestO
    // return this.m_http.post(SystemConstants.BASE_API + '/api/authen/token', l_body, {}).map((response:Response)=>{

    // });
  }
  logout() {

  }
  isUserAuthenticated(): boolean {
    return true;
  }
  getLoggedInUser(): any {
    return null;
  }
}
