import React from "react";
import { Link } from "react-router-dom";
import {
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
  UncontrolledDropdown,
} from "reactstrap";
import DataTable from "react-data-table-component";
import PrivateComponent from "../../../helpers/privateComponent";
import { Roles } from "../../../constants/Roles";

const ManufacturesTable = ({ data }) => {
  const columns = [
    {
      id: "displayOrder",
      name: <span className="font-weight-bold fs-13">Показать по</span>,
      selector: (row) => row.displayOrder,
      sortable: true,
    },
    {
      name: <span className="font-weight-bold fs-13">Навзание</span>,
      selector: (row) => {
        return <Link to="/brands">{row.name}</Link>;
      },
      sortable: false,
    },
    {
      name: <span className="font-weight-bold fs-13">Картинки</span>,
      selector: (row) => {
        return (
          <React.Fragment>
            <div className="avatar-group">
              <img src={row.photo} className="avatar-sm" alt={"photo"} />
            </div>
          </React.Fragment>
        );
      },
      sortable: false,
    },
    {
      name: <span className="font-weight-bold fs-13">Действие</span>,
      cell: (row) => {
        return (
          <UncontrolledDropdown className="dropdown d-inline-block">
            <DropdownToggle
              className="btn btn-soft-secondary btn-sm"
              tag="button"
            >
              <i className="ri-more-fill align-middle"></i>
            </DropdownToggle>
            <DropdownMenu className="dropdown-menu-end">
              <DropdownItem href="/brands">
                <i className="ri-eye-fill align-bottom me-2 text-muted"></i>
                Посмотреть
              </DropdownItem>
              <PrivateComponent>
                <DropdownItem className="edit-item-btn" roles={[Roles.Admin]}>
                  <i className="ri-pencil-fill align-bottom me-2 text-muted"></i>
                  <Link to={`/admin/manufactures/edit/${row.id}`}>
                    Редактировать
                  </Link>
                </DropdownItem>
                <DropdownItem className="edit-item-btn" roles={[Roles.Admin]}>
                  <i className="ri-delete-bin-fill align-bottom me-2 text-muted"></i>
                  Удалить
                </DropdownItem>
              </PrivateComponent>
            </DropdownMenu>
          </UncontrolledDropdown>
        );
      },
    },
  ];

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

export default ManufacturesTable;
