import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    private urlAPI = 'https://localhost:44350/user/';

    constructor(private http: HttpClient) {

    }

    getUser = async () => {
        try {
            return await this.http.get(this.urlAPI).toPromise();
        }
        catch (e) {
            console.log(e);
        }
    }

    postUser = async (users) => {
        try {
            console.log(users);
            return await this.http.post(this.urlAPI + "register", users).toPromise();
        }
        catch (e) {
            console.log(e);
        }
    }

    login = async (username, password) => {
        try {
            const data = {
                username,
                password
            };

            return await this.http.post(`${this.urlAPI}/`, data);
        }
        catch (e) {
            console.log(e);
        }
    };
}