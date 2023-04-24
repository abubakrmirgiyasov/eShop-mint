// import { call, takeEvery, fork, all } from "redux-saga/effects";
// import {
//   CHANGE_LAYOUT_MODE,
//   CHANGE_LAYOUT_TYPE,
//   CHANGE_LAYOUT_TYPE_SIZE,
// } from "../store/theme/actionType";

// function changeHTMLAttribute(attribute, value) {
//   console.log(value);

//   if (document.documentElement) {
//     document.documentElement.setAttribute(attribute, value);
//   }
//   return true;
// }

// /**
//  * @param {*} param0
//  */
// function* changeLayoutType({ payload: layout }) {
//   try {
//     if (layout === "horizontal")
//       document.documentElement.removeAttribute("data-sidebar-size");
//     yield call(changeHTMLAttribute, "data-layout", layout);
//   } catch (error) {
//     console.log(error);
//   }
// }

// /**
//  * @param {*} param0
//  */
// function* changeLayoutTypeSize({ payload: layoutTypeSize }) {
//   try {
//     switch (layoutTypeSize) {
//       case "lg":
//         yield call(changeHTMLAttribute, "data-sidebar-size", "lg");
//         break;
//       case "md":
//         yield call(changeHTMLAttribute, "data-sidebar-size", "md");
//         break;
//       case "sm":
//         yield call(changeHTMLAttribute, "data-sidebar-size", "sm");
//         break;
//       case "sm-hover":
//         yield call(changeHTMLAttribute, "data-sidebar-size", "sm-hover");
//         break;
//       default:
//         yield call(changeHTMLAttribute, "data-sidebar-size", "lg");
//     }
//   } catch (error) {
//     console.log(error);
//   }
// }

// /**
//  * @param {*} param0
//  */
// function* changeLayoutMode({ payload: mode }) {
//   try {
//     yield call(changeHTMLAttribute, "data-layout-mode", mode);
//   } catch (error) {
//     console.log(error);
//   }
// }

// /**
//  * @param {*} param0
//  */
// function* chang({ payload: mode }) {
//   try {
//     yield call(changeHTMLAttribute, "data-layout-mode", mode);
//   } catch (error) {
//     console.log(error);
//   }
// }

// export function* watchChangeLayoutMode() {
//   yield takeEvery(CHANGE_LAYOUT_MODE, changeLayoutMode);
// }

// export function* watchChangeLayoutType() {
//   yield takeEvery(CHANGE_LAYOUT_TYPE, changeLayoutType);
// }

// export function* watchChangeLayoutTypeSize() {
//   yield takeEvery(CHANGE_LAYOUT_TYPE_SIZE, changeLayoutTypeSize);
// }

// function* LayoutSaga() {
//   yield all([
//     fork(watchChangeLayoutMode),
//     fork(watchChangeLayoutType),
//     fork(watchChangeLayoutTypeSize),
//   ]);
// }

// export default LayoutSaga;
