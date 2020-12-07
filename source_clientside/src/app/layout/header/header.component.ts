import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { UriHandler } from 'src/app/_helpers/uri-handler';
@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
    appUsers:Array<AppUsers>
    public Image: string
    constructor(private router: Router ,private service: LoginService, public uriHandler:UriHandler) {}

    async ngOnInit() {
      var user = await this.service.getUser();
      this.Image = user["avatar"]
    }
    getPath(){
      return this.router.url;
    }
    onLogout() {
      this.service.logout();
      this.router.navigateByUrl('/login');
    }
}

