import { Routes, Route } from "react-router-dom";
import { privateRoutes, publicRoutes } from "./RoutesData";
import { PrivateRoutesLayout, PublicRoutesLayout } from "./ProtectedRoutes";
import React from "react";
import Layout from "../components/Layouts/Layout";

const MainRoute = () => {
  return (
    <React.Fragment>
      <Routes>
        <Route>
          {publicRoutes.map((route, key) => (
            <Route
              key={key}
              path={route.path}
              element={
                <PublicRoutesLayout>
                  <Layout>{route.component}</Layout>
                </PublicRoutesLayout>
              }
            />
          ))}
        </Route>
        <Route>
          {privateRoutes.map((route, key) => (
            <Route
              key={key}
              path={route.path}
              element={
                <PrivateRoutesLayout>
                  <Layout>{route.component}</Layout>
                </PrivateRoutesLayout>
              }
            />
          ))}
        </Route>
      </Routes>
    </React.Fragment>
  );
};

export default MainRoute;
