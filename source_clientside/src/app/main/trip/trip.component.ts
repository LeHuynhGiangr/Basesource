import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from '../../_core/services/login.service';
import { UserProfile } from '../../_core/data-repository/profile'
import { UriHandler } from 'src/app/_helpers/uri-handler';
import { MatDialog } from '@angular/material/dialog';
import { TripDialogComponent } from './trip-dialog/trip-dialog.component';
import { AddFriendDialogComponent } from './addfriend-dialog/addfriend-dialog.component';
import { Trips } from '../../_core/models/trip.model';
import { TripService } from '../../_core/services/trip.service';
@Component({
    selector: 'app-trip',
    templateUrl: './trip.component.html',
    styleUrls: ['./trip.component.css']
  })
  export class TripComponent implements OnInit {
    public appUsers: AppUsers;
    public users:any
    public userList = new Array<AppUsers>();
    public trips:any
    public tripList = new Array<Trips>();
    play:boolean
    interval;
    time: number = 0;
    check:boolean=true
    constructor(private router: Router, private elementRef: ElementRef, @Inject(DOCUMENT) private doc,
      private service: LoginService,public uriHandler:UriHandler, public dialog: MatDialog,private TService:TripService) {
  
    }
    async ngOnInit() {
        var script = document.createElement("script");
        script.type = "text/javascript";
        script.src = "../assets/js/script.js";
        this.elementRef.nativeElement.appendChild(script);

        this.appUsers = new AppUsers();
        this.appUsers.Avatar = UserProfile.Avatar
        this.appUsers.Id = UserProfile.Id
        this.getTripList()
        this.startTimer()
        UserProfile.count = 1
        this.router.routeReuseStrategy.shouldReuseRoute = () =>{
           return false;
         }
    }
    startTimer() {
      this.play = true;
      this.interval = setInterval(() => {
        this.time++;
        if(this.time>=100)
        {
          this.play = false
          clearInterval(this.interval);
        }
      },50)
    }
    getTripList = async () => {
      this.trips = await this.TService.getAllTrips()
      for (let i = 0; i < UserProfile.count; i++) {
          let trip = new Trips();
          trip.Id = this.trips[i].id.toString()
          trip.Name = this.trips[i].name
          trip.Description = this.trips[i].description
          trip.Image = this.trips[i].image
          trip.authorId = this.trips[i].authorId
          trip.CreatedDate = this.trips[i].dateCreated
          trip.Image = this.trips[i].image
          const user = await this.service.getUserById(trip.authorId)
          trip.authorAvatar = user["avatar"]
          trip.authorName = user["firstName"]+" "+user["lastName"]
          this.tripList.push(trip)
      }
    }
    async getTripListmore(){
      this.time=0
      this.startTimer()
      this.trips = await this.TService.getAllTrips()
      for (let i = UserProfile.count; i < UserProfile.count+1; i++) {
          let trip = new Trips();
          trip.Id = this.trips[i].id.toString()
          trip.Name = this.trips[i].name
          trip.Description = this.trips[i].description
          trip.Image = this.trips[i].image
          trip.authorId = this.trips[i].authorId
          trip.CreatedDate = this.trips[i].dateCreated
          trip.Image = this.trips[i].image
          const user = await this.service.getUserById(trip.authorId)
          trip.authorAvatar = user["avatar"]
          trip.authorName = user["firstName"]+" "+user["lastName"]
          this.tripList.push(trip)
      }
      UserProfile.count=UserProfile.count+1
    }
    CreateTripDialog(): void {
        const dialogRef = this.dialog.open(TripDialogComponent, {
          width: '500px',
          height: '400px',
        });
    
        dialogRef.afterClosed().subscribe(result => {
          console.log('The dialog was closed');
          console.log(result);
        });
      }
    AddFriendDialog(): void {
        const dialogRef = this.dialog.open(AddFriendDialogComponent, {
          width: '500px',
          height: '400px',
        });
    
        dialogRef.afterClosed().subscribe(result => {
          console.log('The dialog was closed');
          console.log(result);
        });
      }
}