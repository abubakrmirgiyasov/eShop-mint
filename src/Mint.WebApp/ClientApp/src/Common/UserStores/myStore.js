import Helper from "./myStoreHelper";
import { MY_STORE } from "../../store/userStore/actionType";
import { SET_MESSAGE } from "../../store/message/actionType";

export const myStore = () => (dispatch) => {
  return Helper.myStoreHelper().then(
    (response) => {
      dispatch({
        type: MY_STORE,
        payload: response,
      });
      return Promise.resolve();
    },
    (error) => {
      dispatch({
        type: SET_MESSAGE,
        payload: error,
      });
      return Promise.reject();
    }
  );
};
