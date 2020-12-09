export interface Post{
    id:string,
    dateCreated:string,
    content:string,
    imageUri?:string,
    likeJson:{count:number, subjects:{Id:string, Name:string}[]},
    commentJson:{Id:string, Name:string, Comment:string}[],
    authorName:string,
    authorThumb?:string,
    authorId:string
}