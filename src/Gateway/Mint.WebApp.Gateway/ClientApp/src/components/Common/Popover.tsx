import React, { FC } from "react";
import { UncontrolledTooltip } from "reactstrap";

interface IPopover {
  id: string;
  text?: string;
  placement: string;
}

const Popover: FC<IPopover> = ({ id, text, placement }) => {
  return (
    <React.Fragment>
      <i className={"ri-question-fill"} id={id}></i>
      <UncontrolledTooltip placement={placement} target={id}>
        {text}
      </UncontrolledTooltip>
    </React.Fragment>
  );
};

export default Popover;
