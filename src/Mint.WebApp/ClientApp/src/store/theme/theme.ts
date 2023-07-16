import { SET_THEME } from "./actionType";

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
