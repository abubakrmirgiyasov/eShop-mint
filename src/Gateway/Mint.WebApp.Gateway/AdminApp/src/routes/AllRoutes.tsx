import SignInPage from "../pages/Authentication/SignIn";
import {IAllRoute} from "../types/Common/IAllRoute";

export const protectedRoutes: IAllRoute[] = [
    {
        path: "/",
        component: <SignInPage />,
        exact: true,
    }
];

export const publicRoutes: IAllRoute[] = [
    {
        path: "/sign-in",
        component: <SignInPage />,
        exact: true,
    },
];
