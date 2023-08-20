import { DELETE_TAG, GET_TAGS, NEW_TAG, UPDATE_TAG } from "./actionType";
import { ITag } from "../../services/admin/ITag";

export const getTags = (tags: ITag[] | void) => (dispatch) => {
  dispatch({
    type: GET_TAGS,
    payload: tags,
  });
};

export const newTag = (tag: ITag) => (dispatch) => {
  dispatch({
    type: NEW_TAG,
    payload: tag,
  });
};

export const updateTag = (tag: ITag) => (dispatch) => {
  dispatch({
    type: UPDATE_TAG,
    payload: tag,
  });
};

export const deleteTag = (id: string) => (dispatch) => {
  dispatch({
    type: DELETE_TAG,
    payload: id,
  });
};
