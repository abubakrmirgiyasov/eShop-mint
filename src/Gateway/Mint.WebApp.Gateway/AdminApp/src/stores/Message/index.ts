import {IMessage} from "../../types/Message/IMessage";
import {MessageActions} from "../../types/Message/IMessageActions";
import {CLEAR_MESSAGE, SET_MESSAGE} from "./actionType";

const initState: IMessage = {
  message: null,
};

export default function (state = initState, action: MessageActions) {
  switch (action.type) {
    case SET_MESSAGE:
      console.log(action.payload)
      return {
        ...state,
        message: action.payload,
      };
    case CLEAR_MESSAGE:
      return {
        ...state,
        message: action.payload,
      };
    default:
      return state;
  }
}