import React, { FC, ReactNode } from "react";

const CustomDivider: FC<ReactNode> = () => {
  return (
    <div
      style={{
        width: "100%",
        height: "1px",
        background: "rgb(210 210 210)",
      }}
      className={"mb-3"}
    ></div>
  );
};

export default CustomDivider;
