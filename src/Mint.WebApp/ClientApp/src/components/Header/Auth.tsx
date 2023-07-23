import React, { FC, ReactNode, useState } from "react";
import { Button, Dropdown, DropdownMenu, DropdownToggle } from "reactstrap";
import { Link } from "react-router-dom";
import SignInModal from "../../pages/Authentication/SignInModal";
import SignUpModal from "../../pages/Authentication/SignUpModal";

const Auth: FC<ReactNode> = () => {
  const [isUserMenuOpen, setIsUserMenuOpen] = useState<boolean>(false);
  const [isLoginModalOpen, setIsLoginModalOpen] = useState<boolean>(false);
  const [isSignUpModalOpen, setIsSignUpModalOpen] = useState<boolean>(false);

  const toggleUserOpen = () => {
    setIsUserMenuOpen(!isUserMenuOpen);
  };

  const onSignInClick = () => {
    setIsLoginModalOpen(!isLoginModalOpen);
    setIsUserMenuOpen(false);
  };

  const onSignUpClick = () => {
    setIsSignUpModalOpen(!isSignUpModalOpen);
    setIsUserMenuOpen(false);
  };

  return (
    <React.Fragment>
      <Dropdown
        isOpen={isUserMenuOpen}
        toggle={toggleUserOpen}
        className={"topbar-head-dropdown ms-1 header-item"}
      >
        <DropdownToggle
          type={"button"}
          tag={"button"}
          className={
            "btn btn-icon btn-topbar btn-ghost-secondary rounded-circle"
          }
        >
          <i className={"ri-user-6-line fs-22"}></i>
        </DropdownToggle>
        <DropdownMenu className={"dropdown-menu-end"}>
          <Button
            className={"dropdown-item"}
            onClick={onSignInClick}
            color={"light"}
          >
            <i
              className={"ri-user-6-line text-muted fs-16 align-middle me-1"}
            ></i>
            <span className={"align-middle"}>Войти</span>
          </Button>
          <Button
            className={"dropdown-item"}
            onClick={onSignUpClick}
            color={"light"}
          >
            <i
              className={"ri-user-add-line text-muted fs-16 align-middle me-1"}
            ></i>
            <span className={"align-middle"}>Регистрация</span>
          </Button>
          <div className={"dropdown-divider"}></div>
          <Link className={"dropdown-item"} to={"/"}>
            <i
              className={
                "ri-lock-unlock-line text-muted fs-16 align-middle me-1"
              }
            ></i>
            <span className={"align-middle"}>Забыли пароль?</span>
          </Link>
        </DropdownMenu>
      </Dropdown>

      <SignInModal isOpen={isLoginModalOpen} toggle={onSignInClick} />

      <SignUpModal isOpen={isSignUpModalOpen} toggle={onSignUpClick} />
    </React.Fragment>
  );
};

export default Auth;
