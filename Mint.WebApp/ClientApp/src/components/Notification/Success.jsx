import { useEffect } from "react";
import { toast } from "react-toastify";

export const Success = ({ message }) => {
  useEffect(() => {
    toast.success(message, {
      position: toast.POSITION.TOP_RIGHT,
    });
  }, [message])
};