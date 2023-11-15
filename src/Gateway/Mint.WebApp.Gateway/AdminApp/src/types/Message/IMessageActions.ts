import {IMessage} from "./IMessage";
import {CLEAR_MESSAGE, SET_MESSAGE} from "../../stores/Message/actionType";
import {Action} from "redux";

interface IMessageErrorShown extends IMessage { }
interface IMessageErrorClear extends IMessage { }

export interface IMessageSetError extends Action<typeof SET_MESSAGE> {
    type: typeof SET_MESSAGE;
    payload: IMessageErrorShown;
}

export interface IMessageClearError extends Action<typeof CLEAR_MESSAGE> {
    type: typeof CLEAR_MESSAGE;
    payload: IMessageErrorClear;
}

export type MessageActions =
    IMessageSetError | IMessageClearError;
