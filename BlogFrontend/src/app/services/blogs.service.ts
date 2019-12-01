import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import {RegistrationRequestDto} from '../dtos/account/registration-request.dto';
import {AuthResponseDto} from '../dtos/account/auth-response.dto';

@Injectable({
  providedIn: 'root'
})
export class BlogsService extends BaseService {
  private blogControllerUrl = 'api/blog';
  private homeControllerUrl = 'api/home';

  constructor(httpClient: HttpClient, cookieService: CookieService, router: Router) {
    super(httpClient, cookieService, router);
  }

  public async signUp(registrationRequest: RegistrationRequestDto): Promise<boolean> {
    const url = `${ this.homeControllerUrl }/user-subscriptions`;

    const response: AuthResponseDto = await this.post(url, registrationRequest);
    if (!response) {
      return false;
    }

    this.cookieService.set(this.accessTokenField, response.accessToken);
    this.cookieService.set(this.refreshTokenField, response.refreshToken);

    return true;
  }


}
