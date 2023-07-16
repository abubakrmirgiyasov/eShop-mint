import React, { FC, useState } from "react";
import { IUser } from "../../services/types/IUser";
import { Dropdown, DropdownMenu, DropdownToggle } from "reactstrap";
import { Link } from "react-router-dom";

type ICurrentUser = {
  user: IUser;
};

const UserMenu: FC<ICurrentUser> = ({ user }) => {
  const [isProfileDropdown, setIsProfileDropdown] = useState<boolean>(false);

  const toggleUserMenuDropdown = () => {
    setIsProfileDropdown(!isProfileDropdown);
  };

  return (
    <React.Fragment>
      <Dropdown
        isOpen={isProfileDropdown}
        toggle={toggleUserMenuDropdown}
        className={"ms-sm-3 header-item topbar-user"}
      >
        <DropdownToggle
          tag={"button"}
          type={"button"}
          className={"btn border-0"}
        >
          <span className={"d-flex align-items-center"}>
            <img
              className={"rounded-circle header-profile-user"}
              src={user.image}
              alt={"pic"}
            />
            <span className={"text-start ms-xl-2"}>
              <span
                className={
                  "d-none d-xl-inline-block ms-1 fw-medium user-name-text"
                }
              >
                {`${user.firstName} ${user.secondName}`}
              </span>
              <span
                className={
                  "d-none d-xl-block ms-1 fs-12 text-muted user-name-sub-text"
                }
              >
                {/*Role*/}
              </span>
            </span>
          </span>
        </DropdownToggle>
        <DropdownMenu className={"dropdown-menu-end"}>
          <h6 className={"dropdown-header"}>Добро пожаловать {user.email}!</h6>
          <Link to={"/profile/info"} className={"dropdown-item"}>
            <i
              className={
                "ri-account-circle-line text-muted fs-16 align-middle me-1"
              }
            ></i>
            <span className={"align-middle"}>Мой профиль</span>
          </Link>
          <Link to={"/wishlist"} className={"dropdown-item"}>
            <i
              className={"ri-heart-2-line text-muted fs-16 align-middle me-1"}
            ></i>
            <span className="align-middle">Список желаний</span>
          </Link>
          <Link to={"/profile/orders"} className={"dropdown-item"}>
            <i
              className={
                "ri-shopping-bag-3-line text-muted fs-16 align-middle me-1"
              }
            ></i>
            <span className={"align-middle"}>Заказы</span>
          </Link>
          <div className={"dropdown-divider"}></div>
          <Link to={"/logout"} className={"dropdown-item"}>
            <i
              className={
                "ri-logout-box-line text-muted fs-16 align-middle me-1"
              }
            ></i>
            <span className={"align-middle"}>Выйти</span>
          </Link>
        </DropdownMenu>
      </Dropdown>
    </React.Fragment>
  );
};

export default UserMenu;
