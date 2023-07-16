import React, { FC, useState } from "react";
import { IUser } from "../../services/types/IUser";
import { Card, Spinner, TabPane } from "reactstrap";
import CustomDivider from "../../components/Common/CustomDivider";

interface ICustomerInfo {
  user: IUser;
  activeTab: number;
}

const CustomerInfo: FC<ICustomerInfo> = ({ user, activeTab }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);

  return (
    <React.Fragment>
      <TabPane tabId={1}>
        {isLoading ? (
          <Spinner size={"sm"} />
        ) : (
          <Card>
            <h2>Личная информация</h2>
            <CustomDivider />
          </Card>
        )}
      </TabPane>
    </React.Fragment>
  );
};

export default CustomerInfo;
