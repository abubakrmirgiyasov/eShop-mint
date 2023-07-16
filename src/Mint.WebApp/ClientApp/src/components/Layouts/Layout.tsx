import React, { FC, ReactNode, useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { IAuth } from "../../services/types/IAuth";
import { ToastContainer } from "react-toastify";
import Header from "../Header/Header";

// media
import "react-toastify/dist/ReactToastify.css";

interface ILayout {
  children: ReactNode;
}

const Layout: FC<ILayout> = ({ children }) => {
  const [headerClass, setHeaderClass] = useState<string>("");

  const { auth }: { auth: IAuth } = useSelector((state) => ({
    auth: state.Auth,
  }));

  useEffect(() => {
    if (auth.isLoggedIn) console.log("here we get all liked prod");

    window.addEventListener("scroll", scrollNavigation, true);
  }, [auth]);

  const scrollNavigation = () => {
    let scrollUp = document.documentElement.scrollTop;
    setHeaderClass(scrollUp > 50 ? "top-shadow" : "");
  };

  return (
    <React.Fragment>
      <div id={"layout-wrapper"}>
        <Header headerClass={headerClass} />
        <div className={"main-content"}>{children}</div>
        <ToastContainer
          position={"top-right"}
          autoClose={5000}
          limit={10}
          hideProgressBar={false}
          newestOnTop={true}
          closeOnClick={true}
          rtl={false}
          pauseOnFocusLoss={true}
          draggable={true}
          pauseOnHover={true}
          theme={"colored"}
        />
      </div>
    </React.Fragment>
  );
};

export default Layout;
