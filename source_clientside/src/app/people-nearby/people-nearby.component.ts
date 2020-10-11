import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-people-nearby',
    templateUrl: './people-nearby.component.html',
    styleUrls: ['./people-nearby.component.css']
})
export class PeopleNearbyComponent implements OnInit {

    constructor(private router: Router ) {}

    ngOnInit() {

    }
    getPath(){
      return this.router.url;
    }
}
