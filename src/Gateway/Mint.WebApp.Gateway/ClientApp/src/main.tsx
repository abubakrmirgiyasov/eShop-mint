import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import configureStore from "./store/index";
import { BrowserRouter } from "react-router-dom";
import { Provider } from "react-redux";

import { loadAnimation } from "lottie-web";
import { defineElement } from "lord-icon-element";

defineElement(loadAnimation);

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <Provider store={configureStore}>
    <React.StrictMode>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </React.StrictMode>
  </Provider>
);
