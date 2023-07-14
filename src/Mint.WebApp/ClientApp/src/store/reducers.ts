import { combineReducers } from "redux";
import Auth from "./authentication";
import Message from "./message";
import Language from "./language";
import Theme from "./theme";
import Cart from "./cart";
import Favorites from "./favorite";

export default combineReducers({
  Auth,
  Message,
  Language,
  Theme,
  Cart,
  Favorites,
});
