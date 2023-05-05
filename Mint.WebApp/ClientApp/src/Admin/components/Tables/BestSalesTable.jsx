import React, { useMemo } from "react";
import DataTable from "react-data-table-component";
import { Link } from "react-router-dom";

const BestSalesTable = () => {
  const data = [
    { name: "test1", count: 3, price: 333 },
    { name: "test2", count: 4, price: 139 },
    { name: "test3", count: 1, price: 229 },
  ];

  const columns = useMemo(
    () => [
      {
        name: <span className={"font-weight-bold fs-13"}>Продукт</span>,
        selector: (row) => {
          return <Link to="/">{row.name}</Link>;
        },
        sortable: true,
      },
      {
        name: <span className="font-weight-bold fs-13">Кол-во X Цена</span>,
        selector: (row) => `${row.count} X ${row.price}₽`,
        sortable: true,
      },
      {
        name: <span className={"font-weight-bold fs-13"}>Сумма</span>,
        selector: (row) => row.count * row.price,
        sortable: true,
      },
    ],
    []
  );

  return (
    <DataTable
      columns={columns}
      data={data}
      pagination={true}
      highlightOnHover={true}
    />
  );
};

export default BestSalesTable;
