import React, { ChangeEvent, FC, useState } from "react";

interface ITagTableController {
  onClick: (position: number) => void;
}

const TagTableColumnController: FC<ITagTableController> = ({ onClick }) => {
  const onChange = (e: ChangeEvent<HTMLInputElement>) => {
    // e.currentTarget.checked = !e.currentTarget.checked;

    switch (e.currentTarget.name) {
      case "0":
        onClick(0);
        break;
      case "1":
        onClick(1);
        break;
    }
  };

  return (
    <React.Fragment>
      <div className={"form-check form-switch form-switch-success"}>
        <label className={"form-check-label"}>
          <input
            className={"form-check-input"}
            role={"switch"}
            type={"checkbox"}
            id={"flexSwitchCheckDefault"}
            name={"0"}
            defaultChecked={true}
            onChange={onChange}
          />
          Uid
        </label>
      </div>
      <div className={"form-check form-switch form-switch-success"}>
        <label className={"form-check-label"}>
          <input
            className={"form-check-input"}
            role={"switch"}
            type={"checkbox"}
            id={"flexSwitchCheckDefault"}
            name={"1"}
            defaultChecked={true}
            onChange={onChange}
          />
          Перевод
        </label>
      </div>
    </React.Fragment>
  );
};

export default TagTableColumnController;
