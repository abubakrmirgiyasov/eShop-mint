import { useEffect } from "react";
import { toast } from "react-toastify";

export const Error = ({ message }) => {
  useEffect(() => {
    toast.error(message, {
      position: toast.POSITION.TOP_RIGHT,
    });
  }, []);
};
