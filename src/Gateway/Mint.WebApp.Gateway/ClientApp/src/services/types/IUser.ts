import { ICountry } from "../../constants/commonList";

interface IUser {
  id: string;
  firstName: string;
  secondName: string;
  lastName?: string;
  email: string;
  phone: string;
  accessToken: string;
  image: string;
  refreshToken: string;
  gender: string;
  dateBirth: string;
  isConfirmedEmail: boolean;
  isConfirmedPhone: boolean;
  isSeller: boolean;
  description?: string;
  roles: IRole[];
}

interface IRole {
  value: string;
  label: string;
}

interface IUserAddress {
  id: string;
  fullName: string;
  email: string;
  phone: number;
  createdDate: string;
  fullAddress: string;
  country: ICountry;
  city: string;
  street: string;
  zipCode: number;
  description: number;
}

interface IUserOrder {
  id: string;
  orderNumber: string;
}

interface IUserStore {}

export { IUser, IRole, IUserAddress, IUserOrder, IUserStore };