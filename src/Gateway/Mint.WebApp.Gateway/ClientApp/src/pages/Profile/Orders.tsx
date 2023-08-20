import React, { FC, useState } from "react";
import { IUser, IUserOrder } from "../../services/types/IUser";
import { Error } from "../../components/Notifications/Error";
import { Card, CardBody, Col, Row, Spinner, TabPane } from "reactstrap";
import CustomDivider from "../../components/Common/CustomDivider";
import { Link } from "react-router-dom";

interface IOrders {
  user: IUser;
  activeTab: number;
}

const Orders: FC<IOrders> = ({ user, activeTab }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");
  const [orders, setOrders] = useState<IUserOrder[]>([]);

  return (
    <React.Fragment>
      {error && <Error message={error} />}
      <TabPane tabId={3}>
        {isLoading ? (
          <div className={"d-flex justify-content-center align-items-center"}>
            <Spinner size={"sm"} color={"success"}>
              Loading...
            </Spinner>
          </div>
        ) : (
          <Card>
            <CardBody>
              <h2>Мои заказы</h2>
              <CustomDivider />
              <Row>
                <Col>
                  <div
                    className={
                      "d-flex justify-content-start align-items-center"
                    }
                  >
                    <Link to={"/categories"} className={"btn btn-success"}>
                      <i className={"ri-shopping-cart-line"}></i> К покупкам
                    </Link>
                  </div>
                  {orders.length === 0 && (
                    <div>
                      <h3 className={"mt-3 text-center fs-18 text-muted"}>
                        У вас еще нет заказа
                      </h3>
                      <div
                        className={
                          "d-flex justify-content-center align-items-center"
                        }
                      >
                        <lord-icon
                          src="https://cdn.lordicon.com/nkmsrxys.json"
                          trigger={"loop"}
                          delay={"2000"}
                          colors={"primary:#121331,secondary:#08a88a"}
                          style={{ width: "250px", height: "250px" }}
                        ></lord-icon>
                      </div>
                    </div>
                  )}
                  {orders.map((order, key) => (
                    <Card key={key}>
                      <CardBody className={"bg-light"}>
                        <h3 className={"fs-18 mb-4"}>
                          Заказ: #{order.orderNumber}
                        </h3>
                      </CardBody>
                    </Card>
                  ))}
                </Col>
              </Row>
            </CardBody>
          </Card>
        )}
      </TabPane>
    </React.Fragment>
  );
};

export default Orders;
