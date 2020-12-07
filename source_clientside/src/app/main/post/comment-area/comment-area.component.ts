import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { UtilityService } from 'src/app/_core/services/utility.service';
import { UriHandler } from 'src/app/_helpers/uri-handler';

@Component({
  selector: 'app-comment-area',
  templateUrl: './comment-area.component.html',
  styleUrls: ['./comment-area.component.css']
})
export class CommentAreaComponent implements OnInit {
  @Input() commentJson:{Id:string, Name:string, Comment:string}[]

  constructor(public m_utility:UtilityService, public uriHandler:UriHandler) { }

  ngOnInit(): void {
  }

}