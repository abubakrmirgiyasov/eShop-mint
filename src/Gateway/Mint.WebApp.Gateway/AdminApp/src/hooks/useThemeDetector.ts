import {FC, useEffect, useState} from 'react';

const useThemeDetector: FC = () => {
    const getMatchMedia = (): MediaQueryList => {
        return window.matchMedia("(prefers-color-scheme: dark)");
    };

    const [isDarkTheme, setIsDarkTheme] = useState<boolean>(getMatchMedia().matches);

    const mqListener = (e: MediaQueryListEvent) => {
      setIsDarkTheme(e.matches);
    };

    useEffect(() => {
        const mq = getMatchMedia();
        mq.addListener(mqListener);
        return () => mq.removeListener(mqListener);
    }, []);

    return isDarkTheme;
};

export default useThemeDetector;