import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { Trips } from '../../_core/models/trip.model';
import { TripStatic } from '../../_core/data-repository/trip';
import {TripUrl} from 'src/app/_helpers/get-trip-url'
@Component({
    selector: 'app-trip-detail',
    templateUrl: './trip-detail.component.html',
    styleUrls: ['./trip-detail.component.css']
})
export class TripDetailComponent implements OnInit {
    public trips :Trips;
    constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc, public tripurl:TripUrl ) {}

    ngOnInit() {
      var script = document.createElement("script");
      script.type = "text/javascript";
      script.src = "../assets/js/script.js";
      this.elementRef.nativeElement.appendChild(script);

      this.trips = new Trips()
      this.trips.Id = TripStatic.Id
      this.trips.Name = TripStatic.Name
      this.trips.Description = TripStatic.Description
      this.trips.Cost = TripStatic.Cost
      this.trips.Departure = TripStatic.Departure
      this.trips.Destination = TripStatic.Destination
      this.trips.Policy = TripStatic.Policy
      this.trips.InfoContact = TripStatic.InfoContact
      this.trips.Days = TripStatic.Days
      this.trips.DateStart = TripStatic.DateStart
      this.trips.DateEnd = TripStatic.DateEnd
      this.trips.Service = TripStatic.Service
    }
    getPath(){
      return this.router.url;
    }
}
