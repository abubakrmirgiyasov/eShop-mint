import { Routes, Route } from "react-router-dom";
import { publicRoutes } from "./RoutesData";
import { PublicRoutesLayout } from "./ProtectedRoutes";
import Request from "../helpers/requestWrapper/request";
import React from "react";
import Layout from "../components/Layouts/Layout";

const MainRoute = ({ request }: Request) => {
  return (
    <React.Fragment>
      <Routes>
        <Route>
          {publicRoutes.map((route, index) => (
            <Route
              key={index}
              path={route.path}
              element={
                <PublicRoutesLayout>
                  <Layout>{route.component}</Layout>
                </PublicRoutesLayout>
              }
            />
          ))}
        </Route>
      </Routes>
    </React.Fragment>
  );
};

export default MainRoute;
