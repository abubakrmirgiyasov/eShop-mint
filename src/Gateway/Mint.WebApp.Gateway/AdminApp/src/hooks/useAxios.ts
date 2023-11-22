import axios, {AxiosError, AxiosRequestConfig, AxiosResponse} from "axios";
import {useProfile} from "./useProfile";
import {useNavigate} from "react-router-dom";
import {signOutStore} from "../stores/Authentication/authActions";
import {useDispatch} from "react-redux";

export interface IRequest {
    get<TResponse>(path: string): Promise<TResponse | void>;

    post<TRequest, TResponse>(
        path: string,
        data: TRequest,
        config?: AxiosRequestConfig
    ): Promise<TResponse | void>;

    put<TRequest, TResponse>(
        path: string,
        data: TRequest,
        config?: AxiosRequestConfig
    ): Promise<TResponse | void>;

    del<TResponse>(path: string): Promise<TResponse>;
}

export const useAxios = (): IRequest => {
    const user = useProfile();
    const navigate = useNavigate();
    const dispatch = useDispatch();

    const instance = axios.create({
        timeout: 1000 * 10,
        headers: {
            "Content-Type": "application/json",
            "X-Auth-Type": "Admin",
            Authorization: `${user.token ? `Bearer ${user.token}` : ""}`,
        },
    });

    const get = <TResponse>(path: string): Promise<AxiosResponse<TResponse> | void> => {
        return instance.get(path)
            .then((response: AxiosResponse) => {
                return response.data;
            })
            .catch((error: AxiosError) => {
                if (error.response.status === 401 || error.message === "Unauthorized") {
                    dispatch(signOutStore(navigate));
                    console.log("Unauthorized Unauthorized Unauthorized Unauthorized Unauthorized Unauthorized");
                }
                throw error;
            });
    };

    const post = <TRequest, TResponse>(path: string, data: TRequest): Promise<TResponse | void> => {
        return instance.post(path, data)
            .then((response: TResponse) => {
                return response;
            }).catch((error: AxiosError) => {
                if (error.message === "Unauthorized") {
                    console.log("Unauthorized Unauthorized Unauthorized Unauthorized Unauthorized Unauthorized");
                }
                throw error;
            });
    };

    const put = <TRequest, TResponse>(path: string, data: TRequest): Promise<TResponse | void> => {
        return instance.put(path, data)
            .then((response: TResponse) => {
                return response;
            }).catch((error: AxiosError) => {
                if (error.message === "Unauthorized") {
                    console.log("Unauthorized Unauthorized Unauthorized Unauthorized Unauthorized Unauthorized");
                }
                throw error;
            });
    };

    const del = <TResponse>(path: string): Promise<TResponse | void> => {
        return instance.delete(path)
            .then((response: TResponse) => {
                return response;
            }).catch((error: AxiosError) => {
                if (error.message === "Unauthorized") {
                    console.log("Unauthorized Unauthorized Unauthorized Unauthorized Unauthorized Unauthorized");
                }
                throw error;
            });
    };

    return {get, post, put, del};
};
