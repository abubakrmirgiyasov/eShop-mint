import { fetchWrapper } from "../../helpers/fetchWrapper";

const productHelper = () => {
  return fetchWrapper
    .get("api/product/getproducts")
    .then((response) => {
      return response;
    })
    .catch((error) => {
      return error;
    });
};

export default {
  productHelper,
};
