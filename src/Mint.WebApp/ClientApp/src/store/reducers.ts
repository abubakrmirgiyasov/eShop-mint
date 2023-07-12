import { combineReducers } from "redux";
import Auth from "./authentication";
import Message from "./message";
import Language from "./language";
import Theme from "./theme";

export default combineReducers({
  Auth,
  Message,
  Language,
  Theme,
});
