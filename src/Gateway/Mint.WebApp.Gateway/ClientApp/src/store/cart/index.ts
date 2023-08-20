import { IProduct } from "../../services/types/IProduct";
import {
  ADD_PRODUCT_TO_CART,
  DECREMENT,
  GET_CART_PRODUCTS,
  INCREMENT,
  REMOVE_FROM_CART,
} from "./actionType";

interface ICart {
  isCartOpen: boolean;
  cart: IProduct[];
}

const products: IProduct[] = JSON.parse(localStorage.getItem("cart")) || [];

const initState: ICart = { isCartOpen: false, cart: [] };

export default function (state = initState, action) {
  const { type, payload } = action;

  switch (type) {
    case GET_CART_PRODUCTS:
      return {
        ...state,
        isCartOpen: payload,
      };
    case ADD_PRODUCT_TO_CART:
      const isItemExist = state.cart.some(
        (product) => product.id === payload.id
      );

      if (!isItemExist) {
        return {
          ...state,
          cart: [...state.cart, payload],
        };
      } else {
        return {
          ...state,
          cart: state.cart.map((product) => {
            if (product.id === payload.id) {
              return {
                ...product,
                quantity: product.quantity + 1,
              };
            } else {
              return product;
            }
          }),
        };
      }
    case REMOVE_FROM_CART:
      const newProduct = state.cart.filter((product) => product.id !== payload);

      return {
        ...state,
        cart: state.cart.filter((product) => product.id !== payload),
      };
    case INCREMENT:
      return {
        ...state,
        cart: state.cart.map((product) => {
          if (product.id === payload) {
            return {
              ...product,
              quantity: product.quantity + 1,
            };
          } else {
            return product;
          }
        }),
      };
    case DECREMENT:
      return {
        ...state,
        cart: state.cart
          .map((product) => {
            if (product.id === payload) {
              return {
                ...product,
                quantity: product.quantity - 1,
              };
            } else {
              return product;
            }
          })
          .filter((product) => product.quantity !== 0),
      };
    default:
      return state;
  }
}
