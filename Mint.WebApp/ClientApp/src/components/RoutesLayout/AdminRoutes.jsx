import React, { useEffect } from 'react';
import { useSelector } from 'react-redux';
import { Navigate } from 'react-router-dom';

const AdminRoutes = (props) => {
    const { Signin: user } = useSelector(user => user);    

    useEffect(() => {
        if (!user.isLoggedIn) {
            <Navigate to="/" />
        }
    }, [user]);

    return (
        <>{props.children}</>
    );
}

export default AdminRoutes;
