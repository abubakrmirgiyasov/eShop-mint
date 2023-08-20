import {
  ADD_NEW_STORE,
  GET_MY_STORE,
  REMOVE_STORE,
  UPDATE_STORE,
} from "./actionType";
import { IUserStore } from "../../services/types/IUser";

export const getMyStore = (values: IUserStore | void) => (dispatch) => {
  dispatch({
    type: GET_MY_STORE,
    payload: values,
  });
};

export const createNewStore = (values: IUserStore | void) => (dispatch) => {
  dispatch({
    type: ADD_NEW_STORE,
    payload: values,
  });
};

export const updateStore = (values: IUserStore | void) => (dispatch) => {
  dispatch({
    type: UPDATE_STORE,
    payload: values,
  });
};

export const deleteStore = (id: string) => (dispatch) => {
  dispatch({
    type: REMOVE_STORE,
    payload: id,
  });
};
