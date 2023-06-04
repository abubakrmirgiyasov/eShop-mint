import Helper from "./productHelper";
import { GET_ALL_PRODCUTS } from "../../store/products/actionType";
import { SET_MESSAGE } from "../../store/message/actionType";

export const products = () => (dispatch) => {
  return Helper.productHelper().then(
    (response) => {
      dispatch({
        type: GET_ALL_PRODCUTS,
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
