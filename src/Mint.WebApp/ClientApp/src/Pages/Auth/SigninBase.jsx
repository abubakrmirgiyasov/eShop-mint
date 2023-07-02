import React, { useEffect } from "react";
import Signin from "./Signin";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";

const SigninBase = () => {
  const navigate = useNavigate();

  const toggle = () => {
    navigate("/");
  };

  const { isLoggedIn } = useSelector((state) => ({
    isLoggedIn: state.Signin.isLoggedIn,
  }));

  useEffect(() => {
    if (isLoggedIn) navigate("/");
  }, [navigate, isLoggedIn]);

  return (
    <div className={"page-content"}>
      <Signin isOpen={true} toggle={toggle} />
    </div>
  );
};

export default SigninBase;
