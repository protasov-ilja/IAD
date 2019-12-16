import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {BlogDto} from '../../dtos/blog/blog.dto';
import {BlogsService} from '../../services/blogs.service';
import {MatSnackBar} from '@angular/material';

export interface BlogData {
  id: number;
  name: string;
  imageUri: string;
  info: string;
  isSubscribed: boolean;
}

@Component({
  selector: 'app-blog-item',
  templateUrl: './blog-item.component.html',
  styleUrls: ['./blog-item.component.scss']
})
export class BlogItemComponent implements OnInit {
  @Input() blog: BlogDto;

  constructor(private router: Router, private blogsService: BlogsService, private snackBar: MatSnackBar) { }

  ngOnInit() {
  }

  public subscribe() {
    this.blogsService.subscribeOnBlog(this.blog.id).then((bool: boolean) => {
      if (!bool) {
        this.snackBar.open('Error cant subscribed!', null, {
          duration: 2000
        });
      } else {

        this.blog.alreadySubscribed = true;
        window.location.reload();
      }
    });
  }

  public unsubscribe() {
    this.blogsService.unsubscribeOnBlog(this.blog.id).then((bool: boolean) => {
      if (!bool) {
        this.snackBar.open('Error cant unsubscribed!', null, {
          duration: 2000
        });
      } else {
        this.blog.alreadySubscribed = false;
        window.location.reload();
      }
    });
  }

  public readBlog() {
    this.blogsService.getIsUserBlog(this.blog.id).then((bool: boolean) => {
      if (!bool) {
        this.router.navigate(['/other-blog']);
      } else {
        this.router.navigate(['/profile']);
      }
    });
    // this.router.navigate(['/profile'], {state: {data: blogId}});
    // <a [routerLink]=”/b” [state]=”{ data: {...}}”>Go to B</a>
  }
}
