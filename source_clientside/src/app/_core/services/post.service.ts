import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { ApiUrlConstants } from '../common/api-url.constants';
import { CreatePostRequest } from '../models/models.request/CreatePostRequest';
import { Post } from '../models/Post';
import { PostComponent } from 'src/app/main/post/post.component';
import { PostCommentRequest } from '../models/models.request/post-comment-request.model';
import { PostComment } from '../models/post-comment.model';

@Injectable({
  providedIn:'root'
})
export class PostService {
  private postUrl:string=ApiUrlConstants.API_URL+'/post';
  constructor(private m_http: HttpClient) { }

  getPostById(id:string){
    return this.m_http.get<Post[]>(this.postUrl+"/"+id, {observe:'body', responseType:'json'});
  }
  getPostByPostId(id:string){
    return this.m_http.get<Post[]>(this.postUrl+"/load/"+id, {observe:'body', responseType:'json'});
  }
  getPost():Observable<Post[]>{ 
    return this.m_http.get<Post[]>(this.postUrl+"/can-view", {observe:'body', responseType:'json'});
  }

  createPost(createPostRequest:CreatePostRequest):Observable<Post>{
    return this.m_http.post<Post>(this.postUrl, createPostRequest, {observe:'body', responseType:'json'}).pipe(catchError(this.handleError));
  }

  commentPost(postCmtRequest:PostCommentRequest):Observable<PostComment>{
    return this.m_http.post<PostComment>(this.postUrl+"/act-cmt", postCmtRequest, {observe:'body', responseType:'json'}).pipe(catchError(this.handleError));
  }

  private handleError(error:HttpErrorResponse){
    if(error.error instanceof ErrorEvent){
      console.error('An error occurred:', error.error.message);
      return throwError("Something bad happened; please check your internet and try again");
    }else{
      alert("Service is busy, please try again later")
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
      return throwError("Service is busy, please try again later");
    }
  }
}