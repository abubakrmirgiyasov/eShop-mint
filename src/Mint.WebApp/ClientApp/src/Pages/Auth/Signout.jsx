import React from "react";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Navigate } from "react-router-dom";
import { signout } from "../../helpers/authentication";

const Signout = () => {
  const dispatch = useDispatch();
  const { Signin: user } = useSelector((user) => user);

  useEffect(() => {
    dispatch(signout());
  }, []);

  if (user) return <Navigate to="/" />;

  document.title = "Выход - Mint";
  return <></>;
};

export default Signout;
