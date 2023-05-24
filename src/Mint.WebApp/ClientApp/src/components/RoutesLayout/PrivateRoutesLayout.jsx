import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import { useProfile } from "../../hooks/userHooks";
import { Navigate, Route } from "react-router-dom";
import { signout } from "../../helpers/authentication";

const PrivateRoutesLayout = (props) => {
  const dispatch = useDispatch();
  const { userProfile, isLoading, token } = useProfile();

  useEffect(() => {
    if (!userProfile && isLoading && !token) dispatch(signout());
  }, [token, userProfile, isLoading, dispatch]);

  if (!userProfile && isLoading && !token) {
    return (
      <Navigate
        to={{
          pathname: "/",
          state: { from: props.locations },
        }}
      />
    );
  }

  return <>{props.children}</>;
};

const AccessRoute = ({ component: Component, ...rest}) => {
  return (
    <Route 
      {...rest}
      render={props => {
        return (<><Component {...props} /></>)
      }}
    />
  );
};

export { AccessRoute, PrivateRoutesLayout };
