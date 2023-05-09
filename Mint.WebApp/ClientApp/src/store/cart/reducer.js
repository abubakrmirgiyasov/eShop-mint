import {
  ADD_PRODUCT_TO_CART,
  GET_PRODUCTS_FROM_CART,
  TOGGLE_CART,
} from "./actionType";

const products = JSON.parse(localStorage.getItem("cart_items"));

const initState = {
  isCartOpen: false,
  cart: [],
};

export default function (state = initState, action) {
  const { type, payload } = action;

  switch (type) {
    case TOGGLE_CART:
      return {
        ...state,
        isCartOpen: payload,
      };
    case ADD_PRODUCT_TO_CART:
      const isItemExist = state.cart.some((item) => item.id === payload.id);

      if (!isItemExist) {
        return {
          ...state,
          cart: [...state.cart, payload],
        };
      } else {
      }

      return {
        ...state,
      };
    default:
      return state;
  }
}
