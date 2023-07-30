import { GET_MY_STORE } from "./actionType";

export const getMyStore = () => (dispatch) => {
  dispatch({
    type: GET_MY_STORE,
  });
};

export const addNewStore = () => (dispatch) => {};
