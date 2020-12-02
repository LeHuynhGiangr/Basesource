import { Component, OnInit } from '@angular/core';
import { LoginService } from './../login/shared/login.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private router: Router,private service: LoginService) { }

  ngOnInit(): void {
  }
  onLogout() {
    this.service.logout();
    this.router.navigateByUrl('/login');
  }
}
