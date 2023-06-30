import React, { useEffect, useState } from "react";
import { Card, CardBody, Spinner, TabPane } from "reactstrap";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import OpenStore from "./OpenStore";
import StoreInfo from "./StoreInfo";
import { Error } from "../../components/Notification/Error";

const Store = ({ userId }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
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
        setError(error);
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
              <h2>Мои магазины</h2>
              <div
                style={{
                  width: "100%",
                  height: "1px",
                  background: "rgb(210 210 210)",
                }}
                className={"mb-3"}
              ></div>
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
