import React from "react";
import "./custom.css";
import "./assets/scss/themes.scss";
import MainRoute from "./Routes/MainRoute";

import { loadAnimation } from "lottie-web";
import { defineElement } from "lord-icon-element";

defineElement(loadAnimation);

const App = () => {
  return (
    <React.Fragment>
      <MainRoute />
    </React.Fragment>
  );
};

export default App;
