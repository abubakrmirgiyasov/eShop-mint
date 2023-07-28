import {
  login,
  register,
  logout,
  updateUser as update,
  refreshToken as refresh,
  ISignUp,
  ISignIn,
} from "../../services/authentication/authService";
import Request from "../../helpers/requestWrapper/request";
import {
  LOGIN_FAIL,
  LOGIN_SUCCESS,
  LOGOUT,
  REFRESH_TOKEN,
  REGISTER_FAIL,
  REGISTER_SUCCESS,
  UPDATE_USR,
} from "./actionType";
import { SET_MESSAGE } from "../message/actionType";
import { IUser } from "../../services/types/IUser";

export const signUp = (request: Request, values: ISignUp) => (dispatch) => {
  return register(request, values).then(
    (response) => {
      dispatch({
        type: REGISTER_SUCCESS,
      });

      dispatch({
        type: SET_MESSAGE,
        payload: response.data.message,
      });

      return Promise.resolve();
    },
    (error) => {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();

      dispatch({
        type: REGISTER_FAIL,
      });

      dispatch({
        type: SET_MESSAGE,
        payload: message,
      });

      return Promise.reject();
    }
  );
};

export const signIn = (request: Request, values: ISignIn) => (dispatch) => {
  return login(request, values).then(
    (response) => {
      dispatch({
        type: LOGIN_SUCCESS,
        payload: { user: response },
      });

      return Promise.resolve();
    },
    (error) => {
      console.log(error);
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();

      dispatch({
        type: LOGIN_FAIL,
      });

      dispatch({
        type: SET_MESSAGE,
        payload: message,
      });

      return Promise.reject();
    }
  );
};

export const signOut = (request: Request) => (dispatch) => {
  return logout(request).then(
    () => {
      dispatch({
        type: LOGOUT,
      });
      return Promise.resolve();
    },
    (error) => {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();

      dispatch({
        type: SET_MESSAGE,
        payload: message,
      });

      return Promise.reject();
    }
  );
};

export const updateUser = (request: Request, values: IUser) => (dispatch) => {
  return update(request, values).then(
    (response) => {
      dispatch({
        type: UPDATE_USR,
        payload: { user: response },
      });
      return Promise.resolve();
    },
    (error) => {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();

      dispatch({
        type: SET_MESSAGE,
        payload: message,
      });

      return Promise.reject();
    }
  );
};

export const refreshToken = (request: Request, values: IUser) => (dispatch) => {
  return refresh(request, values).then(
    (response) => {
      dispatch({
        type: REFRESH_TOKEN,
        payload: { user: response },
      });
      return Promise.resolve();
    },
    (error) => {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();

      dispatch({
        type: SET_MESSAGE,
        payload: message,
      });

      return Promise.reject();
    }
  );
};
