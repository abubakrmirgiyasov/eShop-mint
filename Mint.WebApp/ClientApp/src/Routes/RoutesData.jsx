import { Navigate } from "react-router-dom";
import Error from "../Pages/Error/Error";
import Profile from "../Pages/Profile/Profile";
import Home from "../Pages/Home/Home";
import Signout from "../Pages/Auth/Signout";
import ProductDetail from "../Pages/Products/ProductDetail";
import AdminSignin from "../Admin/Pages/Auth/AdminSignin";
import AdminDashboard from "../Admin/Pages/Dashboard/AdminDashboard";
import AdminCategories from "../Admin/Pages/Category/Categories";
import Products from "../Admin/Pages/Product/Products";
import Signup from "../Pages/Auth/Signup";
import OrderDetails from "../Pages/Orders/OrderDetails";
import CategoryAction from "../Admin/Pages/Category/CategoryAction";
import Manufactures from "../Admin/Pages/Manufacture/Manufactures";
import ManufacturesAction from "../Admin/Pages/Manufacture/ManufacturesAction";
import PlaceHolder from "../Pages/test";
import ProductAction from "../Admin/Pages/Product/ProductAction";
import Promotions from "../Admin/Pages/News/Promotions";
import Stores from "../Pages/Stores/Stores";
import SingleStore from "../Pages/Stores/SingleStore";
import SampleCategories from "../Pages/Categories/Categories";
import SingleCategory from "../Pages/Categories/SingleCategory";
import Checkout from "../Pages/Checkout/Checkout";

const publicRoutes = [
  { path: "*", component: <Error /> },
  { path: "/", exact: true, component: <Navigate to="/home" /> },
  { path: "/home", component: <Home /> },
  { path: "/logout", component: <Signout /> },
  { path: "/product-details/:id", component: <ProductDetail /> },
  { path: "/signup", component: <Signup /> },
  { path: "/place", component: <PlaceHolder /> },
  { path: "/stores", component: <Stores /> },
  { path: "/stores/:name", component: <SingleStore /> },
  { path: "/categories", component: <SampleCategories /> },
  { path: "/categories/:name", component: <SingleCategory /> },
  { path: "/checkout", component: <Checkout /> },
  {
    path: "/admin/admin-signin",
    component: <div className={"page-content"}>test</div>,
  },
];

const privateRoutes = [
  { path: "/profile/:wh", component: <Profile /> },
  { path: "/orders/details/:id", component: <OrderDetails /> },
];

const adminRoutes = [
  // { path: "*", component: <Error /> },
  // { path: "/", exact: true, component: <Navigate to="/home" /> },
  { path: "/admin/admin-dashboard", component: <AdminDashboard /> },
  { path: "/admin/categories", component: <AdminCategories /> },
  { path: "/admin/products", component: <Products /> },
  { path: "/admin/categories/add", component: <CategoryAction /> },
  { path: "/admin/categories/edit/:id", component: <CategoryAction /> },
  { path: "/admin/manufactures", component: <Manufactures /> },
  { path: "/admin/manufactures/add", component: <ManufacturesAction /> },
  { path: "/admin/manufactures/edit/:id", component: <ManufacturesAction /> },
  { path: "/admin/products/add", component: <ProductAction /> },
  { path: "/admin/products/edit/:id", component: <ProductAction /> },
  { path: "/admin/news/promotions", component: <Promotions /> },
];

const emptyRoutes = [{ path: "/test", component: <AdminSignin /> }];

export { privateRoutes, publicRoutes, adminRoutes, emptyRoutes };
