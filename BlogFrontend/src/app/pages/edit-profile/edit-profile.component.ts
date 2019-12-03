import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

export interface ProfileData {
  blogName: string;
  blogInfo: string;
  userLogin: string;
  userPassword: string;
  firstName: string;
  lastName: string;
}

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent implements OnInit {
  public profile: ProfileData;

  constructor(private router: Router) {
    this.profile = {
      blogName: 'Blog1',
    blogInfo: 'Lore ipsun Lore ipsun Lore ipsun Lore ipsun Lore ipsun',
    userLogin: 'user_login',
    userPassword: 'user_password',
    firstName: 'first Name of user',
    lastName: 'last name of user',
    };
  }

  ngOnInit() {
  }

  public save() {
    this.router.navigate(['/profile']);
  }
}
