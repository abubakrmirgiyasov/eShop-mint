import {SET_LANGUAGE} from "./actionType";

export const switchLanguage = (value: string)  => (dispatch)=> {
    console.log(value)
    const lang = JSON.stringify({ name: value });


    localStorage.setItem("lang", lang);

    dispatch({
        type: SET_LANGUAGE,
        payload: value,
    });
}