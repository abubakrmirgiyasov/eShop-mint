import React, { FC } from "react";

interface Error {
  message: string;
}

const CustomErrorStyle: FC<Error> = ({ message }) => {
  const customError = {
    width: "100%",
    marginTop: "0.25rem",
    fontSize: "0.875em",
    color: "#f06548",
  };

  return <div style={customError}>{message}</div>;
};

export default CustomErrorStyle;
