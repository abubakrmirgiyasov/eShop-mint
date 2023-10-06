import axios from "axios";

interface IUseAxiosOptions {
    headers?: Record<string, string>
}

export const useAxios = () => {
    const instance = axios.create({
        baseURL: "",
        timeout: 1000 * 5,
        headers: {
            "Content-Type": "application/json",
            "Authorization": `${true ? "Bearer" : "asd"}`,
        },
    });

    const get = (url: string) => {
        return instance.get(url);
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