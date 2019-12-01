import {Component, Input, OnInit} from '@angular/core';

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

  constructor() { }

  ngOnInit() {
  }
}
