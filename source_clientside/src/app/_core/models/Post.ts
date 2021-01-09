import { PostComment } from "./post-comment.model";

export interface Post{
    id:string,
    dateCreated:string,
    content:string,
    imageUri?:string,
    likeJson:{count:number, subjects:{Id:string, Name:string}[]},
    commentJson:PostComment[],
    authorName:string,
    authorThumb?:string,
    authorId:string
}