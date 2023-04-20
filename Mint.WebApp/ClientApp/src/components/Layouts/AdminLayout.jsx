import React, { Children, useEffect, useState } from 'react';
import AdminHeader from '../../Admin/components/Header/AdminHeader';
import { useDispatch, useSelector } from 'react-redux';
import { changeLayoutMode, changeLayoutType } from '../../store/theme/reducer';
import AdminSidebar from '../Header/AdminSidebar';
import { changeLayoutTypeSize } from '../../store/theme/reducer';

const AdminLayout = ({ children }) => {
    const [headerClass, setHeaderClass] = useState("");
    const dispatch = useDispatch();

    const { layout } = useSelector((state) => ({
        layout: state.Theme.layout,
    }));

    useEffect(() => {
        if (layout)
            dispatch(changeLayoutMode(layout));
        
        dispatch(changeLayoutType("vertical"));
        dispatch(changeLayoutTypeSize("lg"));
    }, [layout, dispatch]);

    const onChangeLayoutMode = (value) => (dispatch) => {
        console.log("first")
        if (changeLayoutMode)
            dispatch(changeLayoutMode(value));
    };

    useEffect(() => {
        window.addEventListener("scroll", scrollNavigation, true);
    });

    function scrollNavigation() {
        let scrollUp = document.documentElement.scrollTop;
        setHeaderClass(scrollUp > 50 ? "top-shadow" : "");
    }

    return (
        <React.Fragment>
            <div id="layout-wrapper">
                <AdminHeader 
                    headerClass={headerClass}
                    onChangeLayoutMode={onChangeLayoutMode}
                    layoutModeType={layout}
                />
                <AdminSidebar 
                    layoutType={"vetical"}
                />
                <div className='main-content'>{children}</div>
            </div>
        </React.Fragment>
    );
}

export default AdminLayout;
