import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Card, CardBody, CardFooter, Col, Row, TabPane } from "reactstrap";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { Error } from "../../components/Notification/Error";

const Orders = ({ userId, activeTab }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [orders, setOrders] = useState([]);

  useEffect(() => {
    if (activeTab === 3) {
      setIsLoading(true);

      fetchWrapper
        .get("api/order/getbuyerordersbyid/" + userId)
        .then((response) => {
          setIsLoading(false);
          setOrders(response);
        })
        .catch((error) => {
          setIsLoading(false);
          setError(error);
        });
    }
  }, [activeTab, userId]);

  return (
    <React.Fragment>
      {error ? <Error message={error} /> : null}
      <TabPane tabId={3}>
        <Card>
          <CardBody>
            <h2 className={"mb-3"}>Заказы</h2>
            <Row>
              <Col>
                {isLoading ? (
                  <div
                    className={
                      "d-flex justify-content-center align-items-center"
                    }
                  >
                    <div
                      className={"spinner-grow text-success"}
                      role={"status"}
                    >
                      <span className={"visually-hidden"}>Loading...</span>
                    </div>
                  </div>
                ) : (
                  orders.map((item, key) => (
                    <Card key={key}>
                      <CardBody className={"bg-light"}>
                        <h3 className={"fs-18 mb-4"}>
                          Зкакз №: #{item.orderNumber}
                        </h3>
                        <Row>
                          <Col xl={3}>
                            <h3 className={"fs-14 text-muted"}>Статус:</h3>
                          </Col>
                          <Col xl={9} className={"mb-2"}>
                            <h3 className={"fs-14"}>В обработке</h3>
                          </Col>
                          <Col xl={3} className={"mb-2"}>
                            <h3 className={"fs-14 text-muted"}>Сумма:</h3>
                          </Col>
                          <Col xl={9} className={"mb-2"}>
                            <h3 className={"fs-14"}>
                              {item.orderProducts.length ? (
                                item.orderProducts[0].sum
                              ) : (
                                <Error message={"Возникла ошибка"} />
                              )}{" "}
                              ₽
                            </h3>
                          </Col>
                          <Col xl={3} className={"mb-2"}>
                            <h3 className={"fs-14 text-muted"}>Дата заказа</h3>
                          </Col>
                          <Col xl={9}>
                            <h3 className="fs-14">{`${new Date(
                              item.dateCreate
                            ).getDay()} / ${
                              new Date(item.dateCreate).getMonth() + 1
                            } ${new Date(item.dateCreate).getFullYear()}`}</h3>
                          </Col>
                        </Row>
                      </CardBody>
                      <CardFooter className={"bg-light"}>
                        <Link
                          to={"/orders/details/" + item.id}
                          className={"btn btn-primary"}
                          color={"primary"}
                        >
                          <i className={"ri-file-list-3-line"}></i> Детали
                          заказа
                        </Link>
                      </CardFooter>
                    </Card>
                  ))
                )}
              </Col>
            </Row>
          </CardBody>
        </Card>
      </TabPane>
    </React.Fragment>
  );
};

export default Orders;
