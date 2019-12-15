import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthResponseDto } from '../dtos/account/auth-response.dto';
import { CookieService } from 'ngx-cookie-service';
import {UpdateTokensRequestDto} from '../dtos/account/update-tokens-request.dto';

export interface Response<R> {
  httpStatus: number;
  errorInfo: string;
  result: R;
}

export class BaseService {
  protected accessTokenField = 'accessToken';
  protected refreshTokenField = 'refreshToken';
  private accountBaseUrl = 'api/account';

  constructor(private http: HttpClient, protected cookieService: CookieService, private router: Router) {
  }

  protected async get<HttpResult>(url: string): Promise<HttpResult> {
    let response: Response<HttpResult> = await this.tryGet(url);

    if (response.httpStatus === 200) {// TODO: add constants class
      return response.result;
    }

    if (response.httpStatus !== 401) {
      return null;
    }

    const isTokensUpdated: boolean = await this.updateTokens();
    if (!isTokensUpdated) {
      await this.router.navigate([`/login`]);
      // throw 'You are not authorized';
    }

    response = await this.tryGet(url);
    if (response.httpStatus === 200) {
      return response.result;
    } else {
      await this.router.navigate([`/login`]);
      // throw 'You are not authorized';
    }
  }

  protected async post<HttpRequest, HttpResponse>(url: string, request: HttpRequest): Promise<HttpResponse> {
    let response: Response<HttpResponse> = await this.tryPost(url, request);

    if (response.httpStatus === 200) {
      return response.result;
    }

    if (response.httpStatus !== 401) {
      return null;
    }

    const isTokensUpdated: boolean = await this.updateTokens();
    if (!isTokensUpdated) {
      await this.router.navigate([`/login`]);
      // throw 'You are not authorized';
    }

    response = await this.tryPost(url, request);
    if (response.httpStatus === 200) {
      return response.result;
    } else {
      await this.router.navigate([`/login`]);
      // throw 'You are not authorized';
    }
  }

  private async tryGet<HttpR>(url: string): Promise<Response<HttpR>> {
    const httpOptions = this.generateHttpOptions();

    const result = {
      result: null,
    } as Response<HttpR>;

    try {
      const response: HttpR = await this.http.get<HttpR>(url, httpOptions).toPromise();
      result.httpStatus = 200;
      result.result = response;
    } catch (error) {
      result.httpStatus = error.status;
    }

    return result;
  }

  private async tryPost<HttpRequest, HttpResponse>(url: string, request: HttpRequest): Promise<Response<HttpResponse>> {
    const httpOptions = this.generateHttpOptions();

    const result = {
      result: null,
    } as Response<HttpResponse>;

    try {
      const response: HttpResponse = await this.http.post<HttpResponse>(url, request, httpOptions).toPromise();
      result.httpStatus = 200;
      result.result = response;
    } catch (error) {
      result.httpStatus = error.status;
    }

    return result;
  }

  private async updateTokens(): Promise<boolean> {
    const accountUrl = `${this.accountBaseUrl}/update-tokens`;
    const refreshT = this.cookieService.get(this.refreshTokenField);
    const dto = { refreshToken: refreshT } as UpdateTokensRequestDto;
    console.log('updateTokens');
    console.log(refreshT);

    const newTokenResponse: Response<AuthResponseDto> = await this.tryPost(accountUrl, dto);
    if (!newTokenResponse.result) {
      return false;
    }

    const newTokens = newTokenResponse.result;
    this.cookieService.set(this.accessTokenField, newTokens.accessToken);
    this.cookieService.set(this.refreshTokenField, newTokens.refreshToken);

    return true;
  }

  private generateHttpOptions(): { headers: HttpHeaders } {
    let accessToken = this.cookieService.get(this.accessTokenField);
    if (!accessToken) {
      accessToken = '';
    }

    return {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${ accessToken }`
      }),
    };
  }
}
