import { ADD_LIKE, GET_LIKES_PRODUCTS, REMOVE_LIKE } from "./actionType";
import { IProduct } from "../../services/types/IProduct";

export const getLikes = (products: IProduct[]) => (dispatch) => {
  dispatch({
    type: GET_LIKES_PRODUCTS,
    payload: products,
  });
};

export const addLike = (product: IProduct) => (dispatch) => {
  dispatch({
    type: ADD_LIKE,
    payload: product,
  });
};

export const removeLike = (id: string) => (dispatch) => {
  dispatch({
    type: REMOVE_LIKE,
    payload: id,
  });
};
