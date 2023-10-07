import {ISignIn} from "../../types/Authentication/ISignIn";
import {signInRequest} from "../../services/authentication/authService";
import {LOGIN_FAIL, LOGIN_SUCCESS} from "./actionType";
import {SET_MESSAGE} from "../Message/actionType";

export const signInStore = (values: ISignIn) => (dispatch) => {
    return signInRequest(values).then((response) => {
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
            });

            dispatch({
                type: SET_MESSAGE,
                payload: message,
            });
            return Promise.reject();
        });
};


