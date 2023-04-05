import { Navigate } from 'react-router-dom';
import Error from '../Pages/Error/Error';
import Profile from '../Pages/Profile/Profile';
import Home from '../Pages/Home/Home';
import Signin from '../Pages/Auth/Signin';

const publicRoutes = [
    { path: "*", component: <Error /> },
    { path: "/", exact: true, component: <Navigate to="/home" /> },
    { path: "/home", component: <Home /> },
    { path: "/signin", component: <Signin /> },
];

const privateRoutes = [
    { path: "/profile", component: <Profile /> }
];

export { privateRoutes, publicRoutes };