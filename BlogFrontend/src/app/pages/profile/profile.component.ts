import { Component, OnInit } from '@angular/core';
import {PostData} from './post/post.component';

export interface UserBlogData {
  blogId: number;
  name: string;
  info: string;
  imageUri: string;
  userId: number;
}

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})

export class ProfileComponent implements OnInit {
  public posts: PostData[];

  public blogData: UserBlogData;

  constructor() {
    this.blogData = {
      blogId: 1,
      userId: 1,
      name: 'Blog Name',
      info: 'Lore ipsune Lore ipsune Lore ipsune Lore ipsune Lore ipsune',
      imageUri: 'https://material.angular.io/assets/img/examples/shiba2.jpg',
    };

    this.posts = [];

    for (let i = 0; i < 4; ++i) {
      this.posts.push({
        id: i,
        userId: 1,
        title: `Post ${i}`,
        text: 'Post 1 Lore ipsune Lore ipsune Lore ipsune Lore ipsune Lore ipsune',
        date: Date.now(),
        imageUri: 'https://material.angular.io/assets/img/examples/shiba2.jpg',
        likesAmount: 2,
        dislikesAmount: 1
      });
    }
  }

  ngOnInit() {
  }

}
