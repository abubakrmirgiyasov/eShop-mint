import React, { useMemo } from "react";
import DataTable from "react-data-table-component";
import { Link } from "react-router-dom";
import {
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
  UncontrolledDropdown,
} from "reactstrap";

const ProductsTable = ({ data }) => {
  const columns = useMemo(
    () => [
      {
        name: <span className={"font-weight-bold fs-13"}>Артикул</span>,
        selector: (row) => row.sku,
        sortable: true,
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Номер товара</span>,
        selector: (row) => row.gtin,
        sortable: true,
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Название</span>,
        selector: (row) => (
          <Link
            to={"/admin/products/edit/" + row.id}
            className={"text-primary text-decoration-underline"}
          >
            {row.name}
          </Link>
        ),
        sortable: true,
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Цена</span>,
        selector: (row) => row.price + " ₽",
        sortable: true,
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Дата создания</span>,
        selector: (row) => {
          const date = new Date(row.dateCreate);
          const month = date.getUTCMonth() + 1; //months from 1-12
          const day = date.getUTCDate();
          const year = date.getUTCFullYear();
          return day + " / " + month + " / " + year;
        },
        sortable: true,
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Доставка в днях</span>,
        selector: (row) => row.deliveryMinDay + "-" + row.deliveryMaxDay,
        sortable: true,
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Картинки</span>,
        selector: (row) => (
          <div className={"avatar-group"}>
            {row.photos.map((photo, key) =>
              key <= 2 ? (
                <Link to={"#"} key={key} className={"avatar-group-item"}>
                  <img
                    src={photo}
                    alt={""}
                    className={"rounded-circle avatar-xs"}
                  />
                </Link>
              ) : null
            )}
          </div>
        ),
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
                <i className={"ri-eye-fill align-bottom me-2 text-muted"}></i>{" "}
                Просмотр
              </DropdownItem>
              <DropdownItem className={"edit-item-btn"}>
                <i
                  className={"ri-pencil-fill align-bottom me-2 text-muted"}
                ></i>{" "}
                Изменить
              </DropdownItem>
              <DropdownItem className={"remove-item-btn"}>
                <i className="ri-delete-bin-fill align-bottom me-2 text-muted"></i>{" "}
                Удалить
              </DropdownItem>
            </DropdownMenu>
          </UncontrolledDropdown>
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

export default ProductsTable;
