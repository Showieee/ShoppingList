import { Component } from '@angular/core';

import { NavController, AlertController } from 'ionic-angular';
import { Product } from '../fetch/product';
import { GlobalService } from '../helpers/globals';

@Component({
    selector: 'page-fetch',
    templateUrl: 'fetch.html'
})
export class FetchPage {
    products: Array<Product>;
    constructor(public navCtrl: NavController, public alertCtrl: AlertController, public myGlobals: GlobalService) {
        this.products = [
            { 'id': 1, 'idSite': 1, 'name': 'Suruburi M20', 'quantity': '10', 'site': 'Queens', 'driver': '', 'isReserved': false },
            { 'id': 2, 'idSite': 1, 'name': 'Ceva', 'quantity': '15', 'site': 'Queens', 'driver': '', 'isReserved': false },
            { 'id': 3, 'idSite': 1, 'name': 'Altceva', 'quantity': '98', 'site': 'Queens', 'driver': '', 'isReserved': false }
        ];
    }

    reserve(item: Product) {
        item.isReserved = !item.isReserved;
        if (item.isReserved == true) {
            item.driver = this.myGlobals.user;
        } else {
            item.driver = '';
        }

    }

    addOrder() {
        let prompt = this.alertCtrl.create({
            title: 'Adaugare produs',
            inputs: [
                {
                    name: 'title',
                    placeholder: 'Produs'
                },
                {
                    name: 'quantity',
                    placeholder: 'cantitate'
                },
            ],
            buttons: [
                {
                    text: 'Cancel',
                    handler: data => {
                        console.log('Cancel clicked');
                    }
                },
                {
                    text: 'Save',
                    handler: data => {
                        this.products.push({ 'id': this.products.length+1, 'idSite': 1, 'name': data.title, 'quantity': data.quantity, 'site': 'Queens', 'driver': '', 'isReserved': false })
                        console.log('Saved clicked');
                    }
                }
            ]
        });
        prompt.present();
    }

}
