import React, { useEffect, useState } from 'react';
import Header from '../Header/Header';
// import { useDispatch } from 'react-redux';
import Menu from '../Header/Menu';
import { Link } from 'react-router-dom';

const Layout = ({ children }) => {
    const [headerClass, setHeaderClass] = useState("");
    // const dispatch = useDispatch();

    // const { layoutType, layout}

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
                <Header 
                    headerClass={headerClass}
                    layoutMode={""}
                    onChangeLayoutMode={""}
                />
                <Menu />
            </div>
        </React.Fragment>
    );
}

export default Layout;
