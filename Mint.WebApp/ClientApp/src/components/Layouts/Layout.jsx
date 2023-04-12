import React, { useEffect, useState } from "react";
import Header from "../Header/Header";
import Menu from "../Header/Menu";
import { useDispatch, useSelector } from "react-redux";
import { changeLayoutMode, changeLayoutType } from '../../store/theme/reducer';

const Layout = ({ children }) => {
  const [headerClass, setHeaderClass] = useState("");
  const dispatch = useDispatch();

  const { layout, layoutModeType } = useSelector((state) => ({
    layout: state.Theme.layout,
    layoutModeType: state.Theme.layoutModeType,
  }));

  useEffect(() => {
    if (layout)
      dispatch(changeLayoutMode(layout));
      
    dispatch(changeLayoutType("horizontal"));
  }, [layout, layoutModeType, dispatch]);

  const onChangeLayoutMode = (value) => {
    if (changeLayoutMode)
      dispatch(changeLayoutMode(value));
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
      <div id="layout-wrapper">
        <Header
          headerClass={headerClass}
          layoutModeType={layout}
          onChangeLayoutMode={onChangeLayoutMode}
        />
        <Menu />
        <div className="main-content">{children}</div>
      </div>
    </React.Fragment>
  );
};

export default Layout;
