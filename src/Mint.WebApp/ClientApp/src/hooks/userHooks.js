import { useEffect, useState } from "react";

const getLoggedinUser = () => {
    const user = localStorage.getItem("auth_user");
    return user ? JSON.parse(user) : null;     
}

const useProfile = () => {
    const userProfileSession = getLoggedinUser();
    const token = userProfileSession && userProfileSession["accessToken"];
    
    const [isLoading, setIsLoading] = useState(userProfileSession ? false : true);
    const [userProfile, setUserProfile] = useState(userProfileSession ? userProfileSession : null);

    useEffect(() => {
        const userProfileSession = getLoggedinUser();
        const token = userProfileSession && userProfileSession["accessToken"];

        setUserProfile(userProfileSession ? userProfileSession : null);
        setIsLoading(token ? false : true);
    }, []);
    return { userProfile, isLoading, token };
}

export { useProfile };