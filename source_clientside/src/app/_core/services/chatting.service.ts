import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { ApiUrlConstants } from '../common/api-url.constants';

@Injectable({
  providedIn: 'root'
})
export class ChattingService {
  private postUrl:string=ApiUrlConstants.API_URL+'/friend';
  constructor(private m_http: HttpClient) { }

  getFriendDataById(){
    return this.m_http.get<any>(this.postUrl, {observe:'body', responseType:'json'});
  }
}
