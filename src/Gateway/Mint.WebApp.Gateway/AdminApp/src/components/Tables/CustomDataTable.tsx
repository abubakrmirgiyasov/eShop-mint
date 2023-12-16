import React, {FC} from 'react';

type Primitive = string | number | boolean | bigint;
type Selector<T> = (row: T, rowIndex?: number) => Primitive;

interface ICustomDataTable {
    name: string[];

}

const CustomDataTable = (props: ICustomDataTable) => {
    return (
        <table className={"table table-striped table-bordered table-dark"}>
            <thead>
                <tr>
                    <th scope={"col"} style={{borderLeftWidth: "1px"}}>
                        <button className={"btn btn-transparent"}>
                            # <i className={"ri-sort-desc"}></i>
                        </button>
                    </th>
                    {props.name?.map((n, k) => (
                        <th scope={"col"}>
                            <button key={k} className={"btn btn-transparent"}>
                                {n} <i className={"ri-sort-desc"}></i>
                            </button>
                        </th>
                    ))}
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope={"row"}>1</th>
                    <td>Mark</td>
                    <td>Otto</td>
                    <td>@mdo</td>
                </tr>
            </tbody>
        </table>
    );
};

export default CustomDataTable;