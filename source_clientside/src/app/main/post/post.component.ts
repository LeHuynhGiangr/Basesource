import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { UtilityService } from 'src/app/_core/services/utility.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  @Input() public  postData:{
    id:number,
    dateCreated:string,
    content:string,
    imageUri?:string,
    likeJson:{count:number, subjects:{Id:string, Name:string}[]},
    commentJson:{Id:string, Name:string, Comment:string}[],
    authorName:string,
    authorThumb?:string,
    authorId:string
  }
  constructor(public m_utility:UtilityService) { }

  ngOnInit(): void {
  }

}
