import React from "react";
import MainRoute from "./routes/MainRoute";
import Request from "./helpers/requestWrapper/request";
// media
import "./assets/scss/themes.scss";
import "remixicon/fonts/remixicon.css";

function App({ request }: Request) {
  return (
    <React.Fragment>
      <MainRoute request={request} />
    </React.Fragment>
  );
}

export default App;
