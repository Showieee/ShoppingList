import { Component } from '@angular/core';
import { NavController, AlertController } from 'ionic-angular';
import { FetchPage } from '../fetch/fetch';


@Component({
    selector: 'page-site',
    templateUrl: 'site.html'
})
export class SitePage {
    sites = [{ 'name': 'asd' }, {'name': 'das' }];
    constructor(public navCtrl: NavController, public alertCtrl: AlertController) {
    }


    addSite() {
        let prompt = this.alertCtrl.create({
            title: 'Santier',
            message: "Adaugati numele santierului.",
            inputs: [
                {
                    name: 'title',
                    placeholder: 'Title'
                },
            ],
            buttons: [
                {
                    text: 'Cancel',
                    handler: data => {
                        prompt.dismiss();
                    }
                },
                {
                    text: 'Save',
                    handler: data => {

                        console.log('Saved clicked');
                    }
                }
            ]
        });
        prompt.present();
    }
    goToSite() {
        this.navCtrl.push(FetchPage);
    }
}
