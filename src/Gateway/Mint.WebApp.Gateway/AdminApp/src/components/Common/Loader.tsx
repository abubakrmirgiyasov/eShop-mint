import React, {FC} from 'react';
import {Colors} from "../../constants/commonList";
import {Spinner} from "reactstrap";

interface ILoader {
    color: Colors;
    isCenter: boolean;
}

const Loader: FC<ILoader> = ({ color, isCenter }) => {
    return (
        <div
            className={
                isCenter ? "d-flex align-items-center justify-content-center" : ""
            }
        >
            <Spinner size={"sm"} color={Colors[color]}>
                Loading...
            </Spinner>
        </div>
    );
};

export default Loader;