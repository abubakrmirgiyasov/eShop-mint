import React, { useEffect } from "react";
import { useSelector } from "react-redux";
import { Navigate } from "react-router-dom";

const AdminRoutes = ({ children }) => {
  const { Signin: user } = useSelector((user) => user);

  useEffect(() => {
    if (!user.isLoggedIn) {
      <Navigate to="/" />;
    }
  }, [user]);

  return <>{children}</>;
};

export default AdminRoutes;
