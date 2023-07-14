import React, { FC, ReactNode, useEffect, useState } from "react";
import {
  Dropdown,
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
} from "reactstrap";
import { useDispatch, useSelector } from "react-redux";
// import i18n from "../../services/i18n/i18n";
import { switchLanguage } from "../../store/language/language";
import { get } from "lodash";
import { languages } from "../../constants/commonList";

type Languages = {
  name: string;
};

const LanguageList: FC<ReactNode> = () => {
  const [isLanguageDropDown, setIsLanguageDropDown] = useState<boolean>(false);
  const [selectedLanguage, setSelectedLanguage] = useState<string>("");

  const dispatch = useDispatch();

  const { language }: { language: Languages } = useSelector((state) => ({
    language: state.Language,
  }));

  useEffect(() => {
    setSelectedLanguage(language.name);
  }, []);

  const onChangeLanguage = (value: string) => {
    // i18n.changeLanguage(value).then(r => console.log(r)).catch((e) => console.log(e));
    dispatch(switchLanguage(value));
    setSelectedLanguage(value);
  };

  const toggleLanguageDropDown = () => {
    setIsLanguageDropDown(!isLanguageDropDown);
  };

  return (
    <React.Fragment>
      <Dropdown
        isOpen={isLanguageDropDown}
        toggle={toggleLanguageDropDown}
        className={"ms-1 topbar-head-dropdown header-item"}
      >
        <DropdownToggle
          tag={"button"}
          className={
            "btn btn-icon btn-topbar btn-ghost-secondary rounded-circle"
          }
        >
          <img
            src={get(languages, `${selectedLanguage}.flag`)}
            alt={"language"}
            height={20}
            className={"rounded"}
          />
        </DropdownToggle>
        <DropdownMenu className={"notify-item language py-2"}>
          {Object.keys(languages).map((key) => (
            <DropdownItem
              key={key}
              className={`notify-item ${
                selectedLanguage === key ? "active" : "none"
              }`}
              onClick={() => onChangeLanguage(key)}
            >
              <img
                src={get(languages, `${key}.flag`)}
                alt={key}
                className={"me-2 rounded"}
                height={18}
              />
              <span className={"align-middle"}>
                {get(languages, `${key}.label`)}
              </span>
            </DropdownItem>
          ))}
        </DropdownMenu>
      </Dropdown>
    </React.Fragment>
  );
};

export { LanguageList };
