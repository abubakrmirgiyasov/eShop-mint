import tjFlag from "../assets/images/flags/tj.svg";
import enFlag from "../assets/images/flags/us.svg";
import ruFlag from "../assets/images/flags/ru.svg";

interface ICountry {
  value: number;
  label: string;
}

const Countries: ICountry[] = [
  { value: 1, label: "Россия" },
  { value: 2, label: "Казахстан" },
  { value: 3, label: "Таджикистан" },
  { value: 4, label: "Узбекистан" },
];

interface ILanguageList {
  [key: string]: {
    label: string;
    flag: string;
  };
}

const languages: ILanguageList = {
  tj: {
    label: "Тоҷикӣ",
    flag: tjFlag,
  },
  us: {
    label: "English",
    flag: enFlag,
  },
  ru: {
    label: "Русский",
    flag: ruFlag,
  },
};

export { languages, Countries, ICountry };
