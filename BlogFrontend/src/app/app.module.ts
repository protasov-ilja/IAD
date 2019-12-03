import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { MaterialDesignModule } from './material-design/material-designal.module';
import { RegistrationComponent } from './pages/registration/registration.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { BlogItemComponent } from './pages/blog-item/blog-item.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { OtherBlogComponent } from './pages/other-blog/other-blog.component';
import { SearchPageComponent } from './pages/search-page/search-page.component';
import { PostComponent } from './pages/profile/post/post.component';
import {MatCardModule, MatIconModule, MatMenuModule, MatSidenavModule, MatToolbarModule} from '@angular/material';
import { CookieService } from 'ngx-cookie-service';
import { AccountService } from './services/account.service';
import { EditProfileComponent } from './pages/edit-profile/edit-profile.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    RegistrationComponent,
    MainPageComponent,
    BlogItemComponent,
    ProfileComponent,
    OtherBlogComponent,
    SearchPageComponent,
    PostComponent,
    EditProfileComponent
  ],
  imports: [
    MaterialDesignModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MatMenuModule,
    MatIconModule,
    MatToolbarModule,
    MatSidenavModule,
    MatCardModule,
  ],
  providers: [
    AccountService,
    CookieService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
