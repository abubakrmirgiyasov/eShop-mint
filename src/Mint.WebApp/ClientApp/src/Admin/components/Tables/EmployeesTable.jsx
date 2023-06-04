import React, { useMemo } from "react";
import DataTable from "react-data-table-component";
import { DropdownItem, DropdownMenu, DropdownToggle, UncontrolledDropdown } from "reactstrap";

const EmployeesTable = ({ employees }) => {
  const columns = useMemo(
    () => [
      {
        name: <span className="font-weight-bold fs-13">ФИО</span>,
        selector: (row) => row.firstName + " " + row.secondName,
        sortable: true,
      },
      {
        name: <span className="font-weight-bold fs-13">Кол-во X Цена</span>,
        selector: (row) =>
          ` ₽`,
        sortable: true,
      },
      {
        name: <span className="font-weight-bold fs-13">Сумма</span>,
        selector: (row) => ` ₽`,
        sortable: true,
      },
      {
        name: <span className="font-weight-bold fs-13">Дата рождения</span>,
        selector: (row) =>
          `${new Date(row.dateBirth).getDay()} / ${
            new Date(row.dateBirth).getMonth() + 1
          } ${new Date(row.dateBirth).getFullYear()}`,
        sortable: true,
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Действие</span>,
        cell: (row) => (
          <UncontrolledDropdown>
            <DropdownToggle
              className={"btn btn-soft-secondary btn-sm"}
              tag={"button"}
            >
              <i className={"ri-more-fill align-middle"}></i>
            </DropdownToggle>
            <DropdownMenu className={"dropdown-menu-end"}>
              <DropdownItem href={"/product-details/" + row.id}>
                <i className={"ri-eye-fill align-middle me-2 text-muted"}></i>{" "}
                Просмотр
              </DropdownItem>
              <DropdownItem className={"edit-item-btn"}>
                <i
                  className={"ri-pencil-fill align-middle me-2 text-muted"}
                ></i>{" "}
                Изменить
              </DropdownItem>
              <DropdownItem className={"remove-item-btn"}>
                <i className={"ri-settings-5-line align-middle me-2 text-muted"}></i>{" "}
                Заблокировать
              </DropdownItem>
            </DropdownMenu>
          </UncontrolledDropdown>
        ),
      },
    ],
    []
  );

  return (
    <React.Fragment>
      <DataTable
        columns={columns}
        data={employees || []}
        pagination={true}
        highlightOnHover={true}
      />
    </React.Fragment>
  );
};

export default EmployeesTable;
