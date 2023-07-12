import {SET_THEME} from "./actionType";

export const switchTheme = (value: string) => (dispatch) => {
    const theme: string = JSON.stringify({ name: value });
    localStorage.setItem("theme", theme);

    dispatch({
        type: SET_THEME,
        payload: value,
    });
}