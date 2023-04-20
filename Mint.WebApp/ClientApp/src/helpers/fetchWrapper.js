import { refreshToken } from "./authentication";

export const fetchWrapper = {
  get: request("GET"),
  post: request("POST"),
  put: request("PUT"),
  delete: request("DELETE"),
  getFileShow: requestFileShow(),
};

function authToken() {
  if (localStorage.getItem("auth_user")) {
    return JSON.parse(localStorage.getItem("auth_user")).accessToken;
  } else {
    return null;
  }
}

function handleResponseFileShow(response) {
  return response.text();
}

function handleResponseFile(fileName, response) {
  return response.blob().then((blob) => {
    var url = window.URL.createObjectURL(blob);
    var link = document.createElement("a");
    link.href = url;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    link.remove();
  });
}

function handleResponse(response) {
  return response.text().then((text) => {
    const data = text && JSON.parse(text);
    if (!response.ok) {
      const error = (data && data.message) || response.statusText;
      return Promise.reject(error);
    }
    return data;
  });
}

function authHeader(url) {
  const token = authToken();
  const isLoggedIn = !!token;
  const isApiUrl = url;

  return isLoggedIn && isApiUrl ? `Bearer ${token}` : {};
}

function requestFileShow() {
  return (url) => {
    const requestOptions = {
      method: "GET",
      headers: {},
    };

    requestOptions.headers["Authorization"] = authHeader(url);

    return fetch(url, requestOptions)
      .then((response) => handleResponseFileShow(response))
      .catch((error) => {
        if (error === "Unauthorized") {
          // return dispatch(refreshToken())
          //   .unwrap()
          //   .then(() => {
          //     requestOptions.headers["Authorization"] = authHeader(url);
          //     return fetch(url, requestOptions).then(handleResponse);
          //   });
        } else {
          return Promise.reject(error);
        }
      });
  };
}

function request(method) {
  return (url, body, jsonBody = true, fileResponse, fileName) => {
    const requestOptions = {
      method,
      headers: {},
    };

    requestOptions.headers["Authorization"] = authHeader(url);

    if (body) {
      if (jsonBody) {
        requestOptions.headers["Content-Type"] = "application/json";
        requestOptions.body = JSON.stringify(body);
      } else {
        requestOptions.body = body;
      }
    }
    if (fileResponse) {
      return fetch(url, requestOptions)
        .then((response) => handleResponseFile(fileName, response))
        .catch((error) => {
          if (error === "Unauthorized") {
            // return dispatch(refreshToken())
            //   .unwrap()
            //   .then(() => {
            //     requestOptions.headers["Authorization"] = authHeader(url);
            //     return fetch(url, requestOptions).then(handleResponse);
            //   });
          } else {
            return Promise.reject(error);
          }
        });
    } else {
      return fetch(url, requestOptions)
        .then(handleResponse)
        .catch((error) => {
          if (error === "Unauthorized") {
            return fetch("api/authentication/refreshtoken", {
              method: "POST"
            })
              .unwrap()
              .then((response) => {
                console.log(response);
                requestOptions.headers["Authorization"] = authHeader(url);
                return fetch(url, requestOptions).then(handleResponse);
              });
          } else {
            return Promise.reject(error);
          }
        });
    }
  };
}
