import { IUser } from "../types/IUser";

export default function authHeader(): string {
  const user: IUser = JSON.parse(localStorage.getItem("auth_user"));
  return user && user.accessToken ? user.accessToken : "";
}
