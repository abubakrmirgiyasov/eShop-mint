import { combineReducers } from "redux";
import Signin from "./signin/reducer";
import Message from "./message/reducer";
import Theme from "./theme/reducer";
import Categories from "./categories/reducer";
import MyStore from "./userStore/reducer";
import Products from "./products/reducer";
import Cart from "./cart/reducer";
import Likes from "./liked/reducer";

const rootReducer = combineReducers({
  Signin,
  Message,
  Theme,
  Categories,
  MyStore,
  Products,
  Cart,
  Likes,
});

export default rootReducer;
