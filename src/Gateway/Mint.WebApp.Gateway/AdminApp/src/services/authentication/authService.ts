import {ISignIn} from "../../types/Authentication/ISignIn";
import {IRequest, useAxios} from "../../hooks/useAxios";
import {
    ADMIN_SIGN_IN,
    ADMIN_SIGN_OUT,
    ADMIN_USER_UPDATE,
} from "../../constants/urls";
import {IUser} from "../../types/Authentication/IUser";
import {ILocalUser} from "../../types/Authentication/ILocalUser";

export const signInRequest = (axios: IRequest, values: ISignIn) => {
    return axios
        .post(ADMIN_SIGN_IN, values)
        .then((response) => {
            const data: ILocalUser = response.data;
            localStorage.setItem("c_user", JSON.stringify(data));
            return data;
        })
        .catch((error) => {
            throw error;
        });
};

export const logoutRequest = () => {
    const axios = useAxios();

    return axios
        .del(ADMIN_SIGN_OUT)
        .then((response) => {
            return response;
        })
        .catch((error) => {
            return error;
        });
};

export const updateUser = (values: IUser) => {
    const axios = useAxios();

    return axios
        .put(ADMIN_USER_UPDATE, values)
        .then((response) => {
            return response;
        })
        .catch((error) => {
            throw error;
        });
};
