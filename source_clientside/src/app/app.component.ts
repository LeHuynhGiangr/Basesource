import { Component } from '@angular/core';
import { User } from './_core/domain/user';
import { AuthenService } from './_core/services/authen.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  m_user:User
  title = 'ProjectAngular';

  constructor(private m_authenService:AuthenService){
    this.m_authenService.m_user.subscribe(u => this.m_user=u);
  }

  logout(){
    this.m_authenService.logout();
  }
}
