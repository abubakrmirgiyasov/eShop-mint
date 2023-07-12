import {ITheme} from "../../services/types/ICommon";
import {SET_THEME} from "./actionType";

const initState: ITheme = JSON.parse(localStorage.getItem("theme"));

export default function (state = initState, action) {
    const { type, payload } = action;

    switch (type) {
        case SET_THEME:
            return { theme: payload };
        default:
            return state;
    }
}