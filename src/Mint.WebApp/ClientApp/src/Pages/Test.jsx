import React, { useEffect, useState } from 'react';
import { Button } from 'bootstrap';
import { fetchWrapper } from '../helpers/fetchWrapper';

const Test = () => {
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {

        fetchWrapper.post("").then((response) =>{
            console.log(response);
        }).catch((error) => {
            console.error(error);
        });

    }, [   ]);

    return (
        <div className={"page-content"}>
            <Button color={"primary"}>
                Отправить
            </Button>
        </div>
    );
}

export default Test;
