import {
  ADD_PRODUCT_TO_CART,
  DECREMENT,
  GET_CART_PRODUCTS,
  INCREMENT,
  REMOVE_FROM_CART,
} from "./actionType";
import { IProduct } from "../../services/types/IProduct";

export const getCartProducts = (toggle: boolean) => (dispatch) => {
  dispatch({
    type: GET_CART_PRODUCTS,
    payload: toggle,
  });
};

export const addToCart = (item: IProduct) => (dispatch) => {
  dispatch({
    type: ADD_PRODUCT_TO_CART,
    payload: item,
  });
};

export const removeFromCart = (id: string) => (dispatch) => {
  dispatch({
    type: REMOVE_FROM_CART,
    payload: id,
  });
};

export const increment = (id: string) => (dispatch) => {
  dispatch({
    type: INCREMENT,
    payload: id,
  });
};

export const decrement = (id: string) => (dispatch) => {
  dispatch({
    type: DECREMENT,
    payload: id,
  });
};
