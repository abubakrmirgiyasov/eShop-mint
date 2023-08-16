import Request from "../../helpers/requestWrapper/request";
import { IProduct } from "../types/IProduct";

export const getMyLikes = (request: Request, id: string) => {
  return request
    .get("/like/getmylikes/" + id)
    .then((response) => response)
    .catch((error) => {
      throw error;
    });
};

export const addLike = (request: Request, product: IProduct) => {
  return request
    .post("/like/newlike", product)
    .then((response) => response)
    .catch((error) => {
      throw error;
    });
};

export const removeLike = (request: Request, id: string) => {
  return request
    .delete("/like/removelike/" + id)
    .then((response) => response)
    .catch((error) => {
      throw error;
    });
};
