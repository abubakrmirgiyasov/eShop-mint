import { useSelector } from "react-redux";
import { Roles } from "../constants/Roles";

function PrivateComponent({ children }) {
    const user = useSelector(user => user.Signin.user);

    if (children instanceof Array) {
        return children.map((c) =>
            c.props
                ? c.props.roles
                    ? Roles.hasRole(c.props.roles, user.roles)
                        ? c
                        : null
                    : c
                : c
        );
    } else {
        return children.props ? (
            children.props.roles ? (
                Roles.hasRole(children.props.roles, user.roles) ? (
                    children
                ) : (
                    <></>
                )
            ) : (
                children
            )
        ) : (
            children
        );
    }
}

export default PrivateComponent;