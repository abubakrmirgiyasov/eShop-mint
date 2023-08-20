import { IProduct } from "../../services/types/IProduct";
import {
  ADD_COMPARE_PRODUCT,
  GET_ALL_COMPARE_PRODUCTS,
  REMOVE_COMPARE_PRODUCT,
} from "./actionType";

interface ICompare {
  isCompareOpen: boolean;
  products: IProduct[];
}

const products: IProduct[] = JSON.parse(localStorage.getItem("compare")) || [];

const initState: ICompare =
  products.length !== 0
    ? { isCompareOpen: false, products: products }
    : { isCompareOpen: false, products: [] };

export default function (state = initState, action) {
  const { type, payload } = action;

  switch (type) {
    case GET_ALL_COMPARE_PRODUCTS:
      return {
        ...state,
        isCompareOpen: payload,
      };
    case ADD_COMPARE_PRODUCT:
      const isItemExist = state.products.some(
        (product) => product.id === payload.id
      );

      if (!isItemExist) {
        return {
          ...state,
          products: [...state.products, payload],
        };
      } else {
        return state;
      }
    case REMOVE_COMPARE_PRODUCT:
      return {
        ...state,
        products: state.products.filter((product) => product.id !== payload.id),
      };
    default:
      return state;
  }
}
