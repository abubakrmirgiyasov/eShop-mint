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

const publicRoutes = [
    { path: "*", component: <Error /> },
    { path: "/", exact: true, component: <Navigate to="/home" /> },
    { path: "/home", component: <Home /> },
    { path: "/logout", component: <Signout /> },
    { path: "/product-details/:id", component: <ProductDetail /> },
    { path: "/signup", component: <Signup /> },
];

const privateRoutes = [
    { path: "/profile", component: <Profile /> },
];

const adminRoutes = [
    { path: "/admin/admin-signin", component: <AdminSignin /> },
    { path: "/admin/admin-dashboard", component: <AdminDashboard /> },
    { path: "/admin/categories", component: <Categories /> },
    { path: "/admin/products", component: <Prodcuts /> },
];

export { privateRoutes, publicRoutes, adminRoutes };