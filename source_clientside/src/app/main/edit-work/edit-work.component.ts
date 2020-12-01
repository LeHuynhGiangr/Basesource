import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogUploadAvatarComponent } from '../timeline/dialog-uploadavatar/dialog-uploadavatar.component';
import { EditWorkService } from './shared/edit-work.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DialogUploadBackgroundComponent } from '../timeline/dialog-uploadbackground/dialog-uploadbackground.component';
@Component({
  selector: 'app-edit-work',
  templateUrl: './edit-work.component.html',
  styleUrls: ['./edit-work.component.css']
})
export class EditWorkComponent implements OnInit {

  public appUsers: AppUsers;
  public m_returnUrl: string;
  constructor(private router: Router, private elementRef: ElementRef, @Inject(DOCUMENT) private doc, private service: LoginService, public dialog: MatDialog,
    private EWService: EditWorkService, private m_router: Router, private m_route: ActivatedRoute) {

  }

  async ngOnInit() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "../assets/js/script.js";
    this.elementRef.nativeElement.appendChild(script);


    this.appUsers = new AppUsers();
    var user = await this.service.getUser();
    this.appUsers.Id = user["id"].toString();
    console.log(user["firstName"] + " " + user["lastName"]);
    this.appUsers.FirstName = user["firstName"]
    this.appUsers.LastName = user["lastName"]
    this.appUsers.Avatar = user["avatar"]
    this.appUsers.AcademicLevel = user["academicLevel"]
    this.appUsers.AddressAcademic = user["addressAcademic"]
    this.appUsers.DescriptionAcademic = user["descriptionAcademic"]
    this.appUsers.StudyingAt = user["studyingAt"]
    this.appUsers.FromDate = user["fromDate"]
    this.appUsers.ToDate = user["toDate"]
    this.appUsers.Background = user["background"];
  }
    getPath() {
      return this.router.url;
    }
    getImageMime(base64: string): string {
      return 'jpg';
    }
    getImageSource(base64: string): string {
      return `data:image/${this.getImageMime(base64)};base64,${base64}`;
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
    selectChangeHandler(value: any) {
      //update the ui
      console.log('!!', value);
      this.appUsers.AcademicLevel = value;
    }
    onSave() {
      try {
        const lelveElement = document.querySelector("#level");
        this.appUsers.AcademicLevel = (<HTMLInputElement>lelveElement).value;
        const formData = new FormData();
        formData.append('id', this.appUsers.Id);
        if (1) {
          formData.append('academicLevel', this.appUsers.AcademicLevel);
          formData.append('studyingAt', this.appUsers.StudyingAt);
          formData.append('descriptionAcademic', this.appUsers.DescriptionAcademic);
          formData.append('addressAcademic', this.appUsers.AddressAcademic);
          formData.append('fromDate', this.appUsers.FromDate.toString());
          formData.append('toDate', this.appUsers.ToDate.toString());
          this.EWService.updateAcademic(this.appUsers.Id, formData);
          alert("Upload succesfully !")
          this.refresh();
        }
        else {
          alert("Upload failure !")
        }
      }
      catch (e) {
        alert("Upload failure !")
      }
    }
    refresh(): void {
      this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/main/about';
      this.m_router.navigateByUrl(this.m_returnUrl, { skipLocationChange: true });
      //window.location.reload();
    }
    openDialogBackground(): void {
      const dialogRef = this.dialog.open(DialogUploadBackgroundComponent, {
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
            this.appUsers.Background = user["background"]
          }
        });
  
      });
    }
}
