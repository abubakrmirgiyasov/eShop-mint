import { BASE_URL, REFRESHTOKEN, SIGNIN, SIGNOUT } from "../constants/Urls";

const getAccessToken = () => {
  const user = JSON.parse(localStorage.getItem("auth_user"));
  return user && user.accessToken ? `Bearer ${user.accessToken}` : "";
};

const signinHelper = async (values) => {
  const response = await fetch(BASE_URL + SIGNIN, {
    method: "POST",
    body: JSON.stringify(values),
    headers: {
      "Content-Type": "application/json",
    },
  });

  response.json().then((data) => {
    if (data.accessToken) {
      localStorage.setItem("auth_user", JSON.stringify(data));
    }
    return data;
  });
};

const signoutHelper = () => {
  fetch(BASE_URL + SIGNOUT, {
    method: "POST",
    headers: {
      Authorization: getAccessToken(),
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ token: null }),
  })
    .then(() => localStorage.removeItem("auth_user"))
    .catch((error) => console.log(error));
};

const refreshTokenHelper = () => {
  console.log("refresh");
  const response = fetch(BASE_URL + REFRESHTOKEN, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
  });

  response.json().then((data) => {
    if (data.accessToken) {
      localStorage.setItem("auth_user", JSON.stringify(data));
    }
    return data;
  });
};

export default {
  signinHelper,
  signoutHelper,
  getAccessToken,
  refreshTokenHelper,
};
