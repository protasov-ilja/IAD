import {Component, Input, OnInit} from '@angular/core';
import DateTimeFormat = Intl.DateTimeFormat;
import {Router} from '@angular/router';
import {BlogsService} from '../../../services/blogs.service';
import {PostDto} from '../../../dtos/post/post.dto';

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

  @Input() post: PostDto;

  constructor(private router: Router, private blogsService: BlogsService) { }

  ngOnInit() {
  }

  public setLike() {
    this.post.likesData.positiveLikes++;
  }

  public setDislike() {
    this.post.likesData.negativeLikes++;
  }
}
