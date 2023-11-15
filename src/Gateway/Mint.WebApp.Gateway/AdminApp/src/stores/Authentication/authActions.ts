import { ISignIn } from "../../types/Authentication/ISignIn";
import { signInRequest } from "../../services/authentication/authService";
import { LOGIN_FAIL, LOGIN_SUCCESS } from "./actionType";
import { IRequest } from "../../hooks/useAxios";

export const signInStore = (axios: IRequest, values: ISignIn) => (dispatch) => {
  return signInRequest(axios, values).then(
    (response) => {
      dispatch({
          type: LOGIN_SUCCESS,
          payload: response,
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
          payload: { message },
      });
      return Promise.reject();
    }
  );
};
