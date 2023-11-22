import React, {FC} from 'react';
import {Link} from "react-router-dom";
import {useAxios} from "../../hooks/useAxios";

const Dashboard: FC = () => {

    return (
        <div className={"page-content"}>
            Dashboard
            <br />
            <Link to={"/sign-in"}>go back</Link>
        </div>
    );
};

export default Dashboard;