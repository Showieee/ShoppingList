import { Component } from '@angular/core';
import { NavController, AlertController } from 'ionic-angular';
import { SitePage } from '../site/site';
import { SettingsPage } from '../settings/settings';
import { GlobalService } from '../helpers/globals';

@Component({
    selector: 'page-login',
    templateUrl: 'login.html'
})
export class LoginPage {
    username = localStorage.getItem('username').toString();
    password = '';
    constructor(public navCtrl: NavController, public alertCtrl: AlertController, public myGlobals: GlobalService) {

    }
    login() {
        //TODO baza
        if (null != this.username && null != this.password && this.username.toLowerCase() == "mircea" && this.password.toLowerCase() == "123") {
            console.log(localStorage.getItem('username'));
            localStorage.setItem('username', this.username);
            console.log(localStorage.getItem('username'));
            this.myGlobals.user = this.username;
            this.navCtrl.push(SitePage);
        }
    }
    openSettings() {
        this.navCtrl.push(SettingsPage);
    }
}
