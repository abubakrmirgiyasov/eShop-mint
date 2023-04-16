import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import {
  Dropdown,
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
} from "reactstrap";

import avatar1 from "../../assets/images/users/avatar-1.jpg";

const UserMenu = () => {
  const { Signin: isLoggedIn } = useSelector((user) => user);

  useEffect(() => {}, []);

  const [isProfileDropDown, setIsProfileDropDown] = useState(false);

  return (
    <React.Fragment>
      <Dropdown
        isOpen={isProfileDropDown}
        toggle={() => setIsProfileDropDown(!isProfileDropDown)}
        className="ms-sm-3 header-item topbar-user"
      >
        <DropdownToggle tag="button" type="button" className="btn">
          <span className="d-flex align-items-center">
            <img
              className="rounded-circle header-profile-user"
              src={avatar1}
              alt="Header Avatar"
            />
            <span className="text-start ms-xl-2">
              <span className="d-none d-xl-inline-block ms-1 fw-medium user-name-text">
                {`${isLoggedIn.user?.firstName} ${isLoggedIn.user?.secondName}`}
              </span>
              <span className="d-none d-xl-block ms-1 fs-12 text-muted user-name-sub-text">
                Role
              </span>
            </span>
          </span>
        </DropdownToggle>
        <DropdownMenu className="dropdown-menu-end">
          <h6 className="dropdown-header">
            Добро пожаловать {isLoggedIn.user?.email}!
          </h6>
          <DropdownItem href={process.env.PUBLIC_URL + "/profile"}>
            <i className="mdi mdi-account-circle text-muted fs-16 align-middle me-1"></i>
            <span className="align-middle">Мой профиль</span>
          </DropdownItem>
          <DropdownItem href={process.env.PUBLIC_URL + "/wishlist"}>
            <i className="bx bx-heart text-muted fs-16 align-middle me-1"></i>
            <span className="align-middle">Список желаний</span>
          </DropdownItem>
          <DropdownItem href={process.env.PUBLIC_URL + "/orders"}>
            <i className="ri-shopping-bag-3-line text-muted fs-16 align-middle me-1"></i>
            <span className="align-middle">Заказы</span>
          </DropdownItem>
          <div className="dropdown-divider"></div>
          <DropdownItem href={process.env.PUBLIC_URL + "/logout"}>
            <i className="ri-logout-box-line text-muted fs-16 align-middle me-1"></i>
            <span className="align-middle">Выйти</span>
          </DropdownItem>
        </DropdownMenu>
      </Dropdown>
    </React.Fragment>
  );
};

export default UserMenu;
