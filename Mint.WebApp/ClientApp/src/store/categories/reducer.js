import {
  GET_ALL_CATEGORIES,
  GET_ALL_MANUFACTURES,
  GET_ALL_SUBCATEGORIES,
  MENU,
} from "./actionType";

const initState = {};

export default function (state = initState, action) {
  const { type, payload } = action;

  switch (type) {
    case GET_ALL_CATEGORIES:
      return {
        ...state,
        categories: payload,
      };
    case GET_ALL_MANUFACTURES:
      return {
        ...state,
        manufactures: payload,
      };
    case GET_ALL_SUBCATEGORIES:
      return {
        ...state,
        subCategories: payload,
      };
    case MENU:
      return {
        ...state,
        menu: payload,
      };
    default:
      return state;
  }
}
