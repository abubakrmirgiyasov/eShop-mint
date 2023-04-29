import { fetchWrapper } from "../../helpers/fetchWrapper";
import { useState } from "react";

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

// const manufacturesHelper = () => {
//   return fetchWrapper
//     .get("api/manufacture/getmanufactures")
//     .then((response) => {
//       return response;
//     })
//     .catch((error) => {
//       return error;
//     });
// };
//
// const subCategoriesHelper = () => {
//   return fetchWrapper
//     .get("api/subcategory/getsubcategories")
//     .then((response) => {
//       return response;
//     })
//     .catch((error) => {
//       return error;
//     });
// };

// const menuHelper = () => {
//   return fetchWrapper
//     .get("api/menu")
//     .then((response) => {
//       return response;
//     })
//     .catch((error) => {
//       return error;
//     });
// };

export default {
  menuHelper,
};
