import {LikesDto} from '../like/likes.dto';

export interface PostDto {
  id: number;
  userId: number;
  blogId: number;
  title: string;
  text: string;
  publishDateOnUtc: string;
  likesData: LikesDto;
}
