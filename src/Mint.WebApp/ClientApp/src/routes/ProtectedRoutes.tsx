import { FC, ReactNode, useEffect } from "react";
import { useDispatch } from "react-redux";
import { useProfile } from "../hooks/useProfile";
import { signOut } from "../store/authentication/authentication";
import { Navigate } from "react-router-dom";

interface IPublicRoute {
  children: ReactNode;
}

interface IPrivateRoute {
  children: ReactNode;
  locations?: string;
}

const PublicRoutesLayout: FC<IPublicRoute> = ({ children }) => {
  return <>{children}</>;
};

const PrivateRoutesLayout: FC<IPrivateRoute> = ({ children, locations }) => {
  const { user, isLoading, token } = useProfile();

  const dispatch = useDispatch();

  useEffect(() => {
    if (!user && !token && isLoading) dispatch(signOut());
  }, [token, user, isLoading, token, dispatch]);

  // if (!user && !token && isLoading) {
  //   return (
  //       <Navigate
  //         to{{
  //           pathname: "/",
  //           state: {from: locations}
  //         }}
  //       />
  //   );
  // }

  return <>{children}</>;
};

export { PublicRoutesLayout, PrivateRoutesLayout };
