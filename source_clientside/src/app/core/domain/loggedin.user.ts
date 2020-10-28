import { timeStamp } from 'console';

export class LoggedInUser{
    public id:string;
    public access_token:string;
    public username:string;
    public password:string;
    public email:string;
    public avatar:string;
    
    constructor(access_token:string, username:string, password:string, email:string, avatar:string){
        this.access_token=access_token;
        this.username=username;
        this.password=password;
        this.email=email;
        this.avatar=avatar;
    }

}