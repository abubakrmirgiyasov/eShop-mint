import Request from "../../../helpers/requestWrapper/request";

import {
  getTags as getRequest,
  newTag as newRequest,
  updateTag as updateRequest,
  deleteTag as deleteRequest,
} from "./tagService";
import {
  getTags as getStore,
  newTag as newStore,
  updateTag as updateStore,
  deleteTag as deleteStore,
} from "../../../store/tag/tag";
import { SET_MESSAGE } from "../../../store/message/actionType";
import { ITag } from "../ITag";

export const getTags = (request: Request) => (dispatch) => {
  return getRequest(request).then(
    (response) => {
      dispatch(getStore(response));
      return Promise.resolve(response);
    },
    (error) => {
      dispatch({
        type: SET_MESSAGE,
        payload: error,
      });
      return Promise.reject(error);
    }
  );
};

export const newTag = (request: Request, tag: ITag) => (dispatch) => {
  return newRequest(request, tag).then(
    (response) => {
      console.log("updateTag Success");
      dispatch(newStore(tag));
      return Promise.resolve(response);
    },
    (error) => {
      console.log("updateTag error");
      dispatch({
        type: SET_MESSAGE,
        payload: error,
      });
      return Promise.reject(error);
    }
  );
};

export const updateTag = (request: Request, tag: ITag) => (dispatch) => {
  return updateRequest(request, tag).then(
    (response) => {
      dispatch(updateStore(tag));
      return Promise.resolve(response);
    },
    (error) => {
      dispatch({
        type: SET_MESSAGE,
        payload: error,
      });
      return Promise.reject(error);
    }
  );
};

export const deleteTag = (request: Request, id: string) => (dispatch) => {
  return deleteRequest(request, id).then(
    () => {
      dispatch(deleteStore(id));
      return Promise.resolve();
    },
    (error) => {
      dispatch({
        type: SET_MESSAGE,
        payload: error,
      });
      return Promise.reject();
    }
  );
};
