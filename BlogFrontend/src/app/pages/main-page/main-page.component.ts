import { Component, OnInit } from '@angular/core';
import {BlogData} from '../blog-item/blog-item.component';
import {Router} from '@angular/router';
import {BlogsService} from '../../services/blogs.service';
import {BlogDto} from '../../dtos/blog/blog.dto';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {
  public subscribedBlogs: BlogDto[];

  constructor(private blogsService: BlogsService, private router: Router) {
    blogsService.getUserSubscriptions().then((blogDtos: BlogDto[]) => {
      if (!blogDtos) {
        return;
      }

      this.subscribedBlogs = blogDtos;
    });

    // this.subscribedBlogs = [];
    //
    // for (let i = 0; i < 5; i++) {
    //   this.subscribedBlogs.push({
    //     id: i,
    //     name: `Blog ${i}`,
    //     info: 'Lore ipsune Lore ipsune Lore ipsune Lore ipsune Lore ipsune',
    //     imageUri: 'https://material.angular.io/assets/img/examples/shiba1.jpg',
    //     isSubscribed: true
    //   });
    // }
  }

  ngOnInit() {
  }

  public showBlog(blogId: number) {
    this.blogsService.getIsUserBlog(blogId).then((bool: boolean) => {
      if (!bool) {
        this.router.navigate(['/other-blog']);
      } else {
        this.router.navigate(['/profile']);
      }
    });
  }
}
