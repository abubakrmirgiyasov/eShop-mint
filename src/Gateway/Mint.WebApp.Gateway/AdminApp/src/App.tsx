import React, {FC} from "react";
import Index from "./components/Index";
import { loadAnimation } from "lottie-web";
import { defineElement } from "lord-icon-element";
defineElement(loadAnimation);

// static files
import "./assets/scss/themes.scss";
import "remixicon/fonts/remixicon.css";
import "react-phone-input-2/lib/style.css";
import "swiper/css";
import "swiper/css/navigation";
import "swiper/css/pagination";
import "swiper/css/scrollbar";
import 'react-toastify/dist/ReactToastify.css';

const App: FC = () => {
  return (
    <React.Fragment>
      <Index />
    </React.Fragment>
  );
}

export default App;
