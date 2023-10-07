import axios from "axios";
import {useProfile} from "./useProfile";

interface IUseAxiosOptions {
    headers?: Record<string, string>
}

export const useAxios = () => {
    const user = useProfile();

    const instance = axios.create({
        baseURL: "",
        timeout: 1000 * 5,
        headers: {
            "Content-Type": "application/json",
            "Authorization": `${user.token ? `Bearer ${user.token}` : ""}`,
        },
    });

    const get = (url: string) => {
        return instance.get(url)
            .then((response) => {
                return response;
            }).catch((error) => {
                if (error.message === "Unauthorized") {
                    console.log("Unauthorized Unauthorized Unauthorized Unauthorized Unauthorized Unauthorized")
                }
                throw error;
            });
    };

    const post = <TData>(url: string, data: TData) => {
        return instance.post(url, data);
    };

    const put = <TData>(url: string, data: TData) => {
        return instance.put(url, data);
    };

    const del = (url: string) => {
        return instance.delete(url);
    };

    return {get, post, put, del};
};