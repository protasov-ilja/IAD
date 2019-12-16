import {PostDto} from '../post/post.dto';

export interface BlogDataDto {
  id: number;
  name: string;
  info: string;
  userId: number;
  posts: PostDto[];
  isUsersBlog: boolean;
}
