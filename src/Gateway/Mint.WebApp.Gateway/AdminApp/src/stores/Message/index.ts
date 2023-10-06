import {CLEAR_MESSAGE, SET_MESSAGE} from "./actionType";

interface IMessage {
    message?: string | null;
}

const initState: IMessage = { message: null };

export default function (state = initState, action) {
    const {type, payload}: { type: string, payload: string } = action;

    switch (type) {
        case SET_MESSAGE:
            return {
                ...state,
                message: payload,
            };
        case CLEAR_MESSAGE:
            return {
                ...state,
                message: null,
            };
        default:
            return state;
    }
}
