import { GET_ALL_PRODCUTS } from "./actionType";

const initState = {};

export default function (state = initState, action) {
  const { type, payload } = action;

  switch (type) {
    case GET_ALL_PRODCUTS:
      return {
        ...state,
        products: payload,
      };
    default:
      return state;
  }
}
