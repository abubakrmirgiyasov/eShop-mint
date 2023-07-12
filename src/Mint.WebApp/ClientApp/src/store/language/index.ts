import {ILanguage} from "../../services/types/ICommon";
import {SET_LANGUAGE} from "./actionType";

const initState : ILanguage = JSON.parse(localStorage.getItem("lang"));

export default function (state = initState, action) {
    const { type, payload } = action;

    switch (type) {
        case SET_LANGUAGE:
            return {
                language: payload
            };
        default:
            return state;
    }
}
