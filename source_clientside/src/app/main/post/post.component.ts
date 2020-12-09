import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/_core/models/Post';
import { UtilityService } from 'src/app/_core/services/utility.service';
import { UriHandler } from 'src/app/_helpers/uri-handler';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  @Input() public  postData:Post
  constructor(public m_utility:UtilityService, public uriHandler:UriHandler) { }

  ngOnInit(): void {
  }

}
