import React, { useEffect, useState } from "react";
import { Card, CardBody, TabPane } from "reactstrap";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import OpenStore from "./OpenStore";
import StoreInfo from "./StoreInfo";

const Store = ({ userId }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setErorr] = useState(null);
  const [data, setData] = useState(null);

  useEffect(() => {
    setIsLoading(true);

    fetchWrapper
      .get("api/store/getmystore/" + userId)
      .then((response) => {
        setData(response);
        setIsLoading(false);
      })
      .catch((error) => {
        setErorr(error);
        setIsLoading(false);
      });
  }, []);

  function handleNewData(newData) {
    setData([...data, newData]);
  }

  return (
    <React.Fragment>
      <TabPane tabId={5}>
        <Card>
          <CardBody>
            <h2 className={"mb-3"}>Ваш магазин</h2>
            {!data ? (
              <OpenStore userId={userId} newData={handleNewData} />
            ) : (
              <StoreInfo data={data} />
            )}
          </CardBody>
        </Card>
      </TabPane>
    </React.Fragment>
  );
};

export default Store;
