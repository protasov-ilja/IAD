import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {BlogDto} from '../../dtos/blog/blog.dto';

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

  constructor(private router: Router) { }

  ngOnInit() {
  }

  public subscribe(blogId: number) {
    this.blog.alreadySubscribed = true;
  }

  public unsubscribe(blogId: number) {
    this.blog.alreadySubscribed = false;
  }

  public readBlog(blogId: number) {
    this.router.navigate(['/profile'], {state: {data: blogId}});
    // <a [routerLink]=”/b” [state]=”{ data: {...}}”>Go to B</a>
  }
}
