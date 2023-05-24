import {
  NEW_LIKE,
  REMOVE_LIKE,
  TOGGLE_LIKES,
} from "../../store/liked/actionType";
import { SET_MESSAGE } from "../../store/message/actionType";
import Helper from "./likesHelper";
import { removeLike as rl } from "../../store/liked";

export const toggleLikes = (id) => (dispatch) => {
  return Helper.toggleLikes(id).then(
    (response) => {
      dispatch({
        type: TOGGLE_LIKES,
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

export const newLike = (values) => (dispatch) => {
  return Helper.newLike(values).then(
    (response) => {
      dispatch({
        type: NEW_LIKE,
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

export const removeLike = (values) => (dispatch) => {
  return Helper.removeLike(values).then(
    (response) => {
      dispatch(rl(response));
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
