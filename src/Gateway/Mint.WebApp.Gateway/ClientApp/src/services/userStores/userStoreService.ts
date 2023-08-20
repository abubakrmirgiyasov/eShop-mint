import Request from "../../helpers/requestWrapper/request";
import { IUserStore } from "../types/IUser";

type Success = {
  message: string;
};

export const getMyStore = (request: Request, id: string) => {
  return request
    .get("/store/getmystore/" + id)
    .then((response: IUserStore) => {
      return response;
    })
    .catch((error) => {
      throw error;
    });
};

export const createNewStore = (request: Request, values: IUserStore) => {
  return request
    .post("/store/createstore", values)
    .then((response: IUserStore) => {
      return response;
    })
    .catch((error) => {
      throw error;
    });
};

export const updateStore = (request: Request, values: IUserStore) => {
  return request
    .put("/store/updatestore", values)
    .then((response: IUserStore) => {
      return response;
    })
    .catch((error) => {
      throw error;
    });
};

export const deleteStore = (request: Request, id: string) => {
  return request
    .delete("/store/deletestore/" + id)
    .then((response: Success) => {
      return response;
    })
    .catch((error) => {
      throw error;
    });
};
