import React, { FC, useState } from "react";
import adaptiveMenu from "../../helpers/adaptiveMenu";
import { Button } from "reactstrap";
import {ILocalUser} from "../../types/Authentication/ILocalUser";

interface IHeader {
  headerClass: string;
  auth?: ILocalUser | null;
}

const AdminHeader: FC<IHeader> = ({ headerClass, auth }) => {
  const [isSearch, setIsSearch] = useState<boolean>(false);

  const toggleMenu = () => {
    adaptiveMenu();
  };

  return (
    <React.Fragment>
      <header id={"page-topbar"} className={headerClass}>
        <div className={"layout-width"}>
          <div className={"navbar-header"}>
            <div className={"d-flex"}>
              <Button
                onClick={toggleMenu}
                type={"button"}
                className={
                  "btn btn-sm-px-3 fs-16 header-item vertical-menu-btn topnav-hamburger"
                }
                color={"light"}
                id={"topnav-hamburger-icon"}
              >
                <span className={"hamburger-icon"}>
                  <span></span>
                  <span></span>
                  <span></span>
                </span>
              </Button>
            </div>
            <div className={"d-flex align-items-center"}>
              menu settings theme
            </div>
          </div>
        </div>
      </header>
    </React.Fragment>
  );
};

export default AdminHeader;
