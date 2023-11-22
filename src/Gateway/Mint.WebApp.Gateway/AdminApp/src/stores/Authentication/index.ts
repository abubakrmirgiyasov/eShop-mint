import {ILocalUser} from "../../types/Authentication/ILocalUser";
import {LOGIN_FAIL, LOGIN_SUCCESS, LOGOUT, UPDATE_USER} from "./actionType";
import {AuthenticationsActions} from "../../types/Authentication/IAuthenticationActions";

interface IUserAuth {
    isLoggedIn: boolean;
    user?: ILocalUser | null;
}

const currentUser: ILocalUser = JSON.parse(localStorage.getItem("c_user"));

const initState: IUserAuth = currentUser
    ? { isLoggedIn: true, user: currentUser, }
    : { isLoggedIn: false, user: null };

export default function (state = initState, action: AuthenticationsActions) {
    switch (action.type) {
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
                user: action.payload,
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
                user: action.payload,
            };
        default:
            return state;
    }
}
