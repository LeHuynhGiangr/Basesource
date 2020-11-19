import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';

@Component({
    selector: 'app-timeline',
    templateUrl: './timeline.component.html',
    styleUrls: ['./timeline.component.css']
})
export class TimelineComponent implements OnInit {

    appUsers:Array<AppUsers>
    public Name: string = ''
    public Image: string
    public dataset: AppUsers[]
    constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc ,private service: LoginService) {
      
    }
    
    async ngOnInit() {
      var script = document.createElement("script");
      script.type = "text/javascript";
      script.src = "../assets/js/script.js";
      this.elementRef.nativeElement.appendChild(script);

      var user = await this.service.getUser();
      console.log(user["firstName"]+" "+user["lastName"]);
      this.Name=user["firstName"]+" "+user["lastName"];
      this.Image = user["avatar"]
    }
    getPath(){
      return this.router.url;
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

}
 