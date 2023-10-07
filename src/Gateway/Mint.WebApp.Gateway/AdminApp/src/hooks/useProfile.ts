import {ILocalUser} from "../types/Authentication/ILocalUser";
import {useEffect, useState} from "react";

const isLoggedInUser: () => ILocalUser | null = () => {
    const json = localStorage.getItem("c_user");
    if (json) {
        const user: ILocalUser = JSON.parse(json);
        return user;
    }
    return null;
}

export const useProfile = () => {
    const userProfileSession = isLoggedInUser();
    const token = userProfileSession && userProfileSession.token;

    const [isLoading, setIsLoading] = useState<boolean>(!!userProfileSession);
    const [user, setUser] = useState<ILocalUser>(userProfileSession);

    useEffect(() => {
        const userProfileSession = isLoggedInUser();
        const token = userProfileSession && userProfileSession.token;

        setUser(userProfileSession);
        setIsLoading(!!token);
    }, []);

    return { user, token, isLoading };
};