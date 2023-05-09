import React, { useEffect, useState } from "react";
import Header from "../Header/Header";
import Menu from "../Header/Menu";
import { useDispatch, useSelector } from "react-redux";
import { changeLayoutMode, changeLayoutType } from "../../store/theme/reducer";
import { ToastContainer } from "react-toastify";
import { menu } from "../../Common/Categories/categories";

// media
import "react-toastify/dist/ReactToastify.css";
import PlaceHolder from "../../Pages/test";
import Footer from "../Footer/Footer";
// import { myStore } from "../../Common/UserStores/myStore";

const Layout = ({ children }) => {
  const [headerClass, setHeaderClass] = useState("");
  const dispatch = useDispatch();

  const { layout, layoutModeType, menuData } = useSelector((state) => ({
    layout: state.Theme.layout,
    layoutModeType: state.Theme.layoutModeType,
    menuData: state.Categories.menu,
  }));

  useEffect(() => {
    if (layout) dispatch(changeLayoutMode(layout));

    dispatch(menu());
    dispatch(changeLayoutType("horizontal"));
    // dispatch(myStore());
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
          limit={1}
          hideProgressBar={false}
          newestOnTop={false}
          closeOnClick={true}
          rtl={false}
          pauseOnFocusLoss={true}
          draggable={true}
          pauseOnHover={true}
          theme="colored"
        />
      </div>
    </React.Fragment>
  );
};

export default Layout;
