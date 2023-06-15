import React from "react";
import { Link } from "react-router-dom";
import ThemeToggle from "../../../components/Header/ThemeToggle";

///////////////////////////////////////////////////////
import LogoSm from "../../../assets/images/test-logo.png";
import LogoDark from "../../../assets/images/test-logo.png";
import LogoLight from "../../../assets/images/test-logo.png";
import AdminSettings from "./AdminSettings";
import AdminMenu from "./AdminMenu";

const AdminHeader = ({ headerClass, layoutModeType, onChangeLayoutMode }) => {
  const toggleMenuBtn = () => {
    var windowSize = document.documentElement.clientWidth;

    if (windowSize > 767) {
      document.querySelector(".hamburger-icon").classList.toggle("open");
    }

    if (document.documentElement.getAttribute("data-layout") === "horizontal")
      document.body.classList.contains("menu")
        ? document.body.classList.remove("menu")
        : document.body.classList.add("menu");

    if (document.documentElement.getAttribute("data-layout") === "vertical") {
      if (windowSize < 1025 && windowSize > 767) {
        document.body.classList.remove("vertical-sidebar-enable");
        document.documentElement.getAttribute("data-sidebar-size") === "sm"
          ? document.documentElement.setAttribute("data-sidebar-size", "")
          : document.documentElement.setAttribute("data-sidebar-size", "sm");
      } else if (windowSize > 1025) {
        document.body.classList.remove("vertical-sidebar-enable");
        document.documentElement.getAttribute("data-sidebar-size") === "lg"
          ? document.documentElement.setAttribute("data-sidebar-size", "sm")
          : document.documentElement.setAttribute("data-sidebar-size", "lg");
      } else if (windowSize <= 767) {
        document.body.classList.add("vertical-sidebar-enable");
        document.documentElement.setAttribute("data-sidebar-size", "lg");
      }
    }
  };

  return (
    <React.Fragment>
      <header id="page-topbar" className={headerClass}>
        <div className="layout-width">
          <div className="navbar-header">
            <div className="d-flex">
              <div className="navbar-brand-box horizontal-logo">
                <Link to="/" className="logo logo-dark">
                  <span className="logo-sm">
                    <img src={LogoSm} alt="" height="22" />
                  </span>
                  <span className="logo-lg">
                    <img src={LogoDark} alt="" height="17" />
                  </span>
                </Link>
                <Link to="/" className="logo logo-light">
                  <span className="logo-sm">
                    <img src={LogoSm} alt="" height="22" />
                  </span>
                  <span className="logo-lg">
                    <img src={LogoLight} alt="" height="17" />
                  </span>
                </Link>
              </div>
              <button
                onClick={toggleMenuBtn}
                type="button"
                className="btn btn-sm-px-3 fs-16 header-item vertical-menu-btn topnav-hamburger"
                id="topnav-hamburger-icon"
              >
                <span className="hamburger-icon">
                  <span></span>
                  <span></span>
                  <span></span>
                </span>
              </button>
            </div>
            <div className="d-flex align-items-center">
              <ThemeToggle
                layoutModeType={layoutModeType}
                onChangeLayoutMode={onChangeLayoutMode}
              />
              <AdminSettings />
              <AdminMenu />
            </div>
          </div>
        </div>
      </header>
    </React.Fragment>
  );
};

export default AdminHeader;
