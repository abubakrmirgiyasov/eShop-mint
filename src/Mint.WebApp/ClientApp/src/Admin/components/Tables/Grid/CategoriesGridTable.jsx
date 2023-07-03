import React, { useMemo } from "react";
import { Grid, _ } from "gridjs-react";
import {
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
  UncontrolledDropdown,
} from "reactstrap";
import PrivateComponent from "../../../../helpers/privateComponent";
import { Roles } from "../../../../constants/Roles";
import { Link } from "react-router-dom";

const CategoriesGridTable = ({ data, handleDeleteClick }) => {
  const columns = useMemo(
    () => [
      {
        name: "ID",
        formatter: (cell) => _(cell.id),
      },
      "",
      "",
      "",
      "",
      {
        name: <span className="font-weight-bold fs-13">Название</span>,
        formatter: (cell) => _(cell.name),
      },
      {
        name: <span className="font-weight-bold fs-13">Родитель</span>,
        formatter: (cell) => _(cell.subCategory),
      },
      {
        name: <span className="font-weight-bold fs-13">Текст значка</span>,
        formatter: (cell) =>
          _(
            <span className={`badge bg-${cell.badgeStyle}`}>
              {cell.badgeText}
            </span>
          ),
      },
      {
        name: <span className="font-weight-bold fs-13">Производитель</span>,
        formatter: (cell) => _(cell.manufacture),
      },
      {
        name: <span className="font-weight-bold fs-13">Картинки</span>,
        formatter: (cell) =>
          _(
            <img
              src={cell.photo}
              alt={""}
              className={"rounded"}
              width={50}
              height={50}
            />
          ),
      },
      {
        name: <span className="font-weight-bold fs-13">Действие</span>,
        formatter: (cell) =>
          _(
            <UncontrolledDropdown>
              <DropdownToggle
                className={"btn btn-soft-secondary btn-sm"}
                tag={"button"}
              >
                <i className={"ri-more-fill align-middle"}></i>
              </DropdownToggle>
              <DropdownMenu className={"dropdown-menu-end"}>
                <DropdownItem href={"/brands"}>
                  <i className={"ri-eye-fill align-bottom me-2 text-muted"}></i>
                  Посмотреть
                </DropdownItem>
                <PrivateComponent>
                  <DropdownItem
                    className={"edit-item-btn"}
                    roles={[Roles.Admin]}
                  >
                    <i
                      className={"ri-pencil-fill align-bottom me-2 text-muted"}
                    ></i>
                    <Link to={`/admin/categories/edit/${cell.id}`}>
                      Редактировать
                    </Link>
                  </DropdownItem>
                  <DropdownItem
                    className={"edit-item-btn"}
                    roles={[Roles.Admin]}
                    onClick={() => handleDeleteClick({ id: cell.id })}
                  >
                    <i
                      className={
                        "ri-delete-bin-fill align-bottom me-2 text-muted"
                      }
                    ></i>
                    Удалить
                  </DropdownItem>
                </PrivateComponent>
              </DropdownMenu>
            </UncontrolledDropdown>
          ),
      },
    ],
    [handleDeleteClick]
  );

  return (
    <React.Fragment>
      <Grid
        data={data}
        columns={false}
        search={false}
        sort={true}
        pagination={{ enabled: true, limit: 10 }}
      />
    </React.Fragment>
  );
};

export default CategoriesGridTable;
