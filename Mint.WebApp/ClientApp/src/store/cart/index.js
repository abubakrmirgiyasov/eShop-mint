import {
  ADD_PRODUCT_TO_CART,
  DECREMENT,
  INCREMENT,
  REMOVE_FROM_CART,
  TOGGLE_CART,
} from "./actionType";

export const toggleCart = (toggle) => {
  return {
    type: TOGGLE_CART,
    payload: toggle,
  };
};

export const addToCart = (item) => {
  return {
    type: ADD_PRODUCT_TO_CART,
    payload: item,
  };
};

export const removeFromCart = (id) => {
  return {
    type: REMOVE_FROM_CART,
    payload: id,
  };
};

export const increment = (id) => {
  return {
    type: INCREMENT,
    payload: id,
  };
};

export const decrement = (id) => {
  return {
    type: DECREMENT,
    payload: id,
  };
};
