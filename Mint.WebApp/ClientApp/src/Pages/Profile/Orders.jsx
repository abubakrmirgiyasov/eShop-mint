import React, { useState } from "react";
import { Link } from "react-router-dom";
import {
  Button,
  Card,
  CardBody,
  CardFooter,
  Col,
  Row,
  TabPane,
} from "reactstrap";

const Orders = ({ userId }) => {
  return (
    <React.Fragment>
      <TabPane tabId={3}>
        <Card>
          <CardBody>
            <h2 className={"mb-3"}>Заказы</h2>
            <Row>
              <Col>
                <Card>
                  <CardBody className="bg-light">
                    <h3 className="fs-18 mb-4">Зкакз №: #1</h3>
                    <Row>
                      <Col xl={3}>
                        <h3 className="fs-14 text-muted">Статус:</h3>
                      </Col>
                      <Col xl={9} className="mb-2">
                        <h3 className="fs-14">В обработке</h3>
                      </Col>
                      <Col xl={3} className="mb-2">
                        <h3 className="fs-14 text-muted">Сумма:</h3>
                      </Col>
                      <Col xl={9} className="mb-2">
                        <h3 className="fs-14">1999$</h3>
                      </Col>
                      <Col xl={3} className="mb-2">
                        <h3 className="fs-14 text-muted">Дата заказа</h3>
                      </Col>
                      <Col xl={9}>
                        <h3 className="fs-14">{"2023-01-05"}</h3>
                      </Col>
                    </Row>
                  </CardBody>
                  <CardFooter className="bg-light">
                    <Link
                      to="/orders/details/3"
                      className="btn btn-primary"
                      color="primary"
                    >
                      <i className="ri-file-list-3-line"></i> Детали заказа
                    </Link>
                  </CardFooter>
                </Card>
              </Col>
            </Row>
          </CardBody>
        </Card>
      </TabPane>
    </React.Fragment>
  );
};

export default Orders;
