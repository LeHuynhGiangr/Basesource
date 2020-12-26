import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { UserProfile } from '../../_core/data-repository/profile'
import { UriHandler } from 'src/app/_helpers/uri-handler';
import { MatDialog } from '@angular/material/dialog';
import { TripDialogComponent } from './trip-dialog/trip-dialog.component';
import { AddFriendDialogComponent } from './addfriend-dialog/addfriend-dialog.component';
import { Trips } from './../trip/shared/trip.model';
import { TripService } from './shared/trip.service';
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
    check:boolean=true
    constructor(private router: Router, private elementRef: ElementRef, @Inject(DOCUMENT) private doc,
      private service: LoginService,public uriHandler:UriHandler, public dialog: MatDialog,private TService:TripService) {
  
    }
    async ngOnInit() {
        this.appUsers = new AppUsers();
        var script = document.createElement("script");
        script.type = "text/javascript";
        script.src = "../assets/js/script.js";
        this.elementRef.nativeElement.appendChild(script);

        this.appUsers = new AppUsers();
        var user = await this.service.getUser();
        console.log(user["firstName"]+" "+user["lastName"]);
        this.appUsers.Avatar = UserProfile.Avatar
        this.appUsers.Id = UserProfile.Id
        console.log(this.appUsers.Id)
        this.getTripList()
        this.router.routeReuseStrategy.shouldReuseRoute = () =>{
           return false;
         }
    }
    getTripList = async () => {
      this.trips = await this.TService.getAllTrips()
      for (let i = 0; i < this.trips.length; i++) {
          let trip = new Trips();
          trip.Id = this.trips[i].id.toString()
          // //get friends in trip
          // this.users = await this.TService.getFriendInTrip(trip.Id)
          
          // if(this.users.length>0)
          // {
          //   for (let i = 0; i < this.users.length; i++) {
          //     let user = new AppUsers()         
          //     user.Id = this.users[i].userId
          //     const name = await this.service.getUserById(user.Id)
          //     user.FirstName = name["firstName"]
          //     user.LastName = name["lastName"]
          //     this.userList.push(user)
          //   }
          // }
          //get fields of trip
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
    clearArray()
    {
      for(let i=0;i<this.userList.length;i++){
        this.userList.pop()
      }
    }
    CreateTripDialog(): void {
        const dialogRef = this.dialog.open(TripDialogComponent, {
          width: '500px',
          height: '400px',
          data: { Id: this.appUsers.Id }
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
          data: { Id: this.appUsers.Id }
        });
    
        dialogRef.afterClosed().subscribe(result => {
          console.log('The dialog was closed');
          console.log(result);
        });
      }
}