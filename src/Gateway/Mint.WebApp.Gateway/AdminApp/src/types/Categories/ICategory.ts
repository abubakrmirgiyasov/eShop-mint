import { IManufacture } from "../Manufactures/IManufacture";

export interface ICategoryFull {
  id: string;
  name: string;
  defaultLink: string;
  ico: string;
  badgeStyle?: string | null;
  badgeText?: string | null;
  displayOrder: number;
  folder?: string | null;
  photo?: File[] | [];
  childs?: string[] | [];
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
