import { FC, useEffect } from "react";
import { INotification } from "../../services/types/INotification";
import { toast } from "react-toastify";

const Error: FC<INotification> = ({ message }) => {
  useEffect(() => {
    toast.error(message, {
      position: toast.POSITION.TOP_RIGHT,
    });
  }, []);
};

export { Error };
