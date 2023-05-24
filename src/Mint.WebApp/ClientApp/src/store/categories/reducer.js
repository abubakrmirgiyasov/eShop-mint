import { MENU } from "./actionType";

const initState = {};

export default function (state = initState, action) {
  const { type, payload } = action;

  switch (type) {
    case MENU:
      return {
        ...state,
        menu: payload,
      };
    default:
      return state;
  }
}
