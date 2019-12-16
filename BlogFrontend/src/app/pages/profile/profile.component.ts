import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {BlogsService} from '../../services/blogs.service';
import {BlogDataDto} from '../../dtos/blog/blog-data.dto';
import {PostDto} from '../../dtos/post/post.dto';
import {PostCreationDto} from '../../dtos/post/post-creation.dto';
import {NgForm} from '@angular/forms';
import {LikesDto} from '../../dtos/like/likes.dto';
import {AccountService} from '../../services/account.service';
import {MatSnackBar} from '@angular/material';

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
  public posts: PostDto[];

  public blogData: BlogDataDto;

  constructor(private router: Router, private blogsService: BlogsService, private snackBar: MatSnackBar) {
    this.blogsService.getUserBlogData().then((data: BlogDataDto) => {
      if (!data) {
        return;
      }

      this.blogData = data;
      if (!this.blogData.name) {
        this.blogData.name = 'standart name';
      }

      this.posts = data.posts;
    });

    // this.blogData = {
    //   blogId: 1,
    //   userId: 1,
    //   name: 'Blog Name',
    //   info: 'Lore ipsune Lore ipsune Lore ipsune Lore ipsune Lore ipsune',
    //   imageUri: 'https://material.angular.io/assets/img/examples/shiba2.jpg',
    // };
    //
    // this.posts = [];
    //
    // for (let i = 0; i < 4; ++i) {
    //   this.posts.push({
    //     id: i,
    //     userId: 1,
    //     title: `Post ${i}`,
    //     text: 'Post 1 Lore ipsune Lore ipsune Lore ipsune Lore ipsune Lore ipsune',
    //     date: Date.now(),
    //     imageUri: 'https://material.angular.io/assets/img/examples/shiba2.jpg',
    //     likesAmount: 2,
    //     dislikesAmount: 1
    //   });
    // }
  }

  ngOnInit() {

  }

  public edit() {
    this.router.navigate(['/profile/edit']);
  }

  public createPost(form: NgForm) {
    const post = {
      title: form.value.title,
      text: form.value.text,
      publishDateInUtc: '',
      blogId: this.blogData.id,
    } as PostCreationDto;
    console.log('post: ' + post.blogId);
    this.blogsService.createPost(post).then((bool: boolean) => {
      if (!bool) {
        this.snackBar.open('Post not created!', null, {
          duration: 2000
        });
      } else {
        window.location.reload();
        this.router.navigate(['/profile']);
      }
    });
  }
}
