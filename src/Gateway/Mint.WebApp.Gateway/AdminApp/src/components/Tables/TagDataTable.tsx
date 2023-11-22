import React, {FC, useMemo} from 'react';
import DataTable from "react-data-table-component";
import {ITag} from "../../types/Tags/ITag";
import {DropdownItem, DropdownMenu, DropdownToggle, UncontrolledDropdown} from "reactstrap";

interface ITagDataTable {
    omit: boolean;
    data: ITag[] | void;
    onChangeItem: (tag: ITag) => void;
    onRemoveItem: (id: string) => void;
}

export const TagDataTable: FC<ITagDataTable> = ({ omit, data, onChangeItem, onRemoveItem}) => {
    const columns = useMemo(() => [
        {
            name: "ID",
            selector: row => row.value,
            sortable: false,
        },
        {
            name: "Название",
            selector: row => row.label,
            sortable: true,
        },
        {
            name: "Перевод",
            selector: row => row.translate,
            sortable: true,
            omit: omit,
        },
        {
            name: "",
            sortable: false,
            cell: (row) => {
                return (
                    <UncontrolledDropdown className={"dropdown d-inline-block"}>
                        <DropdownToggle className={"btn btn-soft-secondary btn-sm"} tag={"button"}>
                            <i className={"ri-more-fill align-middle"}></i>
                        </DropdownToggle>
                        <DropdownMenu className={"dropdown-menu-end"}>
                            <DropdownItem
                                className={"edit-item-btn d-flex align-items-center"}
                                // roles={[Roles.Admin]}
                                onClick={() => onChangeItem(row)}
                            >
                                <i className={"ri-pencil-fill align-bottom me-2 text-muted"}></i>Изменить
                            </DropdownItem>
                            <DropdownItem
                                className={"remove-item-btn d-flex align-items-center"}
                                // roles={[Roles.Admin]}
                                onClick={() => onRemoveItem(row.value)}
                            >
                                <i className={"ri-delete-bin-fill align-bottom me-2 text-muted"}></i>Удалить
                            </DropdownItem>
                        </DropdownMenu>
                    </UncontrolledDropdown>
                );
            }
        }
    ], [omit]);

    return (
        <React.Fragment>
            <DataTable
                columns={columns}
                data={data}
                pagination={true}
            />
        </React.Fragment>
    );
};
