import tjFlag from "../assets/images/flags/tj.svg";
import enFlag from "../assets/images/flags/us.svg";
import ruFlag from "../assets/images/flags/ru.svg";

interface IBadgeStyle {
  readonly value: string;
  readonly label: string;
  readonly color: string;
  readonly isFixed?: boolean;
  readonly isDisabled?: boolean;
}

const BadgeStyles: IBadgeStyle[] = [
  { value: "primary", label: "Primary", color: "#405189" },
  { value: "success", label: "Success", color: "#0ab39c" },
  { value: "info", label: "Info", color: "#299cdb" },
  { value: "warning", label: "Warning", color: "#f7b84b" },
  { value: "dark", label: "Dark", color: "#212529" },
  { value: "light", label: "Light", color: "#f3f6f9" },
  { value: "green", label: "Green", color: "#36B37E", isFixed: true },
  { value: "forest", label: "Forest", color: "#00875A", isFixed: true },
  { value: "slate", label: "Slate", color: "#253858", isFixed: true },
  { value: "silver", label: "Silver", color: "#666666", isFixed: true },
];

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

const Languages: ILanguageList = {
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

interface IIco {
  value: string;
  label: string;
  svg: string;
}

const Icons: IIco[] = [
  { value: "ri-table-line", label: "ri-table-line", svg: "ri-table-line" },
  {
    value: "ri-arrow-down-s-fill",
    label: "ri-arrow-down-s-fill",
    svg: "ri-arrow-down-s-fill",
  },
];

export {
  Languages,
  Countries,
  ICountry,
  BadgeStyles,
  IBadgeStyle,
  Icons,
  IIco,
};
