import { IManufacture } from "./IManufacture";

export interface ICategoryFull {
  id: string;
  name: string;
  defaultLink: string;
  ico: string;
  badgeStyle?: string;
  badgeText?: string;
  displayOrder: number;
  folder?: string;
  photo?: File[];
  childs?: string[];
  categoryTags: ICategoryTag[];
  manufactureCategories: IManufacture[];
}

export interface ICategory {
  value?: string;
  label?: string;
}

export interface ICategoryTag {
  value?: string;
  label?: string;
}
