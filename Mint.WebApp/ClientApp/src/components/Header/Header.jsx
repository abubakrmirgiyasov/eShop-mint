import React, { useState } from "react";
import { Link } from "react-router-dom";
import {
  Dropdown,
  DropdownMenu,
  DropdownToggle,
  Form,
  Input,
} from "reactstrap";
import LanguageList from "./LanguageList";
import CartList from "./CartList";
import ThemeToggle from "./ThemeToggle";
import LikesList from "./LikesList";
import NotificationList from "./NotificationList";
import UserMenu from "./UserMenu";
import Signin from "../../Pages/Auth/Signin";
import { useSelector } from "react-redux";
import PrivateComponent from "../../helpers/privateComponent";
import { Roles } from "../../constants/Roles";

//images
import LogoSm from "../../assets/images/logo-sm.png";
import LogoDark from "../../assets/images/logo-dark.png";
import LogoLight from "../../assets/images/logo-light.png";

const Header = (props) => {
  const [value, setValue] = useState("");
  const [isSearch, setIsSearch] = useState(false);
  const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);

  const { Signin: user } = useSelector((user) => user);

  const onChangeData = (e) => {};

  const toggleLoginModal = () => {
    setIsLoginModalOpen(!isLoginModalOpen);
  };

  const toggleMenuBtn = () => {
    let windowSize = document.documentElement.clientWidth;

    if (windowSize > 767)
      document.querySelector(".hamburger-icon").classList.toggle("open");

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
      <header id="page-topbar" className={props.headerClasss}>
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
                className="btn btn-sm px-3 fs-16 header-item vertical-menu-btn topnav-hamburger"
                id="topnav-hamburger-icon"
              >
                <span className="hamburger-icon">
                  <span></span>
                  <span></span>
                  <span></span>
                </span>
              </button>
              <Form className="app-search d-none d-md-block">
                <div className="position-relative">
                  <Input
                    type="text"
                    className="form-control"
                    placeholder="Поиск..."
                    defaultValue={value}
                    onChange={onChangeData}
                  />
                  <span className="mdi mdi-magnify search-widget-icon"></span>
                  <span
                    className="mdi mdi-close-circle search-widget-icon search-widget-icon-close d-none"
                    id="search-close-options"
                  ></span>
                </div>
              </Form>
            </div>
            <div className="d-flex align-items-center">
              <Dropdown
                isOpen={isSearch}
                toggle={() => setIsSearch(!isSearch)}
                className="d-md-none topbar-head-dropdown header-item"
              >
                <DropdownToggle
                  tag="button"
                  className="btn btn-icon btn-topbar btn-ghost-secondary rounded-circle"
                >
                  <i className="bx bx-search fs-22"></i>
                </DropdownToggle>
                <DropdownMenu className="dropdown-menu-lg dropdown-menu-end p-0">
                  <Form className="p-3">
                    <div className="form-group m-0">
                      <div className="input-group">
                        <Input
                          type="text"
                          className="form-control"
                          placeholder="Поиск..."
                          defaultValue={""}
                        />
                        <button className="btn btn-primary" type="submit">
                          <i className="mdi mdi-magnify"></i>
                        </button>
                      </div>
                    </div>
                  </Form>
                </DropdownMenu>
              </Dropdown>

              {<LanguageList />}
              {<CartList />}
              {<LikesList />}
              {
                <ThemeToggle
                  layoutModeType={props.layoutModeType}
                  onChangeLayoutMode={props.onChangeLayoutMode}
                />
              }
              {<NotificationList />}
              {user.isLoggedIn ? (
                <>
                  <UserMenu />
                  {
                    <PrivateComponent>
                      <div
                        className="ms-sm-3 header-item topbar-user"
                        roles={[Roles.Admin, Roles.Seller]}
                      >
                        <Link
                          to="/admin/admin-dashboard"
                          className="btn bg-light fs-5 rounded btn-icon"
                          style={{ padding: "2rem 3rem" }}
                        >
                          <span className="d-flex align-items-center user-name-text">
                            <i className="ri-shield-user-line"></i>
                            <span className="text-start ms-xl-2">Админ</span>
                          </span>
                        </Link>
                      </div>
                    </PrivateComponent>
                  }
                </>
              ) : (
                <>
                  <div className="ms-sm-3 header-item topbar-user">
                    <button
                      className="btn bg-light fs-5 rounded btn-icon"
                      style={{ padding: "2rem 3rem" }}
                      onClick={() => setIsLoginModalOpen(true)}
                    >
                      <span className="d-flex align-items-center user-name-text">
                        <i className="ri-login-box-line"></i>
                        <span className="text-start ms-xl-2">Войти</span>
                      </span>
                    </button>
                  </div>
                  <Signin isOpen={isLoginModalOpen} toggle={toggleLoginModal} />
                </>
              )}
            </div>
          </div>
        </div>
      </header>
    </React.Fragment>
  );
};

export default Header;
