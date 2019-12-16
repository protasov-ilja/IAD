import {Injectable} from '@angular/core';
import {BaseService} from './base.service';
import {HttpClient, HttpParams} from '@angular/common/http';
import {CookieService} from 'ngx-cookie-service';
import {Router} from '@angular/router';
import {RegistrationRequestDto} from '../dtos/account/registration-request.dto';
import {AuthResponseDto} from '../dtos/account/auth-response.dto';
import {BlogDto} from '../dtos/blog/blog.dto';
import {BlogDataDto} from '../dtos/blog/blog-data.dto';
import {PostCreationDto} from '../dtos/post/post-creation.dto';

@Injectable({
  providedIn: 'root'
})
export class BlogsService extends BaseService {
  public currentBlogId: number;

  private blogControllerUrl = 'api/blog';
  private homeControllerUrl = 'api/home';
  private blogsSearchControllerUrl = 'api/blogssearch';

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

  public async getUserSubscriptions(): Promise<BlogDto[]> {
    const url = `${this.homeControllerUrl}/user-subscriptions`;

    return await this.get(url);
  }

  public async getAllBlogs(): Promise<BlogDto[]> {
    const url = `${ this.blogsSearchControllerUrl }/all`;

    return await this.get(url);
  }

  public async getUserBlogData(): Promise<BlogDataDto> {
    const url = `${ this.blogControllerUrl }/show-user-blog`;

    return await this.get(url);
  }

  public async getBlogData(): Promise<BlogDataDto> {
    const url = `${ this.blogControllerUrl }/show-blog`;

    return await this.getWithParams(url, new HttpParams().set('blogId', this.currentBlogId.toString()));
  }

  public async getIsUserBlog(blogId: number): Promise<boolean> {
    const url = `${ this.blogControllerUrl }/is-user-blog`;
    this.currentBlogId = blogId;

    return await this.getWithParams(url, new HttpParams().set('blogId', blogId.toString()));
  }

  public async createPost(dto: PostCreationDto): Promise<boolean> {
    const url = `${ this.blogControllerUrl }/create-post-n`;

    return await this.post(url, dto);
  }

  public async subscribeOnBlog(blogId: number): Promise<boolean> {
    const url = `${ this.blogControllerUrl }/subscribe`;

    return await this.post(url, blogId);
  }

  public async unsubscribeOnBlog(blogId: number): Promise<boolean> {
    const url = `${ this.blogControllerUrl }/unsubscribe`;

    return await this.post(url, blogId);
  }
}
