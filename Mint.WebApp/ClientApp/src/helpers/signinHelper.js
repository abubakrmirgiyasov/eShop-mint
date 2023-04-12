import { BASE_URL, SIGNIN, SIGNOUT } from "../constants/Urls";

const getAccessToken = () => {
  const user = JSON.parse(localStorage.getItem("auth_user"));
  return user && user.accessToken ? `Bearer ${user.accessToken}` : "";
}

const signinHelper = async (values) => {
  const response = await fetch(BASE_URL + SIGNIN, {
    method: "POST",
    body: JSON.stringify(values),
    headers: {
      "content-type": "application/json",
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
      "Authorization": getAccessToken(),
      "Content-Type": "application/json",
    },
    body: { 
      token: null 
    },
  }).then(() => localStorage.removeItem("auth_user"));
};

export default { signinHelper, signoutHelper, getAccessToken };