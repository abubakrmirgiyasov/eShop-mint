import Request from "../../helpers/requestWrapper/request";
import { IUser } from "../types/IUser";

export interface ISignUp {
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

export interface ISignIn {
  email: string;
  password: string;
}

export const register = (request: Request, values: ISignUp) => {
  return request
    .post("/identity/authentication/signUp", values)
    .then((response) => {
      return response;
    })
    .catch((error) => {
      throw error;
    });
};

export const login = (request: Request, values: ISignIn) => {
  return request
    .post("/identity/authentication/signIn", values)
    .then((response: IUser) => {
      if (response.accessToken)
        localStorage.setItem("auth_user", JSON.stringify(response));
      return response;
    })
    .catch((error) => {
      throw error;
    });
};

export const logout = (request: Request) => {
  return request
    .delete("/identity/authentication/signOut")
    .then((response: { message: string }) => {
      if (response.message) localStorage.removeItem("auth_user");
    })
    .catch((error) => {
      throw error;
    });
};

export const updateUser = (request: Request, values: IUser) => {
  return request
    .put("/identity/user/updateUser", values)
    .then((response: IUser) => {
      localStorage.setItem("auth_user", JSON.stringify(response));
      return response;
    })
    .catch((error) => {
      throw error;
    });
};

export const refreshToken = (request: Request, values: IUser) => {
  return request
    .post("/identity/authentication/refreshToken", values)
    .then((response: IUser) => {
      localStorage.setItem("auth_user", JSON.stringify(response));
      return response;
    })
    .catch((error) => {
      throw error;
    });
};
