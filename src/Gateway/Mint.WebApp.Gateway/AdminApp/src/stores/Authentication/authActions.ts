import { ISignIn } from "../../types/Authentication/ISignIn";
import {logoutRequest, signInRequest} from "../../services/authentication/authService";
import {LOGIN_FAIL, LOGIN_SUCCESS, LOGOUT} from "./actionType";
import { IRequest } from "../../hooks/useAxios";
import {clearMessage, setMessage} from "../Message/messageActions";

export const signInStore = (axios: IRequest, values: ISignIn) => (dispatch) => {
  return signInRequest(axios, values).then(
    (response) => {
      dispatch({
          type: LOGIN_SUCCESS,
          payload: response,
      });
      dispatch(clearMessage());
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
      dispatch(setMessage(message));
      return Promise.reject();
    }
  );
};

export const signOutStore = (navigate) => (dispatch) => {
    logoutRequest(navigate);
    dispatch({
        type: LOGOUT,
    });
};
