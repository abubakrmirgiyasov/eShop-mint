import { SET_MESSAGE } from "../../store/message/actionType";
import Helper from "./likesHelper";
import {removeLike as rl, toggleLike as tl, newLike as nl} from "../../store/liked";

export const toggleLikes = (id) => (dispatch) => {
  return Helper.toggleLikes(id).then(
    (response) => {
      dispatch(tl(response));
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

export const newLike = (values) => (dispatch) => {
  return Helper.newLike(values).then(
    (response) => {
      dispatch(nl(response));
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

export const removeLike = (values) => (dispatch) => {
  return Helper.removeLike(values).then(
    () => {
      dispatch(rl(values.productId));
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
