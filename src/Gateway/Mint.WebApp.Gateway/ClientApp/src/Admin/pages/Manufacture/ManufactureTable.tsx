import React, {FC, useMemo, useState} from "react";
import {
    DropdownItem,
    DropdownMenu,
    DropdownToggle,
    UncontrolledDropdown,
} from "reactstrap";
import {Roles} from "../../../constants/roles";
import {Link} from "react-router-dom";
import {PrivateComponent} from "../../../helpers/privateComponent";
import DataTable from "react-data-table-component";

interface IManufactureTable {
    handleDelete: (id: string) => void;
}

const ManufactureTable: FC<IManufactureTable> = ({handleDelete}) => {
    const [isOmits, setIsOmits] = useState<boolean[6]>([]);

    const columns = useMemo(
        () => [
            {
                name: "Сортировать по",
                selector: (row) => row.displayOrder,
                sortable: true,
            },
            {
                name: "Название",
                selector: (row) => row.name,
                sortable: true,
            },
            {
                name: "Страна",
                selector: (row) => row.country,
                sortable: true,
                omit: isOmits[0],
            },
            {
                name: "Сайт",
                selector: (row) => row.website,
                sortable: true,
                omit: isOmits[1],
            },
            {
                name: "Email",
                selector: (row) => row.email,
                sortable: true,
                omit: isOmits[2],
            },
            {
                name: "Телефон",
                selector: (row) => row.phone,
                sortable: true,
                omit: isOmits[3],
            },
            {
                name: "Полный адрес",
                selector: (row) => row.fullAddress,
                sortable: true,
                omit: isOmits[4],
            },
            {
                name: "Картинка",
                cell: (row) => (
                    <img
                        src={row.photo}
                        alt={row.name}
                        className={"rounded"}
                        width={50}
                        height={50}
                    />
                ),
                omit: isOmits[5],
            },
            {
                name: "Описание",
                selector: (row) => row.description,
                sortable: true,
                omit: isOmits[6],
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
                            <DropdownItem href={"/brands"}>
                                <i className={"ri-eye-fill align-bottom me-2 text-muted"}></i>
                                Все производители
                            </DropdownItem>
                            <PrivateComponent>
                                <DropdownItem className={"edit-item-btn"} roles={[Roles.Admin]}>
                                    <i
                                        className={"ri-pencil-fill align-bottom me-2 text-muted"}
                                    ></i>
                                    <Link to={`/admin/categories/edit/${row.id}`}>
                                        Редактировать
                                    </Link>
                                </DropdownItem>
                                <DropdownItem
                                    className={"edit-item-btn"}
                                    roles={[Roles.Admin]}
                                    onClick={() => handleDelete(row.id)}
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
            },
        ],
        []
    );

    return (
        <DataTable
            columns={columns}
            data={[]}
            highlightOnHover={true}
            defaultSortAsc={true}
            pagination={true}
            defaultSortField={"displayOrder"}
        />
    );
};

export default ManufactureTable;
