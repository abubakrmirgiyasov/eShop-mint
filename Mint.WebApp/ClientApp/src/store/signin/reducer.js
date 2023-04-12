import { SIGNIN, LOGOUT, REFRESH_TOKEN } from './actionType';

const user = JSON.parse(localStorage.getItem("auth_user"));

const initState = user
    ? { isLoggedIn: true, user }
    : { isLoggedIn: false, user: null };

export default function (state = initState, action) {
    const { type, payload } = action;

    switch (type) {
        case SIGNIN:
            return {
                ...state,
                isLoggedIn: true,
                user: payload.user,
            };
        case LOGOUT:
            return {
                ...state,
                isLoggedIn: false,
                user: null,
            };
        case REFRESH_TOKEN:
            return {
                ...state,
                isLoggedIn: true,
                user: payload.user,
            };
        default:
            return state;
    }
}