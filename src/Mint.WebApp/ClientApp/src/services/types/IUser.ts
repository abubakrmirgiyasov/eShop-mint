interface IUser {
  id: string;
  firstName: string;
  secondName: string;
  email: string;
  accessToken: string;
  image: string;
  refreshToken: string;
  roles: IRole[];
}

interface IRole {
  value: string;
  label: string;
}

export { IUser, IRole };
