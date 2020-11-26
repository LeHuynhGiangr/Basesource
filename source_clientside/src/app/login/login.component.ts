import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { LoginService } from './shared/login.service';
import { AppUsers } from './shared/login.model';
import { EditPasswordComponent } from '../main/edit-password/edit-password.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenService } from '../_core/services/authen.service';
import { UrlConstants } from '../_core/common/url.constants';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public m_loginForm: FormGroup; //check value and validity state
  public m_returnUrl: string;
  public m_submitted: boolean = false;
  public m_loading: boolean = false;
  public m_error = '';

  public appUsers: AppUsers;

  constructor(private m_formBuilder: FormBuilder, private m_route: ActivatedRoute, private m_router: Router
    , private elementRef: ElementRef, @Inject(DOCUMENT) private doc, private service: LoginService) {
  }

  async ngOnInit() {
    this.appUsers = new AppUsers();
    this.appUsers.Gender = 'Male';
    this.appUsers.AcceptTerms = false;
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "../assets/js/script.js";
    this.elementRef.nativeElement.appendChild(script);
    this.appUsers.AcceptTerms = true;
    this.m_loginForm = this.m_formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/';

    const user = await this.service.getUser();
    console.log(user)
    if (user) {
      this.m_router.navigateByUrl('/', { skipLocationChange: true });
    }
  }

  private get m_formValue() {
    return this.m_loginForm.controls;
  }

  async onSubmit() {
    this.m_submitted = true;
    if (this.m_loginForm.invalid) {
      return;
    }
    this.m_loading = true;
    // this.m_authenService.login(this.m_formValue.username.value, this.m_formValue.password.value)
    //   .pipe(first())
    //   .subscribe({
    //     next: () => {this.m_router.navigateByUrl(this.m_returnUrl, {skipLocationChange:true});},

    //     error:error=>{
    //       this.m_error=error;
    //       this.m_loading=false;
    //     }
    //   });

    this.service.login(this.m_formValue.username.value, this.m_formValue.password.value).then((result) => {
      if (result) {
        alert('Login Successfully');
        // this.m_authenService.startRefreshTokenTimer();
        this.m_router.navigateByUrl('/', { skipLocationChange: true });
      }
      else
        alert('Username or Password incorrect !');
      console.log(result);
    }).catch((error) => {
      this.m_error = error;
      this.m_loading = false;
    });

  }

  getPath() {
    return this.m_router.url;
  }

  clear() {
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
      console.log("Created", this.appUsers);
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
