import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-timeline-album',
    templateUrl: './timeline-album.component.html',
    styleUrls: ['./timeline-album.component.css']
})
export class TimelineAlbumComponent implements OnInit {

    constructor(private router: Router ) {}

    ngOnInit() {

    }
    getPath(){
      return this.router.url;
    }
}
