import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { LoginService } from './shared/login.service';
import { AppUsers } from './shared/login.model';
import { EditPasswordComponent } from '../main/edit-password/edit-password.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public appUsers: AppUsers;

  constructor(private router: Router, private elementRef: ElementRef, @Inject(DOCUMENT) private doc, private service: LoginService) { }

  ngOnInit() {
    this.appUsers = new AppUsers();
    this.appUsers.Gender = 'Male';
    this.appUsers.AcceptTerms = false;
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "../assets/js/script.js";
    this.elementRef.nativeElement.appendChild(script);
    this.appUsers.AcceptTerms = true;
  }

  getPath() {
    return this.router.url;
  }
  clear()
  {
    //clear input after register
  }
  onChangeGender = (event: any) => {
    this.appUsers.Gender = event.target.value;
  }

  onChangeTerm = (event: any) => {
    this.appUsers.AcceptTerms = event.target.checked;
    console.log(this.appUsers)
  }


  public createUser = async () => {
    try {

      if (this.appUsers.Password !== this.appUsers.ConfirmPassword) {
        return alert('Password not match a confirm password');
      }

      console.log("Created", this.appUsers);

      if (this.appUsers) {
        const result = await this.service.postUser(this.appUsers);
        console.log(result);
        if (result)
          alert('Register sucessfully');
      }
    }
    catch (e) {
      alert('Register failed');
    }
  };
}
