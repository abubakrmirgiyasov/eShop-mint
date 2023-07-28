import Request from "../../helpers/requestWrapper/request";
import {
  getMyLikes as getRequest,
  addLike as addRequest,
  removeLike as removeRequest,
} from "./favoriteService";
import {
  getLikes as getStore,
  addLike as addStore,
  removeLike as removeStore,
} from "../../store/favorite/favorite";
import { SET_MESSAGE } from "../../store/message/actionType";
import { IProduct } from "../types/IProduct";

export const getMyLikes = (request: Request, id: string) => (dispatch) => {
  return getRequest(request, id).then(
    (response: IProduct[]) => {
      dispatch(getStore(response));
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

export const addLike = (request: Request, product: IProduct) => (dispatch) => {
  return addRequest(request, product).then(
    (response) => {
      dispatch(addStore(product));
      return Promise.resolve();
    },
    (error) => {
      dispatch({ type: SET_MESSAGE, payload: error });
      return Promise.reject();
    }
  );
};

export const removeLike =
  (request: Request, product: IProduct) => (dispatch) => {
    return removeRequest(request, product.id).then(
      () => {
        dispatch(removeStore(product.id));
        return Promise.resolve();
      },
      (error) => {
        dispatch({
          type: SET_MESSAGE,
          payload: error,
        });
      }
    );
  };
