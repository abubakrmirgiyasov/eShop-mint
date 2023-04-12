import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import { Provider } from "react-redux";
import configureStore from "./store";
import * as serviceWorkerRegistration from "./serviceWorkerRegistration";
import reportWebVitals from "./reportWebVitals";

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");
const root = createRoot(rootElement);

root.render(
  <Provider store={configureStore}>
    <React.Fragment>
      <BrowserRouter basename={baseUrl}>
        <App />
      </BrowserRouter>
    </React.Fragment>
  </Provider>
);

serviceWorkerRegistration.unregister();

reportWebVitals();
