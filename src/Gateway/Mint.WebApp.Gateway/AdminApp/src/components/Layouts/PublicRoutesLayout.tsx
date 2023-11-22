import React, {FC, useEffect} from 'react';
import {useSelector} from "react-redux";
import Notification from "../Notifications/Notification";
import {Colors} from "../../constants/commonList";

interface IPublicRoutesLayout {
    theme: boolean;
}

const PublicRoutesLayout: FC<IPublicRoutesLayout> = ({ theme, children }) => {
    const { message } = useSelector((state) => ({
        message: state.Message.message,
        s: console.log(state)
    }));

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
          {message && <Notification message={message} type={Colors.danger} />}
      </React.Fragment>
    );
};

export default PublicRoutesLayout;