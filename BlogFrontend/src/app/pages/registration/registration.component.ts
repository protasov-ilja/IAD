import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { RegistrationRequestDto } from '../../dtos/account/registration-request.dto';
import { MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})

export class RegistrationComponent implements OnInit {
  public registrationData: RegistrationRequestDto;

  constructor(private accountService: AccountService, private snackBar: MatSnackBar, private router: Router) {
    this.registrationData = {} as RegistrationRequestDto;
  }

  ngOnInit() {
  }

  public async register(): Promise<void> {
    console.log(this.registrationData);

    const isSuccess = await this.accountService.signUp(this.registrationData);
    if (isSuccess) {
      this.snackBar.open('Successffuly registrated!', null, {
        duration: 2000
      });
      this.router.navigate([`/home`]);
    } else {
      this.snackBar.open('Ops, sth went wrong! Please try later', null, {
        duration: 2000
      });
    }
  }

  public async login(): Promise<void> {
    this.router.navigateByUrl('/login');
  }
}
