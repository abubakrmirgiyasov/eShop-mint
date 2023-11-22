import React, {FC} from 'react';
import {toast} from "react-toastify";

const ErrorAlert: FC<{ message: string }> = ({ message }) => {
    toast.error(message);
};

export default ErrorAlert;