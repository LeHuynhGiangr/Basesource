import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/_core/models/Post';
import { UtilityService } from 'src/app/_core/services/utility.service';
import { UriHandler } from 'src/app/_helpers/uri-handler';
import { ActivatedRoute, Router } from '@angular/router';
import { UserProfile } from 'src/app/_core/data-repository/profile';
import { ApiUrlConstants } from '../../../../src/app/_core/common/api-url.constants';
@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  @Input() public  postData:Post
  public m_returnUrl: string;
  constructor(public m_utility:UtilityService, public uriHandler:UriHandler,private m_route: ActivatedRoute, private m_router: Router) { }

  ngOnInit(): void {
    this.postData.imageUri = ApiUrlConstants.API_URL + "/" + this.postData.imageUri
    this.postData.authorThumb = ApiUrlConstants.API_URL + "/" + this.postData.authorThumb
  }
  getNavigation( id) {
    this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/main/timeline/'+id;
    UserProfile.IdTemp = id.toString()
    this.m_router.navigateByUrl(this.m_returnUrl, {skipLocationChange:true});
  }
}
