import {combineReducers} from "redux";
import Auth from "./Authentication";
import Message from "./Message"

export default combineReducers({
   Auth,
   Message,
});