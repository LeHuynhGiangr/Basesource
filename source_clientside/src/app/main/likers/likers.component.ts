import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
@Component({
    selector: 'app-likers',
    templateUrl: './likers.component.html',
    styleUrls: ['./likers.component.css']
})
export class LikersComponent implements OnInit {

    constructor(private router: Router ,private elementRef: ElementRef,@Inject(DOCUMENT) private doc) {}

    ngOnInit() {
      var script = document.createElement("script");
      script.type = "text/javascript";
      script.src = "../assets/js/script.js";
      this.elementRef.nativeElement.appendChild(script);
    }
    getPath(){
      return this.router.url;
    }
}
