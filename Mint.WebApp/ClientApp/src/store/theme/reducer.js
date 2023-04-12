import { CHANGE_LAYOUT_MODE, CHANGE_LAYOUT_TYPE, CHANGE_LAYOUT_TYPE_SIZE } from './actionType';

const initState = {};

function changeHTMLAttribute(attribute, value) {
    if (document.documentElement) {
        document.documentElement.setAttribute(attribute, value);
    }
    return true;
}

export const changeLayoutMode = (mode) => (dispatch) => {
    changeHTMLAttribute("data-layout-mode", mode);

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

export default function(state = initState, action) {
    switch (action.type) {
        case CHANGE_LAYOUT_MODE:
            return {
                ...state,
                layout: action.payload,
            };
        case CHANGE_LAYOUT_TYPE:
            return {
                ...state,
                layoutModeType: action.payload,
            };
        case CHANGE_LAYOUT_TYPE_SIZE:
            return {
                ...state,
                layoutTypeSize: action.payload,
            }
        default:
            return state;
    }
}