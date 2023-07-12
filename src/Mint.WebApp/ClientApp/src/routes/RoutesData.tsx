import { ReactNode } from "react";
import { Navigate } from "react-router-dom";
import Error from "../pages/Errors/Error";
import Home from "../pages/Home/Home";

type Routes = {
  path: string;
  component: ReactNode;
  exact?: boolean;
};

const publicRoutes: Routes[] = [
  { path: "*", component: <Error /> },
  { path: "/", exact: true, component: <Navigate to={"home"} /> },
  { path: "/home", component: <Home /> },
];

const privateRoutes: Routes[] = [{ path: "/profile/:wh", component: <></> }];

export { publicRoutes, privateRoutes };
