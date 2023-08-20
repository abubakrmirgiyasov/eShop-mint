import { FC, ReactNode } from "react";
import { useSelector } from "react-redux";
import { IUser } from "../services/types/IUser";
import { Roles } from "../constants/roles";

export const PrivateComponent: FC<ReactNode> = ({ children }) => {
  const user: IUser = useSelector((state) => state.Auth.user);

  if (children instanceof Array) {
    return children.map((child) =>
      child.props
        ? child.props.roles
          ? Roles.hasRole(child.props.roles, user.roles)
            ? child
            : null
          : child
        : child
    );
  } else {
    return children.props
      ? children.props.roles
        ? Roles.hasRole(children.props.roles, user.roles)
          ? children
          : null // <></>
        : children
      : children;
  }
};
