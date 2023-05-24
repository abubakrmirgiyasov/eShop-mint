import { NEW_LIKE, TOGGLE_LIKES, REMOVE_LIKE } from "./actionType";

export const toggleLike = (toggle) => {
  return {
    type: TOGGLE_LIKES,
    payload: toggle,
  };
};

export const newLike = (item) => {
  console.log(item);
  return {
    type: NEW_LIKE,
    payload: item,
  };
};

export const removeLike = (item) => {
  console.log(item);
  return {
    type: REMOVE_LIKE,
    payload: item,
  };
};
