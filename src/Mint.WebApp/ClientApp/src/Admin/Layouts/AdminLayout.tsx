import React, { ReactNode } from "react";

const AdminLayout = ({ children }: ReactNode) => {
  return (
    <React.Fragment>
      <div id={"layout-wrapper"}>
        <div className={"main-content"}>{children}</div>
      </div>
    </React.Fragment>
  );
};

export default AdminLayout;
