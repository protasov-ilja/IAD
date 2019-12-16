import { Component, OnInit } from '@angular/core';
import {BlogData} from '../blog-item/blog-item.component';
import {BlogDto} from '../../dtos/blog/blog.dto';
import {BlogsService} from '../../services/blogs.service';

@Component({
  selector: 'app-search-page',
  templateUrl: './search-page.component.html',
  styleUrls: ['./search-page.component.scss']
})
export class SearchPageComponent implements OnInit {
  public blogs: BlogDto[];

  constructor(private blogsService: BlogsService) {
    blogsService.getAllBlogs().then((blogDtos: BlogDto[]) => {
      if (!blogDtos) {
        return;
      }

      this.blogs = blogDtos;
    });

    // this.blogs = [];
    //
    // for (let i = 0; i < 5; ++i) {
    //   this.blogs.push({
    //     id: i,
    //     isSubscribed: false,
    //     name: `Blog${i}`,
    //     info: 'Lore ipsune Lore ipsune Lore ipsune Lore ipsune Lore ipsune',
    //     imageUri: 'https://material.angular.io/assets/img/examples/shiba1.jpg'
    //   });
    // }
  }

  ngOnInit() {
  }

}
