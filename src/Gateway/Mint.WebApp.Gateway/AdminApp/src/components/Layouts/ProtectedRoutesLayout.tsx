import React, {useEffect} from 'react';
import {useDispatch} from "react-redux";
import {useProfile} from "../../hooks/useProfile";
import { Navigate } from "react-router-dom";

const ProtectedRoutesLayout = (props) => {
    const dispatch = useDispatch();
    const { user, isLoading, token } = useProfile();

    useEffect(() => {
        if (!user && isLoading && !token)
            console.log("dispatch(logout)");
    }, [user, isLoading, token, dispatch]);

    if (!user && isLoading && !token)
        return (
            <Navigate
                to={{
                    pathname: "/sign-in",
                    state: {
                        from: props.location
                    }
                }}
            />
        );

    return (
        <React.Fragment>
            {props.children}
        </React.Fragment>
    );
};

export default ProtectedRoutesLayout;