import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

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
  @Input() blog: BlogData;

  constructor(private router: Router) { }

  ngOnInit() {
  }

  public subscribe(blogId: number) {
    this.blog.isSubscribed = true;
  }

  public unsubscribe(blogId: number) {
    this.blog.isSubscribed = false;
  }

  public readBlog(blogId: number) {
    this.router.navigate(['/profile'], {state: {data: blogId}});
    // <a [routerLink]=”/b” [state]=”{ data: {...}}”>Go to B</a>
  }
}
