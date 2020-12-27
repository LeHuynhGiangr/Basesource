import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { LoginService } from 'src/app/_core/services/login.service';

@Injectable({
  providedIn: 'root'
})
export class AdminRouteGuardService implements CanActivate {

  constructor(private m_router: Router, private service: LoginService) { }

  public canActivate(route: ActivatedRouteSnapshot) {
    console.log("Can go if you are admin !");
    const user = this.service.getCurrrentUser();

    if (user) {
        if (user["role"] == 0) {
            return true;
        }
        else if (user["role"] === 1) {
            //this.m_router.navigate(['/login'], {queryParams: {returnUrl: state.url}});
            this.m_router.navigateByUrl("/", { skipLocationChange: true });
            return false;
        }
    }

    this.m_router.navigateByUrl("/login", { skipLocationChange: true });
    return false;

  }
}
