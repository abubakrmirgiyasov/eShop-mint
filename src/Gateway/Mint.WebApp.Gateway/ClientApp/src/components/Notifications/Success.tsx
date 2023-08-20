import React, { FC, useEffect } from "react";
import { INotification } from "../../services/types/INotification";
import { toast } from "react-toastify";

const Success: FC<INotification> = ({ message }) => {
  useEffect(() => {
    toast.success(message, {
      position: toast.POSITION.TOP_RIGHT,
    });
  }, []);
};

export { Success };
