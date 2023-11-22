import {IRequest} from "../../hooks/useAxios";
import {ITag} from "../../types/Tags/ITag";
import {IMessage} from "../../types/Message/IMessage";

export const getTags = (axios: IRequest) => {
  return axios
    .get<ITag[]>("/main/tag/getTags")
    .then((response) => response)
    .catch((error) => {
      throw error;
    });
};

export const newTag = (axios: IRequest, tag: ITag) => {
  return axios
    .post<ITag, IMessage>("/main/tag/newTag", tag)
    .then((response) => response)
    .catch((error) => {
      throw error;
    });
};

export const updateTag = (axios: IRequest, tag: ITag) => {
  return axios
    .put<ITag, IMessage>("/main/tag/updateTag", tag)
    .then((response) => response)
    .catch((error) => {
      throw error;
    });
};

export const deleteTag = (axios: IRequest, id: string) => {
  return axios
    .del<string, IMessage>("/main/tag/deleteTag/" + id)
    .then((response) => response)
    .catch((error) => {
      throw error;
    });
};
