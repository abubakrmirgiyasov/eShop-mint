import {SET_MESSAGE, CLEAR_MESSAGE} from "../Message/actionType";

export const setMessage = (message: string) => (dispatch) => {
    dispatch({
        type: SET_MESSAGE,
        payload: message,
    });
}

export const clearMessage = () => (dispatch) => {
    dispatch({
        type: CLEAR_MESSAGE,
        payload: null,
    });
}
