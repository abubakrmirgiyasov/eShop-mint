import {
  login,
  register,
  logout,
  ISignUp,
  ISignIn,
} from "../../services/authentication/authService";
import Request from "../../helpers/requestWrapper/request";
import {
  LOGIN_FAIL,
  LOGIN_SUCCESS,
  LOGOUT,
  REGISTER_FAIL,
  REGISTER_SUCCESS,
} from "./actionType";
import { SET_MESSAGE } from "../message/actionType";

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

export const signOut = () => (dispatch) => {
  logout();

  dispatch({
    type: LOGOUT,
  });
};
