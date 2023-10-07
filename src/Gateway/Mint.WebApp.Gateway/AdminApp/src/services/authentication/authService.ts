import {ISignIn} from "../../types/Authentication/ISignIn";
import {useAxios} from "../../hooks/useAxios";
import {ADMIN_SIGN_IN, ADMIN_SIGN_OUT, ADMIN_USER_UPDATE} from "../../constants/urls";
import {IUser} from "../../types/Authentication/IUser";

export const signInRequest = (values: ISignIn) => {
    const axios = useAxios();

    return axios.post(ADMIN_SIGN_IN, values)
        .then((response) => {
            return response;
        })
        .catch((error) => {
            throw error;
        });
};

export const logoutRequest = () => {
    const axios = useAxios();

    return axios.del(ADMIN_SIGN_OUT)
        .then((response) => {
            return response;
        })
        .catch((error) => {
            return error;
        });
};

export const updateUser = (values: IUser) => {
    const axios = useAxios();

    return axios.put(ADMIN_USER_UPDATE, values)
        .then((response) => {
            return response;
        })
        .catch((error) => {
            throw  error;
        });
};
