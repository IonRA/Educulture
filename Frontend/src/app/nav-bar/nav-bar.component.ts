import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import {FormControl, Validators, FormGroup} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  constructor(public dialog: MatDialog,
    private router: Router) {}

  ngOnInit() {
  }

  openDialog(dialogName: string) {
    const dialogRef = this.dialog.open(dialogName === "login" ? LogInDialog : SignUpDialog, {
      width: '450px'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  goTo(address) {
    this.router.navigate(['/' + address]);
  }

}

@Component({
  selector: 'log-in-dialog',
  templateUrl: 'log-in-dialog.html',
})
export class LogInDialog {
  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required]);

  getEmailErrorMessage() {
    return this.email.hasError('required') ? 'You must enter a value' :
        this.email.hasError('email') ? 'Not a valid email' :
            '';
  }

  getPasswordErrorMessage() {
    return this.password.hasError('required') ? 'You must enter a value' :
            '';
  }
}

@Component({
  selector: 'sign-up-dialog',
  templateUrl: 'sign-up-dialog.html',
})
export class SignUpDialog {
  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required]);
  passwordCheck = new FormControl('', [Validators.required]);
  form = new FormGroup({
    email: this.email,
    password: this.password,
    passwordCheck: this.passwordCheck
   })

  getEmailErrorMessage() {
    return this.email.hasError('required') ? 'You must enter a value' :
        this.email.hasError('email') ? 'Not a valid email' :
            '';
  }

  getPasswordErrorMessage() {
    return this.password.hasError('required') ? 'You must enter a value' :
            '';
  }

  getPasswordCheckErrorMessage() {
    return this.passwordCheck.hasError('required') ? 'You must enter a value' :
        this.passwordCheck.hasError('notMatched') ? 'Passwords do not match' :
            '';
  }

  equalPasswords(): boolean {

    const matched: boolean = this.password.value === this.passwordCheck.value;

    console.log('equaltest', matched);

    if (matched) {
        this.form.controls.passwordCheck.setErrors(null);
    } else {
        this.form.controls.passwordCheck.setErrors({
           notMatched: true
        });
    }

    return matched;
  }
}
