import { NgModule, ErrorHandler } from '@angular/core';
import { HttpModule, JsonpModule } from '@angular/http';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { MyApp } from './app.component';
import { AboutPage } from '../pages/about/about';
import { LoginPage } from '../pages/login/login';
import { LoginService } from '../pages/login/loginService';
import { SitePage } from '../pages/site/site';
import { FetchPage } from '../pages/fetch/fetch';
import { GlobalService } from '../pages/helpers/globals';
import { SettingsPage } from '../pages/settings/settings';

@NgModule({
    declarations: [
        MyApp,
        AboutPage,
        LoginPage,
        SitePage,
        FetchPage,
        SettingsPage
    ],
    imports: [
        IonicModule.forRoot(MyApp),
        HttpModule
    ],
    bootstrap: [IonicApp],
    entryComponents: [
        MyApp,
        AboutPage,
        LoginPage,
        SitePage,
        FetchPage,
        SettingsPage
    ],
    providers: [{ provide: ErrorHandler, useClass: IonicErrorHandler }, GlobalService, LoginService]
})
export class AppModule { }
