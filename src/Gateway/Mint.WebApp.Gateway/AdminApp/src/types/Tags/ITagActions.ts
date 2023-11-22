import {Action} from "redux";
import {GET_TAGS, INSERT_TAG, REMOVE_TAG, UPDATE_TAG} from "../../stores/Tag/actionTypes";
import {ITag} from "./ITag";

interface IFetchTagsResponseAction extends Array<ITag> { }
interface ICreateTagResponseAction extends ITag {
    message: string;
    data: ITag;
}
interface IUpdateTagResponseAction extends ITag {
    message: string;
    data: ITag;
}
interface IDeleteTagResponseAction {
    id: string;
    message: string;
}

export interface IFetchTagsAction extends Action<typeof GET_TAGS> {
    type: typeof GET_TAGS;
    payload: IFetchTagsResponseAction;
}

export interface ICreateTagAction extends Action<typeof INSERT_TAG> {
    type: typeof INSERT_TAG;
    payload: ICreateTagResponseAction;
}

export interface IUpdateTagAction extends Action<typeof UPDATE_TAG> {
    type: typeof UPDATE_TAG;
    payload: IUpdateTagResponseAction;
}

export interface IDeleteTagAction extends Action<typeof REMOVE_TAG> {
    type: typeof REMOVE_TAG;
    payload: IDeleteTagResponseAction;
}

export type TagActions =
    | IFetchTagsAction
    | ICreateTagAction
    | IUpdateTagAction
    | IDeleteTagAction
    ;
