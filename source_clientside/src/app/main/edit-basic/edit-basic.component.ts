import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { EditBasicService } from './shared/edit-basic.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { DialogUploadAvatarComponent } from '../timeline/dialog-uploadavatar/dialog-uploadavatar.component';
@Component({
    selector: 'app-edit-basic',
    templateUrl: './edit-basic.component.html',
    styleUrls: ['./edit-basic.component.css']
})
export class EditBasicComponent implements OnInit {

  public appUsers: AppUsers;
  public m_returnUrl: string;
  constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc ,private service: LoginService, 
    private EBService: EditBasicService, private m_route: ActivatedRoute, private m_router: Router,public dialog: MatDialog) {
    
  }
  
  async ngOnInit() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "../assets/js/script.js";
    this.elementRef.nativeElement.appendChild(script);

    this.appUsers = new AppUsers();
    var user = await this.service.getUser();
    this.appUsers.Id = user["id"].toString();
    console.log(user["firstName"]+" "+user["lastName"]);
    this.appUsers.FirstName=user["firstName"];
    this.appUsers.LastName=user["lastName"];
    this.appUsers.Avatar = user["avatar"];
    this.appUsers.Email = user["email"];
    this.appUsers.Gender = user["gender"];
    this.appUsers.Works = user["works"]
    this.appUsers.Location = user["location"];
    this.appUsers.PhoneNumber = user["phoneNumber"];
    this.appUsers.Address = user["address"];
    this.appUsers.Descriptions = user["description"];
    this.appUsers.BirthDay= user["birthDay"];
    //this.datePipe.transform(this.appUsers.BirthDay,"yyyy-MM-dd")
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
  onChangeGender = (event: any) => {
    this.appUsers.Gender = event.target.value;
  }
  onSave() {
    try{
      const formData = new FormData();
      formData.append('id', this.appUsers.Id);
      if (1) {
        formData.append('firstName', this.appUsers.FirstName);
        formData.append('lastName', this.appUsers.LastName);
        formData.append('description', this.appUsers.Descriptions);
        formData.append('email', this.appUsers.Email);
        formData.append('address', this.appUsers.Address);
        formData.append('gender', this.appUsers.Gender);
        formData.append('phoneNumber', this.appUsers.PhoneNumber);
        formData.append('works', this.appUsers.Works);
        formData.append('birthDay', this.appUsers.BirthDay.toString());
        this.EBService.uploadProfile(this.appUsers.Id,formData);
        alert("Upload succesfully !")
        this.refresh();
      }
      else
      {
        alert("Upload failure !")
      }
    }
    catch(e)
    {
      alert("Upload failure !")
    }
  }
  refresh(): void {
    this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/main/about';
    this.m_router.navigateByUrl(this.m_returnUrl, {skipLocationChange:true});
    //window.location.reload();
  }
  onFileChanged(event) {
    this.appUsers.Avatar = event.target.files[0]
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogUploadAvatarComponent, {
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
          this.appUsers.Avatar = user["avatar"]
        }
      });
    });
  }
}