import React, { useEffect, useState } from "react";
import { Card, CardBody, Spinner, TabPane } from "reactstrap";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import OpenStore from "./OpenStore";
import StoreInfo from "./StoreInfo";
import { Error } from "../../components/Notification/Error";

const Store = ({ userId }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setErorr] = useState(null);
  const [data, setData] = useState(null);
  const [newStore, setNewStore] = useState(null);

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
  }, [userId]);

  function handleNewData(newData) {
    setNewStore(newData);
  }

  return (
    <React.Fragment>
      {error ? <Error message={error} /> : null}
      <TabPane tabId={5}>
        {isLoading ? (
          <div className={"d-flex justify-content-center align-items-center"}>
            <Spinner color={"success"} size={"sm"}>
              Loading...
            </Spinner>
          </div>
        ) : (
          <Card>
            <CardBody>
              <h2 className={"mb-3"}>Ваш магазин</h2>
              {!newStore ? (
                <OpenStore userId={userId} newData={handleNewData} />
              ) : (
                <StoreInfo data={newStore} />
              )}
            </CardBody>
          </Card>
        )}
      </TabPane>
    </React.Fragment>
  );
};

export default Store;
