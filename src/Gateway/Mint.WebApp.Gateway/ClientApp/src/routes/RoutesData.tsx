import { ReactNode } from "react";
import { Navigate } from "react-router-dom";
import Error from "../pages/Errors/Error";
import Home from "../pages/Home/Home";
import Profile from "../pages/Profile/Profile";
import SignOut from "../pages/Authentication/SignOut";
import SignInBase from "../pages/Authentication/SignInBase";
import AdminDashboard from "../Admin/pages/AdminDashboard";
import Manufactures from "../Admin/pages/Manufacture/Manufactures";
import ManufactureAction from "../Admin/pages/Manufacture/ManufactureAction";
import Categories from "../Admin/pages/Category/Categories";
import CategoryAction from "../Admin/pages/Category/CategoryAction";
import Tags from "../Admin/pages/Tag/Tags";
import SubCategoryAction from "../Admin/pages/SubCategory/SubCategoryAction";
import Search from "../pages/Search/Search";

type Routes = {
  path: string;
  component: ReactNode;
  exact?: boolean;
};

const publicRoutes: Routes[] = [
  { path: "*", component: <Error /> },
  { path: "/", exact: true, component: <Navigate to={"home"} /> },
  { path: "/home", component: <Home /> },
  { path: "/signin", component: <SignInBase /> },
  { path: "/search/:query", component: <Search /> },
];

const privateRoutes: Routes[] = [
  { path: "/profile/:wh", component: <Profile /> },
  { path: "/logout", component: <SignOut /> },
];

const adminRoutes: Routes[] = [
  { path: "/admin/admin-dashboard", component: <AdminDashboard /> },
  { path: "/admin/manufactures", component: <Manufactures /> },
  { path: "/admin/manufactures/add", component: <ManufactureAction /> },
  { path: "/admin/manufactures/edit/:id", component: <ManufactureAction /> },
  { path: "/admin/categories", component: <Categories /> },
  { path: "/admin/categories/add", component: <CategoryAction /> },
  { path: "/admin/categories/edit/:id", component: <CategoryAction /> },
  { path: "/admin/news/tags", component: <Tags /> },
  {
    path: "/admin/categories/add/subcategory",
    component: <SubCategoryAction />,
  },
  {
    path: "/admin/categories/edit/subcategory/:id",
    component: <SubCategoryAction />,
  },
];

export { publicRoutes, privateRoutes, adminRoutes };
