import React from "react";
import { fetchWrapper } from "../../helpers/fetchWrapper";

const myStoreHelper = () => {
  const user = JSON.parse(localStorage.getItem("auth_user"));

  return fetchWrapper
    .get("api/store/getmystore/" + user?.id)
    .then((response) => {
      localStorage.setItem("my_store", JSON.stringify(response));
    })
    .catch((error) => {
      return error;
    });
};

export default { myStoreHelper };
