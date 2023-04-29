import React, { useState } from "react";
import { useSelector } from "react-redux";
import {
  Dropdown,
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
} from "reactstrap";

const AdminMenu = () => {
  const [isOpen, setIsOpen] = useState(false);
  const user = useSelector((user) => user.Signin.user);

  const toggleIsOpen = () => {
    setIsOpen(!isOpen);
  };

  return (
    <React.Fragment>
      <Dropdown
        isOpen={isOpen}
        toggle={toggleIsOpen}
        className="ms-sm-3 header-item topbar-user"
      >
        <DropdownToggle type={"button"} tag={"button"} className="btn">
          <span className="d-flex align-items-center">
            <img
              className="rounded-circle header-profile-user"
              src={user.imagePath}
              alt="Header Avatar"
            />
            <span className="text-start ms-xl-2">
              <span className="d-none d-xl-inline-block ms-1 fw-medium user-name-text">
                {`${user.firstName} ${user.secondName}`}
              </span>
              <span className="d-none d-xl-block ms-1 fs-12 text-muted user-name-sub-text">
                Role
              </span>
            </span>
          </span>
        </DropdownToggle>
        <DropdownMenu>
          <h6 className="dropdown-header">Добро пожаловать!</h6>
          <DropdownItem tag={"a"} href={process.env.PUBLIC_URL + "/home"}>
            <i className="ri-arrow-go-back-line text-muted fs-16 align-middle me-1"></i>
            <span className="align-middle">Назад</span>
          </DropdownItem>
          <div className="dropdown-divider"></div>
          <DropdownItem href={process.env.PUBLIC_URL + "/user-profile"}>
            <i className="mdi mdi-account-circle text-muted fs-16 align-middle me-1"></i>
            <span className="align-middle">Профиль</span>
          </DropdownItem>
          <DropdownItem href={process.env.PUBLIC_URL + "/logout"}>
            <i className="mdi mdi-logout text-muted fs-16 align-middle me-1"></i>
            <span className="align-middle">Выйти</span>
          </DropdownItem>
        </DropdownMenu>
      </Dropdown>
    </React.Fragment>
  );
};

export default AdminMenu;
