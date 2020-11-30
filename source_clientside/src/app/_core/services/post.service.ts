import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import { Post } from '../models/Post';
import { catchError, retry } from 'rxjs/operators';

@Injectable()
export class PostService {
  private friendUrl:string='friend';
  constructor(private m_http: HttpClient) { }

  getPostById(id:string){
    return this.m_http.get<Post[]>(this.friendUrl+"/"+id, {observe:'body', responseType:'json'});
  }
}