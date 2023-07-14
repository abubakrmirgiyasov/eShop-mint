import React from "react";
import { Dropdown, DropdownToggle } from "reactstrap";

const CompareList = () => {
  return (
    <React.Fragment>
      <div>
        <Dropdown
          isOpen={false}
          toggle={() => {}}
          className={"topbar-head-dropdown ms-1 header-item"}
        >
          <DropdownToggle
            type={"button"}
            tag={"button"}
            className={
              "btn btn-icon btn-topbar btn-ghost-secondary rounded-circle"
            }
          >
            <i className="ri-scales-line fs-22"></i>
            <span
              className={
                "position-absolute cartitem-badge topbar-badge fs-10 translate-middle badge rounded-pill bg-danger"
              }
            >
              {0}
            </span>
          </DropdownToggle>
        </Dropdown>
      </div>
    </React.Fragment>
  );
};

export default CompareList;
