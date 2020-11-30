import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable, throwError} from 'rxjs';

@Injectable()
export class FriendService{
    //constructor inject the HttpClient service
    private friendUrl:string='friend';
    constructor(private m_http: HttpClient){

    }

    getFriend(){
        //return this.m_http.get()
    }
}