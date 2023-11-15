import {Action} from "redux";
import {LOGIN_FAIL, LOGIN_SUCCESS, LOGOUT, UPDATE_USER} from "../../stores/Authentication/actionType";
import {ILocalUser} from "./ILocalUser";
import {IUser} from "./IUser";

interface IAuthenticationLoginFetchSuccess extends ILocalUser { }
interface IAuthenticationUpdateUserFetch extends IUser { }

export interface IAuthenticationLoginSuccess extends Action<typeof LOGIN_SUCCESS> {
 type: typeof LOGIN_SUCCESS;
 payload: IAuthenticationLoginFetchSuccess;
}

export interface IAuthenticationLoginFail extends Action<typeof LOGIN_FAIL> {
 type: typeof LOGIN_FAIL;
 payload: { };
}

export interface IAuthenticationLogout extends Action<typeof LOGOUT> {
 type: typeof LOGOUT;
 payload: {};
}

export interface IAuthenticationUpdateUser extends Action<typeof UPDATE_USER> {
 type: typeof UPDATE_USER;
 payload: IAuthenticationUpdateUserFetch;
}

export type AuthenticationsActions =
    IAuthenticationLoginSuccess
    | IAuthenticationLoginFail
    | IAuthenticationLogout
    | IAuthenticationUpdateUser
 ;
