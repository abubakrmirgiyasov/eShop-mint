import React, { FC, ReactNode } from "react";

const ManufactureTableColumnController: FC<ReactNode> = () => {
  return (
    <React.Fragment>
      <div className={"form-check form-switch form-switch-success"}>
        <label className={"form-check-label"}>
          <input
            className={"form-check-input"}
            role={"switch"}
            type={"checkbox"}
            id={"flexSwitchCheckDefault"}
            defaultChecked={true}
          />
          Страна
        </label>
      </div>
      <div className={"form-check form-switch form-switch-success"}>
        <label className={"form-check-label"}>
          <input
            className={"form-check-input"}
            role={"switch"}
            type={"checkbox"}
            id={"flexSwitchCheckDefault"}
            defaultChecked={true}
          />
          Сайт
        </label>
      </div>
      <div className={"form-check form-switch form-switch-success"}>
        <label className={"form-check-label"}>
          <input
            className={"form-check-input"}
            role={"switch"}
            type={"checkbox"}
            id={"flexSwitchCheckDefault"}
            defaultChecked={true}
          />
          Email
        </label>
      </div>
      <div className={"form-check form-switch form-switch-success"}>
        <label className={"form-check-label"}>
          <input
            className={"form-check-input"}
            role={"switch"}
            type={"checkbox"}
            id={"flexSwitchCheckDefault"}
            defaultChecked={true}
          />
          Телефон
        </label>
      </div>
      <div className={"form-check form-switch form-switch-success"}>
        <label className={"form-check-label"}>
          <input
            className={"form-check-input"}
            role={"switch"}
            type={"checkbox"}
            id={"flexSwitchCheckDefault"}
            defaultChecked={true}
          />
          Полный адрес
        </label>
      </div>
      <div className={"form-check form-switch form-switch-success"}>
        <label className={"form-check-label"}>
          <input
            className={"form-check-input"}
            role={"switch"}
            type={"checkbox"}
            id={"flexSwitchCheckDefault"}
            defaultChecked={true}
          />
          Картинка
        </label>
      </div>
      <div className={"form-check form-switch form-switch-success"}>
        <label className={"form-check-label"}>
          <input
            className={"form-check-input"}
            role={"switch"}
            type={"checkbox"}
            id={"flexSwitchCheckDefault"}
            defaultChecked={true}
          />
          Описание
        </label>
      </div>
    </React.Fragment>
  );
};

export default ManufactureTableColumnController;
