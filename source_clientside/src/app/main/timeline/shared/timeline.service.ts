import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class TimeLineService {
    private urlAPI = 'https://localhost:44350/';

    constructor(private http: HttpClient) {

    }
    uploadAvatar = async (iduser) => {
        try {
            console.log(iduser);
            return await this.http.put(this.urlAPI + "avatar/",iduser).toPromise();            
        }
        catch (e) {
            console.log(e);
        }
    }
}