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

const SubCategoryTable = ({ data, handleDeleteClick, handleUpdateClick }) => {
  const columns = useMemo(() => [
    {
      id: "displayOrder",
      name: <span className={"font-weight-bold fs-13"}>Сортировать по</span>,
      selector: (row) => row.displayOrder,
      sortable: true,
    },
    {
      name: <span className={"font-weight-bold fs-13"}>Название</span>,
      selector: (row) => row.name,
    },
    {
      name: <span className={"font-weight-bold fs-13"}>Иконка</span>,
      cell: (row) => (
        <span className={"fs-18"}>
          <i className={row.ico}></i>
        </span>
      ),
    },
    {
      name: <span className={"font-weight-bold fs-13"}>Действие</span>,
      cell: (row) => {
        return (
          <UncontrolledDropdown className={"dropdown d-inline-block"}>
            <DropdownToggle
              className={"btn btn-soft-secondary btn-sm"}
              tag={"button"}
            >
              <i className={"ri-more-fill align-middle"}></i>
            </DropdownToggle>
            <DropdownMenu className={"dropdown-menu-end"}>
              <PrivateComponent>
                <DropdownItem
                  className={"edit-item-btn"}
                  roles={[Roles.Admin]}
                  onClick={() => handleUpdateClick(row)}
                >
                  <i
                    className={"ri-pencil-fill align-bottom me-2 text-muted"}
                  ></i>
                  Редактировать
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
        );
      },
    },
  ]);

  return (
    <DataTable
      columns={columns}
      data={data || []}
      pagination={true}
      highlightOnHover={true}
      defaultSortAsc={true}
      defaultSortFieldId={"displayOrder"}
    />
  );
};

export default SubCategoryTable;
