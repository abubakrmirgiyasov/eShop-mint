import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import * as serviceWorkerRegistration from "./serviceWorkerRegistration";
import reportWebVitals from "./reportWebVitals";
import { Provider } from "react-redux";
import { store } from "./store";

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");
const root = createRoot(rootElement);

root.render(
  <React.Fragment>
    <Provider store={store}>
      <BrowserRouter basename={baseUrl}>
        <App />
      </BrowserRouter>
    </Provider>
  </React.Fragment>
);

serviceWorkerRegistration.unregister();

reportWebVitals();
