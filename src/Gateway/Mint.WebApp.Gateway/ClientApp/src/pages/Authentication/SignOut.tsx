import React, { useEffect } from "react";
import { Spinner } from "reactstrap";
import { useDispatch } from "react-redux";
import { signOut } from "../../store/authentication/authentication";
import { fetch } from "../../helpers/fetch";
import { useNavigate } from "react-router-dom";

const SignOut = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    dispatch(signOut(fetch())).then(() => navigate("/"));
  }, [dispatch, navigate]);

  return (
    <div className={"d-flex justify-content-center align-items-center"}>
      <Spinner size={"sm"}>Loading...</Spinner>
    </div>
  );
};

export default SignOut;
