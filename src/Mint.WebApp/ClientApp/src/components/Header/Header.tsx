import React, { FC, useState } from "react";
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
import CartList from "./CartList";
import FavoriteList from "./FavoriteList";
import Request from "../../helpers/requestWrapper/request";
import { IProduct } from "../../services/types/IProduct";
import CompareList from "./CompareList";

// media
import Logo from "../../assets/images/logos/logo-light.png";
import LogoSm from "../../assets/images/logos/Logo.png";
import SearchOptions from "./SearchOptions";

interface IHeader {
  request: Request;
  headerClass: string;
  layout: string;
  onChangeLayoutMode: (value: string) => void;
}

const Header: FC<IHeader> = ({
  request,
  headerClass,
  layout,
  onChangeLayoutMode,
}) => {
  const [value, setValue] = useState<string>("");
  const [isSearch, setIsSearch] = useState<boolean>(false);
  const [isLoginModalOpen, setIsLoginModalOpen] = useState<boolean>(false);

  const navigate = useNavigate();

  const {
    auth,
    favorites,
    message,
  }: { auth: IAuth; favorites: IProduct[]; message: string } = useSelector(
    (state) => ({
      auth: state.Auth,
      favorites: state.Favorites.likes,
      message: state.Message,
    })
  );

  const toggleMenu = () => {
    adaptiveMenu();
  };

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
                toggle={() => setIsSearch(!isSearch)}
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

              <LanguageList />

              <CartList />

              <FavoriteList
                isLoggedIn={auth.isLoggedIn && !!auth.user}
                favorites={favorites}
                request={request}
              />

              <CompareList />
            </div>
          </div>
        </div>
      </header>
    </React.Fragment>
  );
};

export default Header;
