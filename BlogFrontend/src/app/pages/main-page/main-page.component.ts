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

  constructor(private blogsService: BlogsService) {
    blogsService.getUserSubscriptions().then((blogDtos: BlogDto[]) => {
      if (!blogDtos) {
        return;
      }
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

}
