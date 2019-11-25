import { Component, OnInit } from '@angular/core';
import { AuthRequestDto } from '../../dtos/account/auth-request.dto';
import { AccountService } from '../../services/account.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {
  public loginData: AuthRequestDto;

  constructor(private accountService: AccountService,
              private snackBar: MatSnackBar,
              private router: Router) {
    this.loginData = {} as AuthRequestDto;
  }

  ngOnInit() {
  }

  public async authorize(): Promise<void> {
    const isSuccess = await this.accountService.authenticate(this.loginData);
    if (isSuccess) {
      this.snackBar.open('Successfully authorized!', null, {
        duration: 200
      });

      this.router.navigate([`/home`]);
    } else {
      this.snackBar.open('Wrong data!', null, {
        duration: 2000
      });
    }
  }

  public async register(): Promise<void> {
    this.router.navigateByUrl('/register');
  }
}
