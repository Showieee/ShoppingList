import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class LoginService {

    constructor(public http: Http) {

    }
    login(): any {
        var url = '';
        return this.http.get(url).map(res => res.json());

    }

}