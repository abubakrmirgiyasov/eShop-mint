import { ICategory } from "./ICategory";

export interface IManufacture {
  value?: string;
  label?: string;
}

export interface IManufactureTag {
  value?: string;
  label?: string;
}

export interface IManufactureFull {
  id: string;
  name: string;
  country: string;
  email: string;
  phone: number;
  fullAddress?: string;
  description?: string;
  website?: string;
  displayOrder: number;
  photo?: File[];
  folder?: string;
  manufactureCategories?: ICategory[];
  manufactureTags?: IManufactureTag[];
}
