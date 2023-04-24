import { Navigate } from 'react-router-dom';
import Error from '../Pages/Error/Error';
import Profile from '../Pages/Profile/Profile';
import Home from '../Pages/Home/Home';
import Signout from '../Pages/Auth/Signout';
import ProductDetail from '../Pages/Products/ProductDetail';
import AdminSignin from '../Admin/Pages/Auth/AdminSignin';
import AdminDashboard from '../Admin/Pages/Dashboard/AdminDashboard';
import Categories from '../Admin/Pages/Category/Categories';
import Prodcuts from '../Admin/Pages/Product/Prodcuts';
import Signup from '../Pages/Auth/Signup';
import OrderDetails from '../Pages/Orders/OrderDetails';
import CategoryAction from '../Admin/Pages/Category/CategoryAction';
import Manufactures from '../Admin/Pages/Manufactures/Manufactures';
import ManufacturesAction from '../Admin/Pages/Manufactures/ManufacturesAction';

const publicRoutes = [
    { path: "*", component: <Error /> },
    { path: "/", exact: true, component: <Navigate to="/home" /> },
    { path: "/home", component: <Home /> },
    { path: "/logout", component: <Signout /> },
    { path: "/product-details/:id", component: <ProductDetail /> },
    { path: "/signup", component: <Signup /> },
    { path: "/admin/admin-signin", component: <>"test"</> },
];

const privateRoutes = [
    { path: "/profile", component: <Profile /> },
    { path: "/orders/details/:id", component: <OrderDetails /> },
];

const adminRoutes = [
    // { path: "*", component: <Error /> },
    // { path: "/", exact: true, component: <Navigate to="/home" /> },
    { path: "/admin/admin-dashboard", component: <AdminDashboard /> },
    { path: "/admin/categories", component: <Categories /> },
    { path: "/admin/products", component: <Prodcuts /> },
    { path: "/admin/categories/add", component: <CategoryAction /> },
    { path: "/admin/categories/edit/:id", component: <CategoryAction /> },
    { path: "/admin/manufactures", component: <Manufactures /> },
    { path: "/admin/manufactures/add", component: <ManufacturesAction /> },
    { path: "/admin/manufactures/edit/:id", component: <ManufacturesAction /> },
];

const emptyRoutes = [
    { path: "/test", component: <AdminSignin /> }
];

export { privateRoutes, publicRoutes, adminRoutes, emptyRoutes };