import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import Request from "./helpers/requestWrapper/request";
import { ApiConfiguration } from "./helpers/requestWrapper/types";
import configureStore from "./store/index";
import { BrowserRouter } from "react-router-dom";
import { Provider } from "react-redux";
import authHeader from "./services/authentication/authHeader";

// const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");

const settings = new ApiConfiguration();
settings.accessToken = authHeader();
const request = new Request(settings);

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
    <Provider store={configureStore}>
        <React.StrictMode>
            <BrowserRouter>
                <App request={request} />
            </BrowserRouter>
        </React.StrictMode>
    </Provider>
);
