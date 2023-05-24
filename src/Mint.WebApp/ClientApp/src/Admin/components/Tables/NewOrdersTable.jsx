import React, { useMemo, useState } from "react";
import DataTable from "react-data-table-component";
import { Link } from "react-router-dom";

const NewOrdersTable = ({ orders }) => {
  const columns = useMemo(
    () => [
      {
        name: <span className="font-weight-bold fs-13">Продукт</span>,
        selector: (row) => (
          <Link to="/">{row.orderProducts[0].product.name}</Link>
        ),
        sortable: true,
      },
      {
        name: <span className="font-weight-bold fs-13">Кол-во X Цена</span>,
        selector: (row) =>
          `${row.orderProducts[0].quantity} X ${row.orderProducts[0].price} ₽`,
        sortable: true,
      },
      {
        name: <span className="font-weight-bold fs-13">Сумма</span>,
        selector: (row) => `${row.orderProducts[0].sum} ₽`,
        sortable: true,
      },
      {
        name: <span className="font-weight-bold fs-13">Дата</span>,
        selector: (row) =>
          `${new Date(row.dateCreate).getDay()} / ${
            new Date(row.dateCreate).getMonth() + 1
          } ${new Date(row.dateCreate).getFullYear()}`,
        sortable: true,
      },
      // {
      //   name: <span className="font-weight-bold fs-13">Действие</span>,
      //   selector: (row) => row.date,
      //   sortable: true,
      // },
    ],
    [orders]
  );

  return (
    <DataTable
      columns={columns}
      data={orders}
      pagination={true}
      highlightOnHover={true}
    />
  );
};

export default NewOrdersTable;
