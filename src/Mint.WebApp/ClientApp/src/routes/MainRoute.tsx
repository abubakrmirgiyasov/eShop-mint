import { Routes, Route } from "react-router-dom";
import { privateRoutes, publicRoutes, adminRoutes } from "./RoutesData";
import {
  AdminRoutesLayout,
  PrivateRoutesLayout,
  PublicRoutesLayout,
} from "./ProtectedRoutes";
import React from "react";
import Layout from "../components/Layouts/Layout";
import AdminLayout from "../Admin/components/Layouts/AdminLayout";

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
        <Route>
          {adminRoutes.map((route, key) => (
            <Route
              key={key}
              path={route.path}
              element={
                <AdminRoutesLayout>
                  <AdminLayout>{route.component}</AdminLayout>
                </AdminRoutesLayout>
              }
            />
          ))}
        </Route>
      </Routes>
    </React.Fragment>
  );
};

export default MainRoute;
