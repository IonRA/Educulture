import { Injectable } from '../../../node_modules/@angular/core';
import { MatSnackBar } from '@angular/material';

@Injectable()

export class NotificationService {

    constructor(
        private _snackBar: MatSnackBar) { }

    openSnackBar(message: string, action: string = "Close") {
        this._snackBar.open(message, action, {
            duration: 2000,
        });
    }

}