import { fetchWrapper } from "../../helpers/fetchWrapper";

const productHelper = () => {
  console.log("asdasd");
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
