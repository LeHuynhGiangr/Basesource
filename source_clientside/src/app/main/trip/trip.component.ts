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
@Component({
    selector: 'app-trip',
    templateUrl: './trip.component.html',
    styleUrls: ['./trip.component.css']
  })
  export class TripComponent implements OnInit {
    public appUsers: AppUsers;
    constructor(private router: Router, private elementRef: ElementRef, @Inject(DOCUMENT) private doc,
      private service: LoginService,public uriHandler:UriHandler, public dialog: MatDialog) {
  
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
        this.router.routeReuseStrategy.shouldReuseRoute = () =>{
           return false;
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
          this.service.getUser().then(user => {
            if (user) {
              console.log(user["firstName"] + " " + user["lastName"]);
              this.appUsers.Id = user["id"].toString();
            }
          });
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
          this.service.getUser().then(user => {
            if (user) {
              console.log(user["firstName"] + " " + user["lastName"]);
              this.appUsers.Id = user["id"].toString();
            }
          });
        });
      }
}