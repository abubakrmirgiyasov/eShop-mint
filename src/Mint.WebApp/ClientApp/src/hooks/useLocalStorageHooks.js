import { useEffect } from "react";
import _ from "lodash";

export const useLocalStorageEffect = (callback, deps = []) => {
    if (!_.isFunction(callback))
        throw new Error("Callback in useLocalStorageEffect is not a function");

    if (!_.isArray(deps))
        throw new Error("Depends in useLocalStorageEffect is not a Array");

    const storageListener = (e) => {
        if (_.size(deps) > 0 && deps.includes(_.get(e, "key"))) {
            return callback(
                _.get(e, "key", ""),
                JSON.parse(_.get(e, "newValue", "")),
                JSON.parse(_.get(e, "oldValue", ""))
            );
        }

        if (_.isArray(deps) && _.size(deps) === 0) {
            return callback(
                _.get(e, "key", ""),
                JSON.parse(_.get(e, "newValue", "")),
                JSON.parse(_.get(e, "oldValue", ""))
            );
        }
    };

    useEffect(() => {
        window.addEventListener("storage", storageListener, false);
        return () => window.removeEventListener("storage", storageListener);
    }, []);
}

export const setLocalStorageItem = (key, value) => {
    if (typeof window !== "undefined") {
        if (key) {
            const data = window.localStorage.getItem(key);

            if (_.isNil(data)) {
                if (_.isUndefined(value)) {
                    window.localStorage.setItem(key, null);
                    return null;
                }

                window.localStorage.setItem(key, JSON.stringify(value));
            }

            window.localStorage.setItem(key, JSON.stringify(value));

            const event = new StorageEvent("storage", {
                isTrusted: true,
                bubbles: true,
                cancelable: false,
                key: key,
                oldValue: data,
                newValue: JSON.stringify(value),
            });

            window.dispatchEvent(event);
        }
        return null;
    }
    return null;
}