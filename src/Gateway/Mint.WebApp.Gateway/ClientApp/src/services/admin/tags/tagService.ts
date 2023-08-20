import Request from "../../../helpers/requestWrapper/request";
import { ITag } from "../ITag";

export const getTags = (request: Request) => {
  return request
    .get("/gate/tag/gettags")
    .then((response: ITag[]) => response)
    .catch((error) => {
      throw error;
    });
};

export const newTag = (request: Request, tag: ITag) => {
  return request
    .post("/gate/tag/newtag", tag)
    .then(() => tag)
    .catch((error) => {
      throw error;
    });
};

export const updateTag = (request: Request, tag: ITag) => {
  return request
    .put("/gate/tag/updatetag", tag)
    .then(() => tag)
    .catch((error) => {
      throw error;
    });
};

export const deleteTag = (request: Request, id: string) => {
  return request
    .delete("/gate/tag/deletetag/" + id)
    .then(() => id)
    .catch((error) => {
      throw error;
    });
};
