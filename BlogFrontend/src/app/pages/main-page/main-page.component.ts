import { Component, OnInit } from '@angular/core';
import {BlogData} from '../blog-item/blog-item.component';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {
  public subscribedBlogs: BlogData[];

  constructor() {
    this.subscribedBlogs = [];

    for (let i = 0; i < 5; i++) {
      this.subscribedBlogs.push({
        id: i,
        name: `Blog ${i}`,
        info: 'Lore ipsune Lore ipsune Lore ipsune Lore ipsune Lore ipsune',
        imageUri: 'https://material.angular.io/assets/img/examples/shiba1.jpg',
        isSubscribed: true
      });
    }
  }

  ngOnInit() {
  }

}
