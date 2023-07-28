import { CLEAR_MESSAGE, SET_MESSAGE } from "./actionType";

export const setMessage = (message) => (dispatch) => {
  dispatch({
    type: SET_MESSAGE,
    payload: message,
  });
};

export const clearMessage = () => (dispatch) => {
  dispatch({
    type: CLEAR_MESSAGE,
  });
};
