import { IUser } from "./IUser";

export interface IAuth {
  isLoggedIn: boolean;
  user: IUser;
}
