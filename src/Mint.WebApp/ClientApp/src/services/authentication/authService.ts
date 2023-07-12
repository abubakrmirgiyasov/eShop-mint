import Request from "../../helpers/requestWrapper/request";
import { IUser } from "../types/IUser";

interface ISignUp {
  firstName: string;
  secondName: string;
  lastName?: string;
  email: string;
  phone: number;
  password: string;
  dateBirth: Date;
  gender: string;
  photo?: FormData;
}

interface ISignIn {
  email: string;
  password: string;
}

const register = (request: Request, values: ISignUp) => {
  return request
    .post("/authentication/signup", values)
    .then((response) => response)
    .catch((error) => error);
};

const login = (request: Request, values: ISignIn) => {
  return request
    .post("/authentication/signin", values)
    .then((response: IUser) => {
      if (response.accessToken)
        localStorage.setItem("auth_user", JSON.stringify(response));
      return response;
    })
    .catch((error) => error);
};

const logout = () => {};

export { register, login, logout, ISignUp, ISignIn };
