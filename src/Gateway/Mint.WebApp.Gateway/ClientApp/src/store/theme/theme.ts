import { SET_LAYOUT, SET_THEME } from "./actionType";

function changeHTMLAttribute(attribute: string, value: string) {
  if (document.documentElement) {
    document.documentElement.setAttribute(attribute, value);
  }
  return true;
}

export const switchTheme = (value: string) => (dispatch) => {
  changeHTMLAttribute("data-layout-mode", value);
  const theme = JSON.stringify({ name: value });
  localStorage.setItem("theme", theme);

  dispatch({
    type: SET_THEME,
    payload: value,
  });
};

export const switchLayout = (value: string) => (dispatch) => {
  changeHTMLAttribute("data-layout", value);

  dispatch({
    type: SET_LAYOUT,
    payload: value,
  });
};
