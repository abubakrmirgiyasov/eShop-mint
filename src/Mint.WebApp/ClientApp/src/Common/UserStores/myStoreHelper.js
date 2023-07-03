import React from "react";
import { fetchWrapper } from "../../helpers/fetchWrapper";

const myStoreHelper = () => {
  const user = JSON.parse(localStorage.getItem("auth_user"));

  if (user) {
    return fetchWrapper
      .get("api/store/getmystore/" + user.id)
      .then((response) => {
        console.log(response);
        localStorage.setItem("my_store", JSON.stringify(response));
        return response;
      })
      .catch((error) => {
        return error;
      });
  } else {
    return fetchWrapper
      .get("")
      .then((response) => response)
      .catch((error) => error);
  }
};

export default { myStoreHelper };
