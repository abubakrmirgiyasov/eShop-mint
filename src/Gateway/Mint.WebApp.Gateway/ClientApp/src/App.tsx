import React from "react";
import MainRoute from "./routes/MainRoute";

// media
import "./assets/scss/themes.scss";
import "remixicon/fonts/remixicon.css";
import "react-phone-input-2/lib/style.css";
import "swiper/css";
import "swiper/css/navigation";
import "swiper/css/pagination";
import "swiper/css/scrollbar";

function App() {
  return (
    <React.Fragment>
      <MainRoute />
    </React.Fragment>
  );
}

export default App;
