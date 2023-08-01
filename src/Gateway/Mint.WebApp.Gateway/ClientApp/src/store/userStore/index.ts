import { IUserStore } from "../../services/types/IUser";
import { GET_MY_STORE } from "./actionType";

const init: IUserStore = JSON.parse(localStorage.getItem("my_store")) || {};

export default function (state = init, action) {
  const { type, payload } = action;

  switch (type) {
    case GET_MY_STORE:
      return {};
  }
}
