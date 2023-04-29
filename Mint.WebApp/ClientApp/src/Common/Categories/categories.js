import Helper from "./categoriesHelper";
import { MENU } from "../../store/categories/actionType";
import { SET_MESSAGE } from "../../store/message/actionType";

export const menu = () => (dispatch) => {
  return Helper.menuHelper().then(
    (response) => {
      dispatch({
        type: MENU,
        payload: response,
      });
      return Promise.resolve();
    },
    (error) => {
      dispatch({
        type: SET_MESSAGE,
        payload: error,
      });
      return Promise.reject();
    }
  );
};

// export const manufactures = () => (dispatch) => {
//   return Helper.manufacturesHelper().then(
//     (response) => {
//       dispatch({
//         type: GET_ALL_MANUFACTURES,
//         payload: response,
//       });
//       return Promise.resolve();
//     },
//     (error) => {
//       dispatch({
//         type: SET_MESSAGE,
//         payload: error,
//       });
//       return Promise.reject();
//     }
//   );
// };
//
// export const subCategories = () => (dispatch) => {
//   return Helper.subCategoriesHelper().then(
//     (response) => {
//       dispatch({
//         type: GET_ALL_SUBCATEGORIES,
//         payload: response,
//       });
//       return Promise.resolve();
//     },
//     (error) => {
//       dispatch({
//         type: SET_MESSAGE,
//         payload: error,
//       });
//       return Promise.reject();
//     }
//   );
// };
