import { Component, OnInit } from '@angular/core';
import {PostDto} from '../../dtos/post/post.dto';
import {BlogDataDto} from '../../dtos/blog/blog-data.dto';
import {Router} from '@angular/router';
import {BlogsService} from '../../services/blogs.service';
import {NgForm} from '@angular/forms';
import {PostCreationDto} from '../../dtos/post/post-creation.dto';

@Component({
  selector: 'app-other-blog',
  templateUrl: './other-blog.component.html',
  styleUrls: ['./other-blog.component.scss']
})
export class OtherBlogComponent implements OnInit {
  public posts: PostDto[];

  public blogData: BlogDataDto;

  constructor(private router: Router, private blogsService: BlogsService) {
    this.blogsService.getBlogData().then((data: BlogDataDto) => {
      if (!data) {
        return;
      }

      this.blogData = data;
      if (!this.blogData.name) {
        this.blogData.name = 'standart blog name';
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
}
