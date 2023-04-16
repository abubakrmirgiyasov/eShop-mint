import { toast } from "react-toastify";

export const Error = ({ message }) => {
  toast.error(message, {
    position: toast.POSITION.TOP_RIGHT,
  });
};
