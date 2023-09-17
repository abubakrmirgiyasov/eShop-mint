import { FC, ReactNode, useEffect } from "react";
import { useDispatch } from "react-redux";
import { useProfile } from "../hooks/useProfile";
import { signOut } from "../store/authentication/authentication";
import { useNavigate } from "react-router-dom";
import { fetch } from "../helpers/fetch";

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
    if (!user && !token && isLoading) dispatch(signOut(fetch()));
  }, [token, user, isLoading, dispatch]);

  if (!user && !token && isLoading) {
    navigate("/signin");
  }

  return <>{children}</>;
};

const AdminRoutesLayout: FC<ReactNode> = ({ children }) => {
  const { user, isLoading, token } = useProfile();

  const dispatch = useDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    if (!user && !token && isLoading) dispatch(signOut(fetch()));

    console.log(user);

    if (!user && !token && isLoading) {
      navigate("/admin/signin");
    } else if (!user?.isSeller) {
      navigate("/admin/signin");
    }
  }, []);

  return <>{children}</>;
};

export { PublicRoutesLayout, PrivateRoutesLayout, AdminRoutesLayout };
