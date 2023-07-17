import { ReactNode } from "react";
import { Navigate } from "react-router-dom";
import Error from "../pages/Errors/Error";
import Home from "../pages/Home/Home";
import Profile from "../pages/Profile/Profile";
import SignOut from "../pages/Authentication/SignOut";
import SignInBase from "../pages/Authentication/SignInBase";

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
];

const privateRoutes: Routes[] = [
  { path: "/profile/:wh", component: <Profile /> },
  { path: "/logout", component: <SignOut /> },
];

export { publicRoutes, privateRoutes };
