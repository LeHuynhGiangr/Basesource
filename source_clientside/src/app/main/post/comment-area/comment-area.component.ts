import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { UtilityService } from 'src/app/_core/services/utility.service';
import { UriHandler } from 'src/app/_helpers/uri-handler';
import { ActivatedRoute, Router } from '@angular/router';
import { UserProfile } from 'src/app/_core/data-repository/profile';
import { AppUsers } from '../../../login/shared/login.model';
import { ApiUrlConstants } from '../../../../../src/app/_core/common/api-url.constants';
@Component({
  selector: 'app-comment-area',
  templateUrl: './comment-area.component.html',
  styleUrls: ['./comment-area.component.css']
})
export class CommentAreaComponent implements OnInit {
  @Input() commentJson:{Id:string, Name:string, avarThumb:string, Comment:string}[]
  public m_returnUrl: string;
  public appUsers: AppUsers;
  constructor(public m_utility:UtilityService, public uriHandler:UriHandler,private m_route: ActivatedRoute, private m_router: Router) {
   }

  ngOnInit(): void {
    this.appUsers = new AppUsers();
    this.appUsers.Avatar =ApiUrlConstants.API_URL + "/" + UserProfile.Avatar;
  }

  getNavigation( id) {
    this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/main/timeline/'+id;
    UserProfile.IdTemp = id.toString()
    this.m_router.navigateByUrl(this.m_returnUrl, {skipLocationChange:true});
  }
  getImageComment(avatarThumb){
    return ApiUrlConstants.API_URL + "/"+avatarThumb
  }
}