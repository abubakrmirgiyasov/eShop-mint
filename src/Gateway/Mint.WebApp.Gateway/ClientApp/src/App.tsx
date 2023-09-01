import React from "react";
import MainRoute from "./routes/MainRoute";
// media
import "./assets/scss/themes.scss";
import "remixicon/fonts/remixicon.css";
import "react-phone-input-2/lib/style.css";
import axios from "axios";

function App() {
  axios
    .get("/gate/tag/gettags")
    .then((t) => console.log(t))
    .catch((er) => console.log(er));

  return (
    <React.Fragment>
      <MainRoute />
    </React.Fragment>
  );
}

export default App;
