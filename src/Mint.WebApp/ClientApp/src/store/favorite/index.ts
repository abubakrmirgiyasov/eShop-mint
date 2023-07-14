import { IProduct } from "../../services/types/IProduct";
import { ADD_LIKE, GET_LIKES_PRODUCTS, REMOVE_LIKE } from "./actionType";

interface ILike {
  isLikeOpen: boolean;
  likes: IProduct[];
}

const products: IProduct[] = JSON.parse(localStorage.getItem("likes")) || [];

const initState: ILike =
  products.length !== 0
    ? { isLikeOpen: false, likes: products }
    : { isLikeOpen: false, likes: [] };

export default function (state = initState, action) {
  const { type, payload } = action;

  switch (type) {
    case GET_LIKES_PRODUCTS:
      return {
        ...state,
        like: payload,
      };
    case ADD_LIKE:
      const isItemExist = state.likes.some(
        (product) => product.id === payload.id
      );

      if (!isItemExist) {
        return {
          ...state,
          likes: [...state.likes, payload],
        };
      } else {
        return state;
      }
    case REMOVE_LIKE:
      return {
        ...state,
        likes: state.likes.filter((product) => product.id !== payload.id),
      };
    default:
      return state;
  }
}
