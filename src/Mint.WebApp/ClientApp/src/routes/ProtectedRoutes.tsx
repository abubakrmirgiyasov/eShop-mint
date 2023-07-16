import { FC, ReactNode, useEffect } from "react";
import { useDispatch } from "react-redux";
import { useProfile } from "../hooks/useProfile";
import { signOut } from "../store/authentication/authentication";
import { useNavigate } from "react-router-dom";

interface IPublicRoute {
  children: ReactNode;
}

interface IPrivateRoute {
  children: ReactNode;
}

const PublicRoutesLayout: FC<IPublicRoute> = ({ children }) => {
  return <>{children}</>;
};

const PrivateRoutesLayout: FC<IPrivateRoute> = ({ children }) => {
  const { user, isLoading, token } = useProfile();

  const dispatch = useDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    if (!user && !token && isLoading) dispatch(signOut());
  }, [token, user, isLoading, token, dispatch]);

  if (!user && !token && isLoading) {
    navigate("/signin");
  }

  return <>{children}</>;
};

export { PublicRoutesLayout, PrivateRoutesLayout };
