import React, { FC, useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { IAuth } from "../../services/types/IAuth";
import { useSelector } from "react-redux";
import adaptiveMenu from "../../helpers/adaptiveMenu";
import {
  Button,
  Dropdown,
  DropdownMenu,
  DropdownToggle,
  Form,
  Input,
} from "reactstrap";
import { LanguageList } from "./LanguageList";
import { IProduct } from "../../services/types/IProduct";
import { PrivateComponent } from "../../helpers/privateComponent";
import { ILanguage, ITheme } from "../../services/types/ICommon";
import { Roles } from "../../constants/roles";
import CompareList from "./CompareList";
import CartList from "./CartList";
import FavoriteList from "./FavoriteList";
import SearchOptions from "./SearchOptions";
import ThemeToggle from "./ThemeToggle";
import NotificationList from "./NotificationList";
import Auth from "./Auth";
import UserMenu from "./UserMenu";
// media
import Logo from "../../assets/images/logos/logo-light.png";
import LogoSm from "../../assets/images/logos/Logo.png";

interface IHeader {
  headerClass: string;
}

const Header: FC<IHeader> = ({ headerClass }) => {
  const [isSearch, setIsSearch] = useState<boolean>(false);

  const {
    auth,
    favorites,
    compares,
    cart,
    theme,
    language,
  }: {
    auth: IAuth;
    favorites: IProduct[];
    cart: IProduct[];
    compares: IProduct[];
    theme: ITheme;
    language: ILanguage;
  } = useSelector((state) => ({
    auth: state.Auth,
    favorites: state.Favorites.likes,
    compares: state.Compare.products,
    cart: state.Cart.cart,
    theme: state.Theme,
    language: state.Language,
  }));

  const toggleMenu = () => {
    adaptiveMenu();
  };

  const toggleSearchDropdown = () => setIsSearch(!isSearch);

  return (
    <React.Fragment>
      <header id={"page-topbar"} className={headerClass}>
        <div className={"layout-width"}>
          <div className={"navbar-header"}>
            <div className={"d-flex"}>
              <div className={"navbar-brand-box horizontal-logo"}>
                <Link to={"/"} className={"logo logo-dark"}>
                  <span className={"logo-sm"}>
                    <img src={LogoSm} alt={"mint"} height={22} />
                  </span>
                  <span className={"logo-lg"}>
                    <img src={Logo} alt={"mint"} width={107} height={29} />
                  </span>
                </Link>
                <Link to={"/"} className={"logo logo-light"}>
                  <span className={"logo-sm"}>
                    <img src={LogoSm} alt={"mint"} height={22} />
                  </span>
                  <span className={"logo-lg"}>
                    <img src={Logo} alt={"mint"} width={107} height={29} />
                  </span>
                </Link>
              </div>
              <Button
                onClick={toggleMenu}
                type={"button"}
                className={
                  "btn btn-sm px-3 fs-16 header-item vertical-menu-btn topnav-hamburger"
                }
                color={"transparent"}
                id={"topnav-hamburger-icon"}
              >
                <span className={"hamburger-icon"}>
                  <span></span>
                  <span></span>
                  <span></span>
                </span>
              </Button>

              <SearchOptions />
            </div>
            <div className={"d-flex align-items-center"}>
              <Dropdown
                isOpen={isSearch}
                toggle={toggleSearchDropdown}
                className={"d-md-none topbar-head-dropdown header-item"}
              >
                <DropdownToggle
                  tag={"button"}
                  className={
                    "btn btn-icon btn-topbar btn-ghost-secondary rounded-circle"
                  }
                >
                  <span className={"ri-search-2-line fs-22"}></span>
                </DropdownToggle>
                <DropdownMenu
                  className={"dropdown-menu-lg dropdown-menu-end p-0"}
                >
                  <Form className={"p-3"}>
                    <div className={"form-group m-0"}>
                      <div className={"input-group"}>
                        <Input
                          type={"text"}
                          placeholder={"Поиск..."}
                          defaultValue={""}
                        />
                        <Button className={"btn btn-primary"} type={"submit"}>
                          <span className={"ri-search-2-line"}></span>
                        </Button>
                      </div>
                    </div>
                  </Form>
                </DropdownMenu>
              </Dropdown>

              <LanguageList name={language ? language.name : "ru"} />

              <CartList products={cart} />

              <FavoriteList
                isLoggedIn={auth.isLoggedIn && !!auth.user}
                favorites={favorites}
              />

              <CompareList products={compares} />

              <NotificationList />

              <ThemeToggle name={theme ? theme.name : "light"} />

              {auth.isLoggedIn && auth.user ? (
                <>
                  <UserMenu user={auth.user} />
                  {
                    <PrivateComponent>
                      <div
                        className={"ms-sm-3 header-item topbar-user"}
                        roles={[Roles.Admin, Roles.Seller]}
                      >
                        <Link
                          className={"btn bg-light fs-5 rounded btn-icon"}
                          to={"/admin/admin-dashboard"}
                          style={{ padding: "2rem 3rem" }}
                        >
                          <span
                            className={
                              "d-flex align-items-center user-name-text"
                            }
                          >
                            <i className={"ri-shield-user-line"}></i>
                            <span className={"text-start ms-xl-2"}>Админ</span>
                          </span>
                        </Link>
                      </div>
                    </PrivateComponent>
                  }
                </>
              ) : (
                <Auth />
              )}
            </div>
          </div>
        </div>
      </header>
    </React.Fragment>
  );
};

export default Header;
