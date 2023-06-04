import { NEW_LIKE, REMOVE_LIKE, TOGGLE_LIKES } from "./actionType";

const initState = {
  likes: [],
};

export default function (state = initState, action) {
  const { type, payload } = action;

  switch (type) {
    case TOGGLE_LIKES:
      return {
        ...state,
        likes: payload,
      };
    case NEW_LIKE:
      const isItemExist = state.likes.some((item) => item.id === payload.id);

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
        likes: state.likes.filter((item) => item.id !== payload),
      };
    default:
      return state;
  }
}
