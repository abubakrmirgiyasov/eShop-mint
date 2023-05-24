import React, { useState } from "react";
import {
  Dropdown,
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
} from "reactstrap";
import Russia from "../../assets/images/flags/russia.svg";

const LanguageList = () => {
  const [isLanguageDropdown, setIsLanguageDropdown] = useState(false);
  // const [selectedLanguage, setSelectedLanguage] = useState("");

  // useEffect(() => {
  //     const currentLanguage = localStorage.getItem("");
  //     setSelectedLanguage(currentLanguage);
  // }, []);

  // const changeLanguageAction = (language) => {

  // };

  return (
    <React.Fragment>
      <Dropdown
        isOpen={isLanguageDropdown}
        toggle={() => setIsLanguageDropdown(!isLanguageDropdown)}
        className="ms-1 topbar-head-dropdown header-item"
      >
        <DropdownToggle 
            className="btn btn-icon btn-topbar btn-ghost-secondary rounded-circle"
            tag={"button"}
        >
          <img
            src={Russia}
            alt="Header Language"
            height={20}
            className="rounded"
          />
        </DropdownToggle>
        <DropdownMenu className="notify-item language py-2">
          <DropdownItem
            // key={""}
            // onClick={() => changeL}
            className={`notify-item none`} // if active show selected lang else none
          >
            <img
              src={Russia}
              alt={"Русский"}
              className="me-2 rounded"
              height={18}
            />
            <span className="align-middle">Русский</span>
          </DropdownItem>
        </DropdownMenu>
      </Dropdown>
    </React.Fragment>
  );
};

export default LanguageList;
