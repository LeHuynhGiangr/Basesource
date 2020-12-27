import { Component, Input, OnInit } from '@angular/core';
import { AppUsers } from 'src/app/login/shared/login.model';
import { LoginService } from 'src/app/_core/services/login.service';
import { TripService } from '../../../_core/services/trip.service';

@Component({
  selector: 'app-users-list-trip',
  templateUrl: './users-list-trip.component.html',
  styleUrls: ['./users-list-trip.component.css']
})
export class UsersListTripComponent implements OnInit {


  @Input() tripId: string
  public userList = new Array<AppUsers>();

  constructor(private TService: TripService,  private service: LoginService) {

  }

  ngOnInit(): void {
    this.getUsersListTrip();
  }

  getUsersListTrip = async () => {
    //get friends in trip
    const users = await this.TService.getFriendInTrip(this.tripId) as any;

    if (users.length > 0) {
      for (let i = 0; i < users.length; i++) {
        let user = new AppUsers()
        user.Id = users[i].userId
        const name = await this.service.getUserById(user.Id);
        user.FirstName = name["firstName"]
        user.LastName = name["lastName"]
        this.userList.push(user)
      }
    }
  }
}
