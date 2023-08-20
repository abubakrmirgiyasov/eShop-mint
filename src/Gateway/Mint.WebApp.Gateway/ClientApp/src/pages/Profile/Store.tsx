import React, { FC, useState } from "react";
import { Card, CardBody, Spinner, TabPane } from "reactstrap";
import CustomDivider from "../../components/Common/CustomDivider";
import OpenStore from "./OpenStore";
import { IUserStore } from "../../services/types/IUser";

interface IStore {
  userId: string;
  activeTab: number;
}

const Store: FC<IStore> = ({ userId, activeTab }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const handleNewStore = (store: IUserStore) => {};

  return (
    <React.Fragment>
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
              <CustomDivider />
              <OpenStore handleNewStore={handleNewStore} />
            </CardBody>
          </Card>
        )}
      </TabPane>
    </React.Fragment>
  );
};

export default Store;
