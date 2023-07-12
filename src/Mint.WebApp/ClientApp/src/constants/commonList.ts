import tjFlag from "../assets/images/flags/tj.svg";
import enFlag from "../assets/images/flags/us.svg";
import ruFlag from "../assets/images/flags/ru.svg";

interface ILanguageList {
    [key: string]: {
        label: string;
        flag: string;
    }
}

const languages: ILanguageList = {
    tj: {
        label: "Тоҷикӣ",
        flag: tjFlag,
    },
    en: {
        label: "English",
        flag: enFlag,
    },
    ru: {
        label: "Русский",
        flag: ruFlag,
    }
}

export { languages };