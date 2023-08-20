import {
  getMyStore as get,
  createNewStore as create,
  updateStore as update,
  deleteStore as del,
} from "./userStoreService";
import {
  getMyStore as getDispatch,
  createNewStore as createDispatch,
  updateStore as updateDispatch,
  deleteStore as delDispatch,
} from "../../store/userStore/userStore";
import Request from "../../helpers/requestWrapper/request";
import { SET_MESSAGE } from "../../store/message/actionType";
import { IUserStore } from "../types/IUser";

export const getMyStore = (request: Request, id: string) => (dispatch) => {
  return get(request, id).then(
    (response) => {
      dispatch(getDispatch(response));
      return Promise.resolve();
    },
    (error) => {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();

      dispatch({
        type: SET_MESSAGE,
        payload: message,
      });

      return Promise.reject();
    }
  );
};

export const createNewStore =
  (request: Request, values: IUserStore) => (dispatch) => {
    return create(request, values).then(
      (response) => {
        dispatch(createDispatch(response));
        return Promise.resolve();
      },
      (error) => {
        const message =
          (error.response &&
            error.response.data &&
            error.response.data.message) ||
          error.message ||
          error.toString();

        dispatch({
          type: SET_MESSAGE,
          payload: message,
        });

        return Promise.reject();
      }
    );
  };

export const updateStore =
  (request: Request, values: IUserStore) => (dispatch) => {
    return update(request, values).then(
      (response) => {
        dispatch(updateDispatch(response));
        return Promise.resolve();
      },
      (error) => {
        const message =
          (error.response &&
            error.response.data &&
            error.response.data.message) ||
          error.message ||
          error.toString();

        dispatch({
          type: SET_MESSAGE,
          payload: message,
        });

        return Promise.reject();
      }
    );
  };

export const deleteStore = (request: Request, id: string) => (dispatch) => {
  return del(request, id).then(
    (response) => {
      dispatch(delDispatch(id));
      return Promise.resolve();
    },
    (error) => {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();

      dispatch({
        type: SET_MESSAGE,
        payload: message,
      });

      return Promise.reject();
    }
  );
};
