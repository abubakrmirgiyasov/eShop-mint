import React, { useEffect, useState } from "react";
import AdminHeader from "../../Admin/components/Header/AdminHeader";
import AdminSidebar from "../Header/AdminSidebar";
import { useDispatch, useSelector } from "react-redux";
import {
  changeLayoutBackground,
  changeLayoutMode,
  changeLayoutType,
} from "../../store/theme/reducer";
import { changeLayoutTypeSize } from "../../store/theme/reducer";
import { Roles } from "../../constants/Roles";
import { useNavigate } from "react-router-dom";

const AdminLayout = ({ children }) => {
  const [headerClass, setHeaderClass] = useState("");
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { layout, user } = useSelector((state) => ({
    layout: state.Theme.layout,
    user: state.Signin.user,
  }));

  useEffect(() => {
    if (layout) {
      dispatch(changeLayoutMode(layout));
      dispatch(changeLayoutBackground(layout));
    }

    dispatch(changeLayoutType("vertical"));
    dispatch(changeLayoutTypeSize("lg"));
  }, [layout, dispatch]);

  const onChangeLayoutMode = (value) => (dispatch) => {
    if (changeLayoutMode) {
      dispatch(changeLayoutMode(value));
      dispatch(changeLayoutBackground(value));
    }
  };

  useEffect(() => {
    window.addEventListener("scroll", scrollNavigation, true);
  });

  function scrollNavigation() {
    setHeaderClass(document.documentElement.scrollTop > 50 ? "top-shadow" : "");
  }

  window.onscroll = function() {
    const element = document.getElementById("back-to-top");

    if (element) {
      if (document.body.scrollTop > 100 || document.documentElement.scrollTop > 100) {
        element.style.display = "block";
      } else {
        element.style.display = "none";
      }
    }
  }

  const toTop = (e) => {
    e.preventDefault();
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
  }

  useEffect(() => {
    if (user.roles.length !== 3) {
      user.roles.map((role) => {
        if (
          role.value !== Roles.Admin.value ||
          role.value !== Roles.Seller.value
        ) {
          navigate("/admin/admin-signin");
        }
      });
    }
  }, [user]);

  return (
    <React.Fragment>
      <div id="layout-wrapper">
        <AdminHeader
          headerClass={headerClass}
          onChangeLayoutMode={onChangeLayoutMode}
          layoutModeType={layout}
        />
        <AdminSidebar layoutType={"vetical"} />
        <div className="main-content">{children}</div>
        <button
          type="button"
          onClick={toTop}
          className="btn btn-danger btn-icon landing-back-top"
          id="back-to-top"
        >
          <i className="ri-arrow-up-line"></i>
        </button>
      </div>
    </React.Fragment>
  );
};

export default AdminLayout;
