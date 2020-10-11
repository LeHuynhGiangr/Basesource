import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-timeline-about',
    templateUrl: './timeline-about.component.html',
    styleUrls: ['./timeline-about.component.css']
})
export class TimelineAboutComponent implements OnInit {

    constructor(private router: Router ) {}

    ngOnInit() {

    }
    getPath(){
      return this.router.url;
    }
}
