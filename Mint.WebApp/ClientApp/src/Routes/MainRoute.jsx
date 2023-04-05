import React from "react";
import { Routes, Route } from "react-router-dom";
import { privateRoutes, publicRoutes } from "./RoutesData";
import PublicRoutesLayout from "../components/RoutesLayout/PublicRoutesLayout";
import Layout from "../components/Layouts/Layout";

const MainRoute = () => {
  return (
    <React.Fragment>
      <Routes>
        <Route>
          {publicRoutes.map((route, index) => (
            <Route
              path={route.path}
              element={
                <PublicRoutesLayout>
                  <Layout>{route.component}</Layout>
                </PublicRoutesLayout>
              }
              key={index}
              exact={true}
            />
          ))}
        </Route>
        {/* <Route>
          {privateRoutes.map((route, index) => {
            <Route
              path={route.path}
              element={

              }
              key={index}
              exact={true}
            />;
          })}
        </Route> */}
      </Routes>
    </React.Fragment>
  );
};

export default MainRoute;
