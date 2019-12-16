import { Component } from '@angular/core';
import {CookieService} from 'ngx-cookie-service';
import {AccountService} from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'BlogFrontend';

  constructor(private accountService: AccountService) {

  }

  public isAuthorized(): boolean {
    return this.accountService.isAuthorized();
  }
}
