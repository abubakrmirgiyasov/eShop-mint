import React, { useEffect, useState } from "react";
import Header from "../Header/Header";
import Menu from "../Header/Menu";
import { useDispatch, useSelector } from "react-redux";
import { changeLayoutMode, changeLayoutType } from "../../store/theme/reducer";
import { ToastContainer } from "react-toastify";
import { menu } from "../../Common/Categories/categories";
import { toggleLikes } from "../../Common/Likes/likes";

// media
import "react-toastify/dist/ReactToastify.css";
import PlaceHolder from "../../components/Placeholder/Placeholder";
import Footer from "../Footer/Footer";

const Layout = ({ children }) => {
  const [headerClass, setHeaderClass] = useState("");
  const dispatch = useDispatch();

  const { layout, layoutModeType, menuData, signIn } = useSelector(
    (state) => ({
      layout: state.Theme.layout,
      layoutModeType: state.Theme.layoutModeType,
      menuData: state.Categories.menu,
      myLikes: state.Likes.likes,
      signIn: state.Signin,
    })
  );

  useEffect(() => {
    if (layout) dispatch(changeLayoutMode(layout));

    if (signIn.isLoggedIn)
      dispatch(toggleLikes(signIn.user.id));
  
      dispatch(menu());
    dispatch(changeLayoutType("horizontal"));
  }, [layout, layoutModeType, dispatch]);

  const onChangeLayoutMode = (value) => {
    if (changeLayoutMode) dispatch(changeLayoutMode(value));
  };

  useEffect(() => {
    window.addEventListener("scroll", scrollNavigation, true);
  });

  function scrollNavigation() {
    let scrollUp = document.documentElement.scrollTop;
    setHeaderClass(scrollUp > 50 ? "top-shadow" : "");
  }

  return (
    <React.Fragment>
      <div id={"layout-wrapper"}>
        <Header
          headerClass={headerClass}
          layoutModeType={layout}
          onChangeLayoutMode={onChangeLayoutMode}
        />
        {!menuData ? (
          <PlaceHolder />
        ) : (
          <>
            <Menu />
            <div className={"main-content"}>
              {children}
              <Footer />
            </div>
          </>
        )}
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
