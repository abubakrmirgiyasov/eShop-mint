import { MY_STORE } from "./actionType";

const myStore = JSON.parse(localStorage.getItem("my_store"));

const initState = myStore ? { myStore } : {};

export default function (state = initState, action) {
  const { type, payload } = action;

  switch (type) {
    case MY_STORE:
      return {
        ...state,
        myStore: payload,
      };
    default:
      return state;
  }
}
