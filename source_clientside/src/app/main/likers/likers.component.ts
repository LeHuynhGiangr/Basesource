import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { LoginService } from './../../login/shared/login.service';
@Component({
    selector: 'app-likers',
    templateUrl: './likers.component.html',
    styleUrls: ['./likers.component.css']
})
export class LikersComponent implements OnInit {

    constructor(private router: Router ,private elementRef: ElementRef,@Inject(DOCUMENT) private doc, private service: LoginService) {}

    ngOnInit() {
      var script = document.createElement("script");
      script.type = "text/javascript";
      script.src = "../assets/js/script.js";
      this.elementRef.nativeElement.appendChild(script);
    }
    getPath(){
      return this.router.url;
    }
    onLogout() {
      this.service.logout();
      this.router.navigateByUrl('/login');
    }
}