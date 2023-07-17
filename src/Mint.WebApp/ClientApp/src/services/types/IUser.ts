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
  dateBirth?: string;
  isEmailConfirmed: boolean;
  isPhoneConfirmed: boolean;
  isSeller: boolean;
  roles: IRole[];
}

interface IRole {
  value: string;
  label: string;
}

export { IUser, IRole };
