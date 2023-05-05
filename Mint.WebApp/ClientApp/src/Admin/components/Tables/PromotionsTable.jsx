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

const PromotionsTable = ({ data, updateData, removeData }) => {
  const setUpdateData = (row) => {
    updateData(row);
  };

  const setRemoveData = (row) => {
    removeData(row.id);
  };

  const columns = useMemo(
    () => [
      {
        name: <span className={"font-weight-bold fs-13"}>Название</span>,
        selector: (row) => row.name,
        sortable: true,
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Процент</span>,
        selector: (row) => row.percent,
        sortable: true,
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Дата создания</span>,
        selector: (row) => {
          const date = new Date(row.createdDate);
          const month = date.getUTCMonth() + 1; //months from 1-12
          const day = date.getUTCDate();
          const year = date.getUTCFullYear();
          return day + " / " + month + " / " + year;
        },
        sortable: true,
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Действителен до</span>,
        selector: (row) => {
          const date = new Date(row.activeDateUntil);
          const month = date.getUTCMonth() + 1; //months from 1-12
          const day = date.getUTCDate() + 1;
          const year = date.getUTCFullYear();
          return day + " / " + month + " / " + year;
        },
        sortable: true,
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Действие</span>,
        cell: (row) => (
          <PrivateComponent>
            <UncontrolledDropdown roles={[Roles.Admin]}>
              <DropdownToggle
                className={"btn btn-soft-secondary btn-sm"}
                tag={"button"}
              >
                <i className={"ri-more-fill align-middle"}></i>
              </DropdownToggle>
              <DropdownMenu className={"dropdown-menu-end"}>
                <DropdownItem
                  className={"edit-item-btn"}
                  onClick={() => setUpdateData(row)}
                >
                  <i
                    className={"ri-pencil-fill align-bottom me-2 text-muted"}
                  ></i>{" "}
                  Изменить
                </DropdownItem>
                <DropdownItem
                  className={"remove-item-btn"}
                  onClick={() => setRemoveData(row)}
                >
                  <i className="ri-delete-bin-fill align-bottom me-2 text-muted"></i>{" "}
                  Удалить
                </DropdownItem>
              </DropdownMenu>
            </UncontrolledDropdown>
          </PrivateComponent>
        ),
      },
    ],
    []
  );

  return (
    <DataTable
      columns={columns}
      data={data || []}
      pagination={true}
      highlightOnHover={true}
    />
  );
};

export default PromotionsTable;
