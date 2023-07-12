import React, { FC, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { IAuth } from "../../services/types/IAuth";
import { useSelector } from "react-redux";
import adaptiveMenu from "../../helpers/adaptiveMenu";
import {
  Dropdown,
  DropdownMenu,
  DropdownToggle,
  Form,
  Input,
  Button,
} from "reactstrap";
// media
import Logo from "../../assets/images/logos/logo-light.png";
import LogoSm from "../../assets/images/logos/Logo.png";
import {LanguageList} from "./LanguageList";

interface IHeader {
  headerClass: string;
  layout: string;
  onChangeLayoutMode: (value: string) => void;
}

const Header: FC<IHeader> = ({ headerClass, layout, onChangeLayoutMode }) => {
  const [value, setValue] = useState<string>("");
  const [isSearch, setIsSearch] = useState<boolean>(false);
  const [isLoginModalOpen, setIsLoginModalOpen] = useState<boolean>(false);

  const navigate = useNavigate();

  const { auth }: { auth: IAuth } = useSelector((state) => ({
    auth: state.Auth,
  }));

  const toggleMenu = () => {
    adaptiveMenu();
  };

  const handleSearch = (e) => {
    e.preventDefault();
    navigate("/search/query=" + value);
  };

  const onChangeData = (e: React.ChangeEvent<HTMLInputElement>) => {
    setValue(e.target.value);
  };

  // const onRemoveValue = () => {
  //   setValue("");
  // }

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
              <Form
                className={"app-search d-none d-md-block"}
                onSubmit={handleSearch}
              >
                <div className={"position-relative"}>
                  <Input
                    type={"text"}
                    placeholder={"Посик..."}
                    defaultValue={value}
                    onChange={onChangeData}
                    id={"searchId"}
                  />
                  <span className={"ri-search-2-line search-widget-icon"}></span>
                  <span
                    className={
                      `ri-close-circle-fill search-widget-icon search-widget-icon-close ${value ? "d-block" : "d-none"}`
                    }
                    id={"search-close-options"}
                    // onClick={onRemoveValue}
                  ></span>
                </div>
              </Form>
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
                  <i className={"bx bx-search fs-22"}></i>
                </DropdownToggle>
                <DropdownMenu
                  className={"dropdown-menu-lg dropdown-menu-end p-0"}
                >
                  <Form className={"p-3"}>
                    <div className={"form-group m-0"}>
                      <div className={"input-group"}>
                        <Input
                          type={"text"}
                          className={"form-control"}
                          placeholder={"Поиск..."}
                          defaultValue={""}
                        />
                        <Button className={"btn btn-primary"} type={"submit"}>
                          <i className={"mdi mdi-magnify"}></i>
                        </Button>
                      </div>
                    </div>
                  </Form>
                </DropdownMenu>
              </Dropdown>

              <LanguageList />

            </div>
          </div>
        </div>
      </header>
    </React.Fragment>
  );
};

export default Header;
