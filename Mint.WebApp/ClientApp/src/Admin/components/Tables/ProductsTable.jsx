import React from "react";
import DataTable from "react-data-table-component";

const ProductsTable = () => {
  const columns = [
    {
      name: <span className={"font-weight-bold fs-13"}>item1</span>,
      selector: (row) => row.item1,
      sortable: true,
    },
    {
      name: <span className={"font-weight-bold fs-13"}>item2</span>,
      selector: (row) => row.item1,
      sortable: true,
    },
    {
      name: <span className={"font-weight-bold fs-13"}>item3</span>,
      selector: (row) => row.item1,
      sortable: true,
    },
    {
      name: <span className={"font-weight-bold fs-13"}>item4</span>,
      selector: (row) => row.item1,
      sortable: true,
    },
  ];

  return (
    <DataTable
      columns={columns}
      data={[]}
      pagination={true}
      highlightOnHover={true}
    />
  );
};

export default ProductsTable;
