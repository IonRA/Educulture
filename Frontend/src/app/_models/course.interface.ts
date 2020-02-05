import { User } from './user.interface';

export interface Course {
  id?: number;
  name?: string;
  details?: string;
  tags?: string;
  userId?: number;
  user?: User;
}
