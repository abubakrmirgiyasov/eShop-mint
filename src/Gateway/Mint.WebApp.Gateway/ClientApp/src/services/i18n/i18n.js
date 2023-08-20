// import i18n from "i18next";
// import detector from "i18next-browser-languagedetector";
// import { initReactI18next } from "react-i18next";
//
// // json files
// import tj from "./tj.json";
// import ru from "./ru.json";
// import en from "./en.json";
//
// interface IResources {
//     [key: string]: {
//       translation: [key: string],
//     };
// }
//
// const resources: IResources = {
//     tj: {
//         translation: tj
//     },
//     en: {
//         translation: en,
//     },
//     ru: {
//         translation: ru,
//     }
// } as const;
//
// const language = JSON.parse(localStorage.getItem("lang"));
//
// if (!language)
//     localStorage.setItem("lang", JSON.stringify({ name: "ru" }));
//
// i18n
//     .use(detector)
//     .use(initReactI18next) // passes i18n down to react-i18next
//     .init({
//        resources: resources,
//         lng: language || "ru",
//         fallbackLng: "ru",
//         keySeparator: false,
//         interpolation: {
//            escapeValue: false, // react already safes from xss
//         }
//     }, null).then(r => console.log(r)).catch((e) => console.log(e));
//
// export default i18n;
