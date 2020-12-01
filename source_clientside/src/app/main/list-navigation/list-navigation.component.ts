import { Component, OnInit } from '@angular/core';
import { LoginService } from './../../login/shared/login.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-list-navigation',
  templateUrl: './list-navigation.component.html',
  styleUrls: ['./list-navigation.component.css']
})
export class ListNavigationComponent implements OnInit {

  constructor(private router: Router,private service: LoginService) { }

  ngOnInit(): void {
  }
  onLogout() {
    this.service.logout();
    this.router.navigateByUrl('/login');
  }
}
