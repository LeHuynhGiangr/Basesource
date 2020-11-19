import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
    appUsers:Array<AppUsers>
    public Image: string
    constructor(private router: Router ,private service: LoginService) {}

    async ngOnInit() {
      var user = await this.service.getUser();
      this.Image = user["avatar"]
    }
    getImageMime(base64: string): string
    {
      if (base64.charAt(0)=='/') return 'jpg';
      else if (base64.charAt(0)=='R') return "gif";
      else if(base64.charAt(0)=='i') return 'png';
      else return 'jpeg';
    }
    getImageSource(base64: string): string
    {
      return `data:image/${this.getImageMime(base64)};base64,${base64}`; 
    }
    getPath(){
      return this.router.url;
    }
}

