import React, { useEffect } from "react";
import { Routes, Route } from "react-router-dom";
import {
  adminRoutes,
  privateRoutes,
  publicRoutes,
} from "./RoutesData";
import PublicRoutesLayout from "../components/RoutesLayout/PublicRoutesLayout";
import { PrivateRoutesLayout } from "../components/RoutesLayout/PrivateRoutesLayout";
import AdminRoutes from "../components/RoutesLayout/AdminRoutes";
import Layout from "../components/Layouts/Layout";
import AdminLayout from "../components/Layouts/AdminLayout";
import { useDispatch } from "react-redux";
import { myStore } from "../Common/UserStores/myStore";

const MainRoute = () => {
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(myStore());
  }, [dispatch]);

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
        <Route>
          {privateRoutes.map((route, index) => (
            <Route
              path={route.path}
              element={
                <PrivateRoutesLayout>
                  <Layout>{route.component}</Layout>
                </PrivateRoutesLayout>
              }
              key={index}
              exact={true}
            />
          ))}
        </Route>
        <Route>
          {adminRoutes.map((route, index) => (
            <Route
              path={route.path}
              element={
                <AdminRoutes>
                  <AdminLayout>{route.component}</AdminLayout>
                </AdminRoutes>
              }
              key={index}
              exact={true}
            />
          ))}
        </Route>
      </Routes>
    </React.Fragment>
  );
};

export default MainRoute;
