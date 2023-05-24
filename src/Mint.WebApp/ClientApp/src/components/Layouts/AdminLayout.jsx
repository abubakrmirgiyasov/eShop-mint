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
import { ToastContainer } from "react-toastify";
import { myStore } from "../../Common/UserStores/myStore";

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
    dispatch(myStore());
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

  window.onscroll = function () {
    const element = document.getElementById("back-to-top");

    if (element) {
      if (
        document.body.scrollTop > 100 ||
        document.documentElement.scrollTop > 100
      ) {
        element.style.display = "block";
      } else {
        element.style.display = "none";
      }
    }
  };

  const toTop = (e) => {
    e.preventDefault();
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
  };

  useEffect(() => {
    if (!user) {
      navigate("/admin/admin-signin");
    }

    // const requiredRoles = [Roles.Seller, Roles.Admin];
    // const hasRequiredRoles =
    //   user.roles.filter((role) => requiredRoles.includes(role)).length ===
    //   requiredRoles.length;
    //
    // if (!hasRequiredRoles) {
    //   navigate("/admin/admin-signin");
    // }

    if (user.roles.length !== 3) {
      let isAccessed = false;

      for (let i = 0; i < user.roles.length; i++) {
        if (
          user.roles[i].value === Roles.Seller.value ||
          user.roles[i].value === Roles.Admin.value
        ) {
          isAccessed = true;
          break;
        } else {
          isAccessed = false;
        }
      }

      if (!isAccessed) navigate("/admin/admin-signin");
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

      <ToastContainer
        position="top-right"
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
    </React.Fragment>
  );
};

export default AdminLayout;
