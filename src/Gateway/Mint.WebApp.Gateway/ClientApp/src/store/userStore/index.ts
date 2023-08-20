import { IUserStore } from "../../services/types/IUser";
import { ADD_NEW_STORE, GET_MY_STORE, UPDATE_STORE } from "./actionType";

export interface IMyStore {
  isSeller: boolean;
  myStore: IUserStore[];
}

const store: IUserStore[] = JSON.parse(localStorage.getItem("my_store")) || [];

const init: IMyStore = store.length
  ? { isSeller: true, myStore: store }
  : { isSeller: false, myStore: [] };

export default function (state = init, action) {
  const { type, payload } = action;

  switch (type) {
    case GET_MY_STORE:
      return {
        ...state,
        myStore: payload,
      };
    case ADD_NEW_STORE:
      return {
        ...state,
        myStore: [...state.myStore, payload],
      };
    case UPDATE_STORE:
      // let temp: IUserStore[] =

      return {
        ...state,
        myStore: temp,
      };
  }
}
