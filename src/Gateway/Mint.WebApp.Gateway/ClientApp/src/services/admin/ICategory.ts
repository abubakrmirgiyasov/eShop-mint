import { IManufacture } from "./IManufacture";

export interface ICategory {
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

export interface ICategoryTag {
  value?: string;
  label?: string;
}
