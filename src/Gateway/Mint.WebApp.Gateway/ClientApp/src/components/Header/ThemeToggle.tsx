import React, { FC } from "react";
import { Button } from "reactstrap";
import { useDispatch } from "react-redux";
import { switchTheme } from "../../store/theme/theme";
import { ITheme } from "../../services/types/ICommon";

enum ThemeType {
  LIGHT_MODE = "light",
  DARK_MODE = "dark",
}

const ThemeToggle: FC<ITheme> = ({ name }) => {
  const dispatch = useDispatch();

  const mode =
    name === ThemeType["DARK_MODE"]
      ? ThemeType["LIGHT_MODE"]
      : ThemeType["DARK_MODE"];

  const onChangeThemeClick = () => {
    dispatch(switchTheme(mode));
  };

  return (
    <div className={"ms-1 header-item d-none d-sm-flex"}>
      <Button
        onClick={onChangeThemeClick}
        type={"button"}
        color={"transparent"}
        className={
          "btn btn-icon btn-topbar btn-ghost-secondary rounded-circle light-dark-mode"
        }
      >
        <i className={"ri-moon-line fs-22"}></i>
      </Button>
    </div>
  );
};

export default ThemeToggle;
