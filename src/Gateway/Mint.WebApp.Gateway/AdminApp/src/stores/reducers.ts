import {combineReducers} from "redux";
import Auth from "./Authentication";
import Message from "./Message";
import Tags from "./Tag";

export default combineReducers({
   Auth,
   Message,
   Tags,
});