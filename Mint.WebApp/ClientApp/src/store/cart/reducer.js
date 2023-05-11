import {
  ADD_PRODUCT_TO_CART,
  DECREMENT,
  INCREMENT,
  REMOVE_FROM_CART,
  TOGGLE_CART,
} from "./actionType";

const products = JSON.parse(localStorage.getItem("cart_items")) || [];

const initState = {
  isCartOpen: false,
  cart: products,
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
        products.push(payload);
        localStorage.setItem("cart_items", JSON.stringify(products));

        return {
          ...state,
          cart: [...state.cart, payload],
        };
      } else {
        return {
          ...state,
          cart: state.cart.map((item) => {
            if (item.id === payload.id) {
              return {
                ...item,
                quantity: item.quantity + 1,
              };
            } else {
              return item;
            }
          }),
        };
      }
    case REMOVE_FROM_CART:
      const newProducts = state.cart.filter(
        (product) => product.id !== payload
      );
      localStorage.setItem("cart_items", JSON.stringify(newProducts));

      return {
        ...state,
        cart: state.cart.filter((item) => item.id !== payload),
      };
    case INCREMENT:
      return {
        ...state,
        cart: state.cart.map((item) => {
          if (item.id === payload.id) {
            return {
              ...item,
              quantity: item.quantity + 1,
            };
          } else {
            return item;
          }
        }),
      };
    case DECREMENT:
      return {
        ...state,
        cart: state.cart
          .map((item) => {
            if (item.id === payload.id) {
              return {
                ...item,
                quantity: item.quantity - 1,
              };
            } else {
              return item;
            }
          })
          .filter((item) => item.quantity !== 0),
      };
    default:
      return state;
  }
}
