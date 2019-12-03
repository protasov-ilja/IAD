import {Component, Input, OnInit} from '@angular/core';
import DateTimeFormat = Intl.DateTimeFormat;

export interface PostData {
  id: number;
  userId: number;
  title: string;
  text: string;
  date: number;
  imageUri: string;
  likesAmount: number;
  dislikesAmount: number;
}

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {

  @Input() post: PostData;

  constructor() { }

  ngOnInit() {
  }

  public setLike() {
    this.post.likesAmount++;
  }

  public setDislike() {
    this.post.dislikesAmount++;
  }
}
