import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-timeline-friends',
    templateUrl: './timeline-friends.component.html',
    styleUrls: ['./timeline-friends.component.css']
})
export class TimelineFriendsComponent implements OnInit {

    constructor(private router: Router ) {}

    ngOnInit() {

    }
    getPath(){
      return this.router.url;
    }
}
