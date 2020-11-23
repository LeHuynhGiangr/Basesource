import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import {NgForm} from '@angular/forms';
@Component({
    selector: 'app-edit-basic',
    templateUrl: './edit-basic.component.html',
    styleUrls: ['./edit-basic.component.css']
})
export class EditBasicComponent implements OnInit {

  appUsers:Array<AppUsers>
  public FName: string = ''
  public LName: string = ''
  public Name: string = ''
  public Email: string = ''
  public PhoneNumber: string = ''
  public Image: string
  public Description: string = ''
  public Address: string = ''
  public dataset: AppUsers[]
  constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc ,private service: LoginService) {
    
  }
  
  async ngOnInit() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "../assets/js/script.js";
    this.elementRef.nativeElement.appendChild(script);

    var user = await this.service.getUser();
    console.log(user["firstName"]+" "+user["lastName"]);
    this.Name=user["firstName"]+" "+user["lastName"];
    this.FName=user["firstName"];
    this.LName=user["lastName"];
    this.Image = user["avatar"];
    this.Email = user["email"];
    this.PhoneNumber = user["phoneNumber"];
    this.Address = user["address"];
    this.Description = user["description"];
  }
  getPath(){
    return this.router.url;
  }
  getImageMime(base64: string): string
  {
    return 'jpg';
  }
  getImageSource(base64: string): string
  {
    return `data:image/${this.getImageMime(base64)};base64,${base64}`; 
  }
  onSubmit() {
    console.log('title is:');
  }
}
