import { Component, Input } from '@angular/core';
import { NavController, NavParams, AlertController } from 'ionic-angular';
import { GroupsComponent } from "../groups/groupsComponent";

import { GlobalService } from '../helpers/globals';
@Component({
    selector: 'settings-login',
    templateUrl: 'settings.html',
})

export class SettingsPage {

    @Input()
    ipWebService: string;
    @Input()
    portWebService: string;
    readTimeout: any;
    writeTimeout: any;
    userWebService: any;
    passwordWebService: any;
    local: any;


    constructor(private alertCtrl: AlertController, private nav: NavController, private navParams: NavParams, private myGlobals: GlobalService) {
        this.ipWebService  = localStorage.getItem('ipWebService');
        this.portWebService = localStorage.getItem('portWebService');
        //this.readTimeout =localStorage.getItem('readTimeout');
        //this.writeTimeout = localStorage.getItem('writeTimeout');
        //this.userWebService = localStorage.getItem('userWebService');
        //this.passwordWebService = localStorage.getItem('passwordWebService');
    }

    //verificarea username si parola
    onSave() {
        if (this.ipWebService == null && this.portWebService == null) {
            let alert = this.alertCtrl.create({
                title: 'Eroare',
                subTitle: 'Toate campurile trebuie completate!',
                buttons: ['OK']
            });
            alert.present();
            return;
        }
        localStorage.setItem('ipWebService', this.ipWebService);
        localStorage.setItem('portWebService', this.portWebService);
        //localStorage.setItem('readTimeout', this.readTimeout);
        //localStorage.setItem('writeTimeout', this.writeTimeout);
        //localStorage.setItem('userWebService', this.userWebService);
        //localStorage.setItem('passwordWebService', this.passwordWebService);
        this.myGlobals.webService = this.ipWebService + ':' + this.portWebService;
        //this.myGlobals.readTimeout = this.readTimeout;
        //this.myGlobals.writeTimeout = this.writeTimeout;
        //this.myGlobals.auth = btoa(this.userWebService + ':' + this.passwordWebService);
        //this.myGlobals.userWebService = this.userWebService;
        //this.myGlobals.passwordWebService = this.passwordWebService;

        this.nav.pop();
    }

    cancel() {
        this.nav.pop();
    }
}
