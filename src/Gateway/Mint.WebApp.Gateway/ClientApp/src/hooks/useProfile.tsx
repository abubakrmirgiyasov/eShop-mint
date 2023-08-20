import { IUser } from "../services/types/IUser";
import { useEffect, useState } from "react";

const isLoggedInUser: () => IUser | null = () => {
  const json = localStorage.getItem("auth_user");
  if (json) {
    const user: IUser = JSON.parse(json);
    return user;
  }
  return null;
};

const useProfile = () => {
  const userProfileSession = isLoggedInUser();
  const token = userProfileSession && userProfileSession["accessToken"];

  const [isLoading, setIsLoading] = useState<boolean>(!!userProfileSession);
  const [user, setUser] = useState<IUser>(
    userProfileSession ? userProfileSession : null
  );

  useEffect(() => {
    const userProfileSession = isLoggedInUser();
    const token = userProfileSession && userProfileSession["accessToken"];

    setUser(userProfileSession ? userProfileSession : null);
    setIsLoading(!!token);
  }, []);

  return { user, isLoading, token };
};

export { useProfile };
