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
            <h2>Мои заказы</h2>
            <div
              style={{
                width: "100%",
                height: "1px",
                background: "rgb(210 210 210)",
              }}
              className={"mb-3"}
            ></div>
            <Row>
              <Col>
                <div
                  className={"d-flex justify-content-start align-items-center"}
                >
                  <Link to={"/categories"} className={"btn btn-success"}>
                    <i className={"ri-shopping-cart-line"}></i> К покупкам
                  </Link>
                </div>
                {isLoading ? (
                  <div
                    className={
                      "d-flex justify-content-center align-items-center"
                    }
                  >
                    <div className={"spinner text-success"} role={"status"}>
                      <span className={"visually-hidden"}>Loading...</span>
                    </div>
                  </div>
                ) : orders.length ? (
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
                                item.orderProducts.at(0).sum
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
                            } / ${new Date(
                              item.dateCreate
                            ).getFullYear()}`}</h3>
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
                ) : (
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
              </Col>
            </Row>
          </CardBody>
        </Card>
      </TabPane>
    </React.Fragment>
  );
};

export default Orders;
