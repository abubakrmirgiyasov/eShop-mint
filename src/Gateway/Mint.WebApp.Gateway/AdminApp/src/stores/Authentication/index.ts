import {ILocalUser} from "../../types/Authentication/ILocalUser";
import {LOGIN_FAIL, LOGIN_SUCCESS, LOGOUT, UPDATE_USER} from "./actionType";

interface IUserAuth {
    isLoggedIn: boolean;
    user?: ILocalUser | null;
}

const currentUser: ILocalUser = JSON.parse(localStorage.getItem("c_user"));

const initState: IUserAuth = currentUser
    ? {isLoggedIn: true, user: currentUser}
    : {isLoggedIn: false, user: null};

export default function (state = initState, action) {
    const {type, payload}: { type: string, payload: ILocalUser } = action;

    switch (type) {
        case LOGIN_FAIL:
            return {
                ...state,
                isLoggedIn: false,
                user: null
            };
        case LOGIN_SUCCESS:
            return {
                ...state,
                isLoggedIn: true,
                user: payload,
            };
        case LOGOUT:
            return {
                ...state,
                isLoggedIn: false,
                user: null,
            };
        case UPDATE_USER:
            return {
                ...state,
                isLoggedIn: true,
                user: payload,
            };
        default:
            return state;
    }
}
