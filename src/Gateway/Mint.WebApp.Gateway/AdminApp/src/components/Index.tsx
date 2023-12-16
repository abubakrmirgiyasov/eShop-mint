import React, {FC} from 'react';
import { Routes, Route } from "react-router-dom";
import { protectedRoutes, publicRoutes } from "../routes/AllRoutes";
import useThemeDetector from "../hooks/useThemeDetector";
import PublicRoutesLayout from "./Layouts/PublicRoutesLayout";
import ProtectedRoutesLayout from "./Layouts/ProtectedRoutesLayout";
import AdminLayout from "./Layouts/AdminLayout";
import NotFound404 from "../pages/Errors/NotFound404";
import InternalServer500 from "../pages/Errors/InternalServer500";

const Index: FC = () => {
    const themeDetector = useThemeDetector();

    return(
        <React.Fragment>
            <Routes>
                <Route>
                    <Route
                        path={"*"}
                        element={<NotFound404 />}
                    />
                    <Route
                        path={"/internal-server-500"}
                        element={<InternalServer500 />}
                    />
                    {publicRoutes.map((route, key) => (
                        <Route
                            key={key}
                            path={route.path}
                            exact={route.exact}
                            element={
                                <PublicRoutesLayout theme={themeDetector}>
                                    <React.Fragment>
                                        {route.component}
                                    </React.Fragment>
                                </PublicRoutesLayout>
                            }
                        />
                    ))}
                </Route>
                <Route>
                    {protectedRoutes.map((route, key) => (
                        <Route
                            key={key}
                            path={route.path}
                            exact={route.exact}
                            element={
                                <ProtectedRoutesLayout>
                                    <AdminLayout>
                                        {route.component}
                                    </AdminLayout>
                                </ProtectedRoutesLayout>
                            }
                        />
                    ))}
                </Route>
            </Routes>
        </React.Fragment>
    );
};

export default Index;