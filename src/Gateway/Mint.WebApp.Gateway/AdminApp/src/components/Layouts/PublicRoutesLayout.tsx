import React, {FC, useEffect} from 'react';
import {useSelector} from "react-redux";

interface IPublicRoutesLayout {
    theme: boolean;
}

const PublicRoutesLayout: FC<IPublicRoutesLayout> = ({ theme, children }) => {
    // const { layoutMode } = useSelector(state => ({
    //     layoutMode: state.Layout?.layoutModeType,
    // }));

    useEffect(() => {
        console.log(theme ? "dark" : "light")
        // if (layoutMode) {
        //     if (layoutMode === "dark")
        //         document.body.setAttribute("data-layout-mode", "dark");
        //     else
        //         document.body.setAttribute("data-layout-mode", "light");
        // } else {
            document.body.setAttribute("data-layout-mode",  theme ? "dark" : "light");
        // }
    }, []); // layoutMode

    return (
      <React.Fragment>
          {children}
      </React.Fragment>
    );
};

export default PublicRoutesLayout;