import React, { useMemo } from "react";
import DataTable from "react-data-table-component";
import {
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
  UncontrolledDropdown,
} from "reactstrap";
import PrivateComponent from "../../../helpers/privateComponent";
import { Roles } from "../../../constants/Roles";
import { Link } from "react-router-dom";

const CategoriesTable = ({ data, handleDeleteClick }) => {
  const columns = useMemo(
    () => [
      {
        id: "displayOrder",
        name: <span className="font-weight-bold fs-13">Сортировать по</span>,
        selector: (row) => row.displayOrder,
        sortable: true,
      },
      {
        name: <span className="font-weight-bold fs-13">Название</span>,
        selector: (row) => row.name,
        sortable: true,
      },
      {
        name: <span className="font-weight-bold fs-13">Родитель</span>,
        selector: (row) => row.subCategory,
        sortable: true,
      },
      {
        name: <span className="font-weight-bold fs-13">Текст значка</span>,
        cell: (row) => (
          <span className={`badge bg-${row.badgeStyle}`}>{row.badgeText}</span>
        ),
      },
      {
        name: <span className="font-weight-bold fs-13">Производитель</span>,
        selector: (row) => row.manufacture,
        sortable: true,
      },
      {
        name: <span className="font-weight-bold fs-13">Картинки</span>,
        cell: (row) => (
          <img
            src={row.photo}
            alt={""}
            className={"rounded"}
            width={50}
            height={50}
          />
        ),
      },
      {
        name: <span className="font-weight-bold fs-13">Действие</span>,
        cell: (row) => (
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
                <DropdownItem className={"edit-item-btn"} roles={[Roles.Admin]}>
                  <i
                    className={"ri-pencil-fill align-bottom me-2 text-muted"}
                  ></i>
                  <Link to={`/admin/categories/edit/${row.id}`}>
                    Редактировать
                  </Link>
                </DropdownItem>
                <DropdownItem
                  className={"edit-item-btn"}
                  roles={[Roles.Admin]}
                  onClick={() => handleDeleteClick({ id: row.id })}
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
    <DataTable
      columns={columns}
      data={data || []}
      pagination={true}
      highlightOnHover={true}
      defaultSortFieldId={"displayOrder"}
      defaultSortAsc={true}
    />
  );
};

export default CategoriesTable;
