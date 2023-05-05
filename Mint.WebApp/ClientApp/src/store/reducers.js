import { combineReducers } from "redux";
import Signin from "./signin/reducer";
import Message from "./message/reducer";
import Theme from "./theme/reducer";
import Categories from "./categories/reducer";
import MyStore from "./userStore/reducer";

const rootReducer = combineReducers({
  Signin,
  Message,
  Theme,
  Categories,
  MyStore,
});

export default rootReducer;
