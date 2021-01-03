import { Component, Input, OnInit, ElementRef, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminService } from '../../admin/admin.service';
import { PostService } from 'src/app/_core/services/post.service';
import { Post } from 'src/app/_core/models/Post';
import { ApiUrlConstants } from 'src/app/_core/common/api-url.constants';
@Component({
    selector: 'app-dialog-post-detail',
    templateUrl: './dialog-post-detail.component.html',
    styleUrls: ['./dialog-post-detail.component.css']
  })
  export class DialogPostDetailComponent implements OnInit {
    public idPost
    public m_posts:Post[];
    public m_post:Post;
    constructor(public dialogRef: MatDialogRef<DialogPostDetailComponent>, private elementRef: ElementRef, @Inject(DOCUMENT) private doc,private m_route: ActivatedRoute,private m_router: Router,
    private Aservice: AdminService, private PService:PostService) {
    }
    async ngOnInit() {
        this.getPostList(this.idPost)
    }
    onNoClick(): void {
        this.dialogRef.close();
    }
    public getPostList = async (id) => {
        this.PService.getPostByPostId(id).subscribe((jsonData:Post[])=>this.m_posts=jsonData);
    }
    getImageComment(avatarThumb){
        return ApiUrlConstants.API_URL + "/"+avatarThumb
    }
}