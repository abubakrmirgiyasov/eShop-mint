import { combineReducers } from "redux";
import Signin from "./signin/reducer";
import Message from "./message/reducer";
import Theme from "./theme/reducer";
import Categories from "./categories/reducer";

const rootReducer = combineReducers({
  Signin,
  Message,
  Theme,
  Categories,
});

export default rootReducer;
