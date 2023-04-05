import React, { useState } from "react";
import { Link } from "react-router-dom";
import LogoSm from "../../assets/images/logo-sm.png";
import LogoDark from "../../assets/images/logo-dark.png";
import LogoLight from "../../assets/images/logo-light.png";
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
import { useDispatch, useSelector } from "react-redux";
import UserMenu from "./UserMenu";
import Signin from "../../Pages/Auth/Signin";

const Header = (props) => {
  const [value, setValue] = useState("");
  const [isSearch, setIsSearch] = useState(false);
  const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);

  const { user: authUser } = useSelector((user) => user.auth);

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
                    onChange={(e) => {
                      onChangeData(e.target.value);
                    }}
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
              {<ThemeToggle />}
              {<NotificationList />}

              {authUser ? (
                <UserMenu />
              ) : (
                <>
                  <div className="d-flex justify-content-center align-items-center">
                    <button
                      className="btn bg-light ms-4 fs-5 rounded btn-icon"
                      style={{ padding: "2rem 3rem" }}
                      onClick={() => setIsLoginModalOpen(true)}
                    >
                      <i className="ri-login-box-line"></i> Войти
                    </button>
                  </div>
                  <Signin 
                    isOpen={isLoginModalOpen}
                    toggle={toggleLoginModal}
                  />
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
