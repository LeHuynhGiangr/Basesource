import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import { Post } from '../models/Post';
import { catchError, retry } from 'rxjs/operators';
import { provideRoutes } from '@angular/router';
import { ApiUrlConstants } from '../common/api-url.constants';

@Injectable({
  providedIn:'root'
}
)
export class PostService {
  private postUrl:string=ApiUrlConstants.API_URL+'/post';
  constructor(private m_http: HttpClient) { }

  getPostById(id:string){
    return this.m_http.get<any[]>(this.postUrl+"/"+id, {observe:'body', responseType:'json'});
  }

  getPost(){
    return this.m_http.get<any[]>(this.postUrl, {observe:'body', responseType:'json'});
  }
}