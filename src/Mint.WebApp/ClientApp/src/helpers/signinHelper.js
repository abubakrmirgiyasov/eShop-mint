import { BASE_URL, REFRESHTOKEN, SIGNIN, SIGNOUT } from "../constants/Urls";

const getAccessToken = () => {
  const user = JSON.parse(localStorage.getItem("auth_user"));
  return user && user.accessToken ? `Bearer ${user.accessToken}` : "";
};

const signinHelper = async (values) => {
  await fetch(BASE_URL + SIGNIN, {
    method: "POST",
    body: JSON.stringify(values),
    headers: {
      "Content-Type": "application/json",
    },
  })
    .then((response) => {
      return response.ok
        ? response.json()
        : response.json().then((error) => {
            throw new Error(error.message);
          });
    })
    .then((data) => {
      if (data.accessToken) {
        localStorage.setItem("auth_user", JSON.stringify(data));
      }
      return data;
    })
    .catch((error) => {
      throw new Error(error);
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
    .then(() => {
      localStorage.removeItem("auth_user");
      localStorage.removeItem("my_store");
    })
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
