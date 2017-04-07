import { Component } from '@angular/core';
import { NavController, AlertController } from 'ionic-angular';
import { SitePage } from '../site/site';
import { SettingsPage } from '../settings/settings';
import { LoginService } from './loginService';
import { GlobalService } from '../helpers/globals';

@Component({
    selector: 'page-login',
    templateUrl: 'login.html'
})
export class LoginPage {
    username = localStorage.getItem('username').toString();
    password = '';
    constructor(public navCtrl: NavController, public alertCtrl: AlertController, public myGlobals: GlobalService, private loginService: LoginService) {
        myGlobals.webService = localStorage.getItem('ipWebService') + ':' + localStorage.getItem('portWebService');
    }
    login() {
        //TODO baza
            if (this.username == null && this.password == null) {
                let alert = this.alertCtrl.create({
                    title: 'Eroare',
                    subTitle: 'Completati campurile de Utilizator si parola!',
                    buttons: ['OK']
                });
                alert.present();
                return;
            }
            console.log(this.myGlobals);
            this.loginService.login(this.username, this.password).subscribe(res => {
                console.log(this.myGlobals.user);
                localStorage.setItem('user', this.username);
                localStorage.setItem('password', this.password);
                this.navCtrl.push(SitePage);
            }, error => {
                let alert = this.alertCtrl.create({
                    title: 'Eroare',
                    subTitle: <any>error,
                    buttons: ['OK']
                });
                alert.present();
            });
        }
    
    openSettings() {
        this.navCtrl.push(SettingsPage);
    }
}
