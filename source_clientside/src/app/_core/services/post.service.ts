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
  private friendUrl:string=ApiUrlConstants.API_URL+'/post';
  constructor(private m_http: HttpClient) { }

  getPostById(id:string){
    return this.m_http.get<any[]>(this.friendUrl+"/"+id, {observe:'body', responseType:'json'});
  }
}