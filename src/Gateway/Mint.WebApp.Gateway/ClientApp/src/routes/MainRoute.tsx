import { Routes, Route } from "react-router-dom";
import { privateRoutes, publicRoutes, adminRoutes } from "./RoutesData";
import {
  AdminRoutesLayout,
  PrivateRoutesLayout,
  PublicRoutesLayout,
} from "./ProtectedRoutes";
import React, { useEffect } from "react";
import Layout from "../components/Layouts/Layout";
import AdminLayout from "../Admin/components/Layouts/AdminLayout";
import { useDispatch, useSelector } from "react-redux";
import { getMyStore } from "../services/userStores/userStore";
import { IAuth } from "../services/types/IAuth";
import { fetch } from "../helpers/fetch";

const MainRoute = () => {
  const dispatch = useDispatch();

  const { auth }: { auth: IAuth } = useSelector((state) => ({
    auth: state.Auth,
  }));

  useEffect(() => {
    if (auth.isLoggedIn) {
      dispatch(getMyStore(fetch(), auth.user.id));
    }
  }, [auth]);

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
