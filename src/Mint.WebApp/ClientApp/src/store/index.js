import { applyMiddleware, createStore } from "redux";
import rootReducer from "./reducers";
import { composeWithDevTools } from "redux-devtools-extension";
import thunk from "redux-thunk";

const middleware = [thunk];

const configureStore = createStore(
  rootReducer,
  composeWithDevTools(applyMiddleware(...middleware))
);

export default configureStore;
