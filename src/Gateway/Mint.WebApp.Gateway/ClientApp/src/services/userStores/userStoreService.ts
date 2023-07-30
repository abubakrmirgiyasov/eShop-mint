import Request from "../../helpers/requestWrapper/request";

export const getMyStore = (request: Request) => {
    return request
        .get("/").then((response) => {

        }).catch((error) => {
            throw error;
        })
};