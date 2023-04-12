import { CLEAR_MESSAGE, SET_MESSAGE } from "./actionType";

const initialState = {};

export default function (state = initialState, action) {
    const { type, payload } = action;

    switch(type) {
        case SET_MESSAGE:
            return {
                ...state,
                message: payload 
            };
        case CLEAR_MESSAGE:
            return { 
                ...state,
                message: "" 
            };
        default:
            return state;
    }
}