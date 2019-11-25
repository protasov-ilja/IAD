import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { RegistrationRequestDto } from '../dtos/account/registration-request.dto';
import { AuthRequestDto } from '../dtos/account/auth-request.dto';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthResponseDto } from '../dtos/account/auth-response.dto';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})

export class AccountService extends BaseService {
  private accountUrl = 'api/account';

  constructor(httpClient: HttpClient, cookieService: CookieService, router: Router) {
    super(httpClient, cookieService, router);
  }

  public async signUp(registrationRequest: RegistrationRequestDto): Promise<boolean> {
    const url = `{this.accountUrl}/sign-up`;

    const response: AuthResponseDto = await this.post(url, registrationRequest);
    if (!response) {
      return false;
    }

    this.cookieService.set(this.accessTokenField, response.accessToken);
    this.cookieService.set(this.refreshTokenField, response.refreshToken);

    return true;
  }

  public async authenticate(authRequest: AuthRequestDto): Promise<boolean> {
    const url = `${this.accountUrl}/auth`;

    const response: AuthResponseDto = await this.post(url, authRequest);
    if (!response) {
      return false;
    }

    this.cookieService.set(this.accessTokenField, response.accessToken);
    this.cookieService.set(this.refreshTokenField, response.refreshToken);

    return true;
  }
}
