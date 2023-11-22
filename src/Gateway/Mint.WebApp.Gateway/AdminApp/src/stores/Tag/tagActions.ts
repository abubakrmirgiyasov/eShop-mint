import {IRequest} from "../../hooks/useAxios";
import {deleteTag, getTags, newTag, updateTag} from "../../services/tags/tagService";
import {clearMessage, setMessage} from "../Message/messageActions";
import {GET_TAGS, INSERT_TAG, REMOVE_TAG, UPDATE_TAG} from "./actionTypes";
import {ITag} from "../../types/Tags/ITag";
import {AxiosError} from "axios";

export const getTagsStore = (axios: IRequest) => (dispatch) => {
    return getTags(axios).then(
        (response) => {
            dispatch({
                type: GET_TAGS,
                payload: response,
            });
            dispatch(clearMessage());
            return Promise.resolve();
        },
        (error) => {
            const message =
                (error.response &&
                    error.response.data &&
                    error.response.data.message) ||
                error.message ||
                error.toString();
            dispatch(setMessage(message));
            return Promise.reject();
        }
    );
}

export const createTagStore = (axios: IRequest, tag: ITag) => (dispatch) => {
    return newTag(axios, tag).then(
        (response) => {
            dispatch({
                type: INSERT_TAG,
                payload: { data: tag, successMessage: response },
            });
            dispatch(clearMessage());
            return Promise.resolve();
        },
        (error) => {
            const message =
                (error.response &&
                    error.response.data &&
                    error.response.data.message) ||
                error.message ||
                error.toString();
            dispatch(setMessage(message));
            return Promise.reject();
        }
    );
}

export const updateTagStore = (axios: IRequest, tag: ITag) => (dispatch) => {
    return updateTag(axios, tag).then(
        (response) => {
            dispatch({
                type: UPDATE_TAG,
                payload: { data: tag, successMessage: response },
            });
            dispatch(clearMessage());
            return Promise.resolve();
        },
        (error) => {
            const message =
                (error.response &&
                    error.response.data &&
                    error.response.data.message) ||
                error.message ||
                error.toString();
            dispatch(setMessage(message));
            return Promise.reject();
        },
    );
}

export const removeTagStore = (axios: IRequest, id: string) => (dispatch) => {
    return deleteTag(axios, id).then(
        (response) => {
            dispatch({
               type: REMOVE_TAG,
                payload: { id: id, message: response },
            });
            dispatch(clearMessage());
            return Promise.resolve();
        },
        (error) => {
            const message =
                (error.response &&
                    error.response.data &&
                    error.response.data.message) ||
                error.message ||
                error.toString();
            dispatch(setMessage(message));
            return Promise.reject();
        }
    );
}
