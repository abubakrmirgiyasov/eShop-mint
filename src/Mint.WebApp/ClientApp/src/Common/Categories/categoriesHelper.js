import { fetchWrapper } from "../../helpers/fetchWrapper";

const menuHelper = () => {
  return fetchWrapper
    .get("api/common/menu")
    .then((response) => {
      return response;
    })
    .catch((error) => {
      return error;
    });
};

export default {
  menuHelper,
};
