import {
  LOGOUT,
  REFRESH_TOKEN,
  SIGNIN as SIGIN_IN,
} from "../store/signin/actionType";
import { SET_MESSAGE } from "../store/message/actionType";
import AuthHelper from "./signinHelper";

export const signin = (values) => (dispatch) => {
  return AuthHelper.signinHelper(values).then(
    (response) => {
      dispatch({
        type: SIGIN_IN,
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

export const signout = () => (dispatch) => {
  AuthHelper.signoutHelper();
  dispatch({ type: LOGOUT });
};

export const refreshToken = () => (dispatch) => {
  console.log("first")
  return AuthHelper.refreshTokenHelper().then(
    (response) => {
      dispatch({
        type: REFRESH_TOKEN,
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
        type: SET_MESSAGE,
        payload: message,
      });
      return Promise.reject();
    }
  );
};
