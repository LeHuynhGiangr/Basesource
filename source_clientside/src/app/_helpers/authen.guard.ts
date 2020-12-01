import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from '../login/shared/login.service';
import { UrlConstants } from '../_core/common/url.constants';
import { AuthenService } from '../_core/services/authen.service';

@Injectable({ providedIn: 'root' })
export class AuthenGuard implements CanActivate {

    constructor(private m_router: Router, private m_authenService: AuthenService, private service: LoginService) {

    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        //throw new Error('Method not implemented.');
        // const l_user = this.m_authenService.currentUser;
        // if(l_user){
        //     //logged in so return true
        //     return true;
        // }else{
        //     //this.m_router.navigate(['/login'], {queryParams: {returnUrl: state.url}});
        //     this.m_router.navigateByUrl("/login", {skipLocationChange:true});
        //     return false;
        // }

        // const user = this.service.getCurrrentUser();

        // if (user) {
        //     //logged in so return true
        //     return true;
        // } else {
        //     //this.m_router.navigate(['/login'], {queryParams: {returnUrl: state.url}});
        //     this.m_router.navigateByUrl("/login", { skipLocationChange: true });
        //     return false;
        // }
        return true;

    }

}