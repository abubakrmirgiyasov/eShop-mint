import React from "react";
import {ILocalUser} from "../types/Authentication/ILocalUser";

interface IUseProfile {
    user?: ILocalUser | null;
    token?: string | null;
    isLoading: boolean;
}

const isLoggedInUser: () => ILocalUser | null = () => {
    const json = localStorage.getItem("c_user");
    if (json) {
        const user: ILocalUser = JSON.parse(json);
        return user;
    }
    return null;
}

export const useProfile = (): IUseProfile => {
    const userProfileSession = isLoggedInUser();
    const token = userProfileSession && userProfileSession.token;

    const [isLoading, setIsLoading] = React.useState<boolean>(!!userProfileSession);
    const [user, setUser] = React.useState<ILocalUser | null>(userProfileSession);

    React.useEffect(() => {
        const userProfileSession = isLoggedInUser();
        const token = userProfileSession && userProfileSession.token;

        setUser(userProfileSession);
        setIsLoading(!token);
    }, []);

    return { user, token, isLoading };
};