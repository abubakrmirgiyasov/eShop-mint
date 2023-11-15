import {ReactElement} from "react";

export interface IAllRoute {
    path: string;
    component: ReactElement;
    exact: boolean;
}