import {ITag} from "../../types/Tags/ITag";
import {TagActions} from "../../types/Tags/ITagActions";
import {GET_TAGS, INSERT_TAG, REMOVE_TAG, UPDATE_TAG} from "./actionTypes";

interface ITagState {
    data: ITag[];
    successMessage?: string | null;
}

const initState: ITagState = {
    data: [],
    successMessage: null,
};

export default function (state = initState, action: TagActions) {
    switch (action.type) {
        case GET_TAGS:
            return {
                ...state,
                data: action.payload
            };
        case INSERT_TAG:
            return {
                ...state,
                data: [...action.payload, ...state.data],
                successMessage: action.payload.message,
            };
        case UPDATE_TAG:
            return {
                ...state,
                data: state.data.map(x => x.value === action.payload.data.value
                    ? action.payload
                    : x) as ITag[],
                successMessage: action.payload.message,
            };
        case REMOVE_TAG:
console.log("delete", action.payload)
            return {
                ...state,
                data: state.data.filter(x => x.value !== action.payload.id),
                successMessage: action.payload.message,
            };
        default:
            return state;
    }
}