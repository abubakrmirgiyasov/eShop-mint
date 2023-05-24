import { CHANGE_LAYOUT_MODE, CHANGE_LAYOUT_TYPE, CHANGE_LAYOUT_TYPE_MODE, CHANGE_LAYOUT_TYPE_SIZE } from './actionType';

const layout = localStorage.getItem("theme_mode");

const initState = layout ? { layout } : {};

function changeHTMLAttribute(attribute, value) {
    if (document.documentElement) {
        document.documentElement.setAttribute(attribute, value);
    }
    return true;
}

export const changeLayoutMode = (mode) => (dispatch) => {
    changeHTMLAttribute("data-layout-mode", mode);
    localStorage.setItem("theme_mode", mode);

    dispatch({
        type: CHANGE_LAYOUT_MODE,
        payload: mode,
    });
}

export const changeLayoutType = (layout) => (dispatch) => {
    changeHTMLAttribute("data-layout", layout);

    dispatch({
        type: CHANGE_LAYOUT_TYPE,
        payload: layout,
    });
}

export const changeLayoutTypeSize = (size) => (dispatch) => {
    changeHTMLAttribute("data-sidebar-size", size);

    dispatch({
        type: CHANGE_LAYOUT_TYPE_SIZE,
        payload: size,
    });
}

export const changeLayoutBackground = (mode) => (dispatch) => {
    changeHTMLAttribute("data-sidebar", mode);

    dispatch({
        type: CHANGE_LAYOUT_TYPE_MODE,
        payload: mode,
    });
}

export default function(state = initState, action) {
    const { type, payload } = action;
    
    switch (type) {
        case CHANGE_LAYOUT_MODE:
            return {
                ...state,
                layout: payload,
            };
        case CHANGE_LAYOUT_TYPE:
            return {
                ...state,
                layoutModeType: payload,
            };
        case CHANGE_LAYOUT_TYPE_SIZE:
            return {
                ...state,
                layoutTypeSize: payload,
            };
        case CHANGE_LAYOUT_TYPE_MODE:
            return {
                ...state,
                layoutModeTypeBack: payload,
            };
        default:
            return state;
    }
}