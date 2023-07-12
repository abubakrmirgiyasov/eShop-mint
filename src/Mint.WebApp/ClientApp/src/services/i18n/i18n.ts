import i18n from "i18next";
import detector from "i18next-browser-languagedetector";
import { initReactI18next } from "react-i18next";
import { ILanguage } from "../types/ICommon";

// json files
import tj from "./tj.json";
import ru from "./ru.json";
import en from "./en.json";

// interface IOptions {
//     resources: IResources;
//     lng: string;
//     fallbackLng: string;
//     keySeparator: boolean;
//     interpolation: {
//         escapeValue: boolean;
//     }
// }

interface IResources {
    [key: string]: {
      translation: [key: string],
    };
}

const resources: IResources = {
    tj: {
        translation: tj
    },
    en: {
        translation: en,
    },
    ru: {
        translation: ru,
    }
};

const language: ILanguage = JSON.parse(localStorage.getItem("lang"));

if (!language)
    localStorage.setItem("lang", JSON.stringify({ name: "ru" }));

i18n
    .use(detector)
    .use(initReactI18next) // passes i18n down to react-i18next
    .init({
        resources: resources,
        lng: language || "ru",
        fallbackLng: "ru",  // use ru if detected lng is not available
        keySeparator: false, // we do not use keys in form messages.welcome
        interpolation: {
            escapeValue: false, // react already safes from xss
        }
    });

export default i18n;