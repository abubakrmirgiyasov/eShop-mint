import React, { FC, ReactNode, useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { IAuth } from "../../services/types/IAuth";
import { ToastContainer } from "react-toastify";
import Header from "../Header/Header";
import { Error } from "../Notifications/Error";

// media
import "react-toastify/dist/ReactToastify.css";
import { switchLayout } from "../../store/theme/theme";

interface ILayout {
  children: ReactNode;
}

const Layout: FC<ILayout> = ({ children }) => {
  const [headerClass, setHeaderClass] = useState<string>("");

  const dispatch = useDispatch();

  const { auth, error }: { auth: IAuth; error: string } = useSelector(
    (state) => ({
      auth: state.Auth,
      error: state.Message.message,
    })
  );

  useEffect(() => {
    if (auth.isLoggedIn) console.log("here we get all liked prod");

    dispatch(switchLayout("horizontal"));

    window.addEventListener("scroll", scrollNavigation, true);
  }, [auth, dispatch]);

  const scrollNavigation = () => {
    let scrollUp = document.documentElement.scrollTop;
    setHeaderClass(scrollUp > 50 ? "top-shadow" : "");
  };

  return (
    <React.Fragment>
      <div id={"layout-wrapper"}>
        {error && <Error message={error} />}
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
