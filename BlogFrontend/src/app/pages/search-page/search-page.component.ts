import { Component, OnInit } from '@angular/core';
import {BlogData} from '../blog-item/blog-item.component';

@Component({
  selector: 'app-search-page',
  templateUrl: './search-page.component.html',
  styleUrls: ['./search-page.component.scss']
})
export class SearchPageComponent implements OnInit {
  public blogs: BlogData[];

  constructor() {
    this.blogs = [];

    for (let i = 0; i < 5; ++i) {
      this.blogs.push({
        id: i,
        isSubscribed: false,
        name: `Blog${i}`,
        info: 'Lore ipsune Lore ipsune Lore ipsune Lore ipsune Lore ipsune',
        imageUri: 'https://material.angular.io/assets/img/examples/shiba1.jpg'
      });
    }
  }

  ngOnInit() {
  }

}
