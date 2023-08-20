import { ITag } from "../../services/admin/ITag";
import { DELETE_TAG, GET_TAGS, NEW_TAG, UPDATE_TAG } from "./actionType";

const initState: ITag[] = [];

export default function (state = initState, action) {
  const { type, payload } = action;

  switch (type) {
    case GET_TAGS:
      return {
        ...state,
        tags: payload,
      };
    case NEW_TAG:
      return {
        ...state,
        tags: [...state, payload],
      };
    case UPDATE_TAG:
      const currentTags: ITag[] = state.filter(
        (x) => x.value !== payload.value
      );

      return {
        ...state,
        tags: [...currentTags, payload],
      };
    case DELETE_TAG:
      const withDeletedTags: ITag[] = state.filter(
        (x) => x.value !== payload.value
      );

      return {
        ...state,
        tags: withDeletedTags,
      };
    default:
      return state;
  }
}
