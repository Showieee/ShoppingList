﻿import { Injectable } from '@angular/core';

@Injectable()
export class GlobalService {
    userId = 1;
    userFirstName = "Anonymous";
    user = 'Anonymous';
    password = '123';
    webService = 'Nothing';
    readTimeout = 15000;
    writeTimeout = 15000;
    auth = "Nothing";
    userWebService = 'Nothing';
    passwordWebService = 'Nothing';
}


