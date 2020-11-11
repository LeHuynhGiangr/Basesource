import {Injectable} from '@angular/core';
import { AuthenService } from '../_core/services/authen.service';

export function InitApp(authenService: AuthenService){
    return () => {
        new Promise(resolve => {
            authenService.refreshToken().subscribe().add(resolve);
        })
    }
}