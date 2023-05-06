import Helper from "./categoriesHelper";
import { MENU } from "../../store/categories/actionType";
import { SET_MESSAGE } from "../../store/message/actionType";

export const menu = () => (dispatch) => {
  return Helper.menuHelper().then(
    (response) => {
      dispatch({
        type: MENU,
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
