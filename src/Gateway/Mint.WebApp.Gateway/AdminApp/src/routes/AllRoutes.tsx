import {IAllRoute} from "../types/Common/IAllRoute";
import SignInPage from "../pages/Authentication/SignIn";
import ForgotPassword from "../pages/Authentication/ForgotPassword";
import Dashboard from "../pages/Home/Dashboard";
import Tags from "../pages/Tag/Tags";

export const protectedRoutes: IAllRoute[] = [
    {
        path: "/",
        component: <Dashboard />,
        exact: true,
    },
    {
        path: "/admin/dashboard",
        component: <Dashboard />,
        exact: true,
    },
    {
        path: "/admin/news/tags",
        component: <Tags />,
        exact: false,
    }
];

export const publicRoutes: IAllRoute[] = [
    {
        path: "/sign-in",
        component: <SignInPage />,
        exact: true,
    },
    {
        path: "/forgot-password",
        component: <ForgotPassword />,
        exact: true,
    },
];
