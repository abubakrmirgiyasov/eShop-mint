import React, {FC, useMemo} from 'react';
import {Link} from "react-router-dom";
import CustomDataTable from "../../components/Tables/CustomDataTable";

const Dashboard: FC = () => {

    const columns = useMemo(() => [
        {
            name: "ID",
        },
        {
            name: "Название",
        },
        {
            name: "Перевод",
        },
    ], []);

    return (
        <div className={"page-content"}>
            Dashboard
            <br/>
            <Link to={"/sign-in"}>go back</Link>

            <CustomDataTable data={[]} name={columns} />
        </div>
    );
};

export default Dashboard;