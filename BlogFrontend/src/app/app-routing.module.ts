import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import {MainPageComponent} from './pages/main-page/main-page.component';
import {ProfileComponent} from './pages/profile/profile.component';
import {SearchPageComponent} from './pages/search-page/search-page.component';
import {EditProfileComponent} from './pages/edit-profile/edit-profile.component';
import {OtherBlogComponent} from './pages/other-blog/other-blog.component';
import {LogOutComponent} from './pages/log-out/log-out.component';


const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegistrationComponent },
  { path: 'main', component: MainPageComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'blogs', component: SearchPageComponent },
  { path: 'profile/edit', component : EditProfileComponent },
  { path: 'other-blog', component : OtherBlogComponent },
  { path: 'log-out', component : LogOutComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(
    routes,
    { enableTracing: true }) // <-- debugging purposes only
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
