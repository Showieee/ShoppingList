import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { GlobalService } from '../helpers/globals';
import { User } from './User';
import 'rxjs/add/operator/map';


@Injectable()
export class LoginService {
    private headers = new Headers({
        'Accept': 'application/json,*!/!*;q=0.9',
        'Content-Type': 'application/json',
    });

    constructor(public http: Http, public myGlobals: GlobalService) {

    }
    login(user: string, password: string): any {
        var url = 'http://' + this.myGlobals.webService + '/ShoppingList/Account/Login?username=' + user + '&password=' + password;
        return this.http.get('http://' + this.myGlobals.webService + '/ShoppingList/Account/Login?username=' + user + '&password=' + password, { headers: this.headers })
            .map((response: Response) => {
                var user = response.json() as User;
                this.myGlobals.user = user.username;
                this.myGlobals.userFirstName = user.firstName;
            })
    }

}