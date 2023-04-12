import { combineReducers } from "redux";
import Signin from "./signin/reducer";
import Message from './message/reducer';
import Theme from './theme/reducer';

const rootReducer = combineReducers({
    Signin,
    Message,
    Theme,
});

export default rootReducer;