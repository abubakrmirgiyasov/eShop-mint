import React, { FC, useState } from "react";
import { INotification } from "../../types/Notifications/INotification";
import { Toast, ToastBody, ToastHeader } from "reactstrap";
import { getFullDateWithTime } from "../../helpers/dateConverter";
import { Colors } from "../../constants/commonList";

// static files
import logoSm from "../../assets/images/logos/logo.png";

const Notification: FC<INotification> = ({ message, type }) => {
  const [isNotification, setIsNotification] = useState<boolean>(!!message);
  const date = new Date();

  const toggleNotification = () => setIsNotification(!isNotification);

  return (
    <React.Fragment>
      <div className={"toast-container position-absolute p-3 bottom-0 end-0"}>
        <Toast className={`bg-${Colors[type]}`} isOpen={isNotification}>
          <ToastHeader toggle={toggleNotification}>
            <img
              src={logoSm}
              className={"rounded me-2"}
              alt={"logo"}
              height={20}
            />
            <span className={"fw-semibold me-auto"}>Mint</span>
            <small style={{ marginLeft: "130px" }}>
              {getFullDateWithTime({ date })}
            </small>
          </ToastHeader>
          <ToastBody className={"text-light"}>{message}</ToastBody>
        </Toast>
      </div>
    </React.Fragment>
  );
};

export default Notification;
