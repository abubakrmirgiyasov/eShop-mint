import Request from "../../../helpers/requestWrapper/request";
import { ITag } from "../ITag";

export const getTags = (request: Request) => {
  return request
    .get("/tag/gettags")
    .then((response: ITag[]) => response)
    .catch((error) => error);
};

export const newTag = (request: Request, tag: ITag) => {
  return request
    .post("/tag/newtag", tag)
    .then(() => tag)
    .catch((error) => error);
};

export const updateTag = (request: Request, tag: ITag) => {
  return request
    .put("/tag/updatetag", tag)
    .then(() => tag)
    .catch((error) => error);
};

export const deleteTag = (request: Request, id: string) => {
  return request
    .delete("/tag/deletetag/" + id)
    .then(() => id)
    .catch((error) => error);
};
