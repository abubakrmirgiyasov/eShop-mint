import { IProduct } from "../../services/types/IProduct";
import {
  ADD_COMPARE_PRODUCT,
  GET_ALL_COMPARE_PRODUCTS,
  REMOVE_COMPARE_PRODUCT,
} from "./actionType";

export const getCompareProducts = (toggle: boolean) => (dispatch) => {
  dispatch({
    type: GET_ALL_COMPARE_PRODUCTS,
    payload: toggle,
  });
};

export const addCompare = (product: IProduct) => (dispatch) => {
  dispatch({
    type: ADD_COMPARE_PRODUCT,
    payload: product,
  });
};

export const removeCompare = (id: string) => (dispatch) => {
  dispatch({
    type: REMOVE_COMPARE_PRODUCT,
    payload: id,
  });
};
