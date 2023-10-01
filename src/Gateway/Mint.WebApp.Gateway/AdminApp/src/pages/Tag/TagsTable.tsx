import React, { FC, useMemo, useState } from "react";
import { PrivateComponent } from "../../../helpers/privateComponent";
import { Roles } from "../../../constants/roles";
import {
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
  UncontrolledDropdown,
} from "reactstrap";
import { Link } from "react-router-dom";
import DataTable from "react-data-table-component";
import { ITag } from "../../../services/admin/ITag";

interface ITagsTable {
  tags: ITag[];
  handleChange: (tag: ITag) => void;
  handleDelete: (id: string) => void;
}

const TagsTable: FC<ITagsTable> = ({ tags, handleChange, handleDelete }) => {
  const [isOmits, setIsOmits] = useState<boolean[2]>([]);

  const columns = useMemo(
    () => [
      {
        name: "Uid",
        selector: (row) => row.value,
        sortable: true,
      },
      {
        name: "Название",
        selector: (row) => row.label,
        sortable: true,
      },
      {
        name: "Перевод",
        selector: (row) => row.translate,
        sortable: true,
        omit: isOmits[0],
      },
      {
        name: "Действие",
        cell: (row) => (
          <UncontrolledDropdown>
            <DropdownToggle
              className={"btn btn-sort-secondary btn-sm"}
              tag={"button"}
            >
              <i className={"ri-more-fill align-middle"}></i>
            </DropdownToggle>
            <DropdownMenu className={"dropdown-menu-end"}>
              <PrivateComponent>
                <DropdownItem
                  className={"edit-item-btn"}
                  roles={[Roles.Admin]}
                  onClick={() => handleChange(row)}
                >
                  <i
                    className={"ri-pencil-fill align-bottom me-2 text-muted"}
                  ></i>
                  Редактировать
                </DropdownItem>
                <DropdownItem
                  className={"edit-item-btn"}
                  roles={[Roles.Admin]}
                  onClick={() => {
                    handleDelete(row.value);
                  }}
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
        omit: isOmits[1],
      },
    ],
    []
  );

  return (
    <DataTable
      columns={columns}
      data={tags || []}
      highlightOnHover={true}
      defaultSortAsc={true}
      pagination={true}
    />
  );
};

export default TagsTable;
