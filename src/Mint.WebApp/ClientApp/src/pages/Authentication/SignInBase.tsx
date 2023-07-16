import React, { FC, ReactNode, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import SignInModal from "./SignInModal";

const SignInBase: FC<ReactNode> = () => {
  const navigate = useNavigate();

  const toggle = () => {
    navigate("/");
  };

  const { isLoggedIn }: { isLoggedIn: boolean } = useSelector((state) => ({
    isLoggedIn: state.Auth.isLoggedIn,
  }));

  useEffect(() => {
    if (isLoggedIn) toggle();
  }, [navigate, isLoggedIn]);

  return (
    <div className={"page-content"}>
      <SignInModal isOpen={true} error={""} toggle={toggle} />
    </div>
  );
};

export default SignInBase;
