import React from "react";
import { Button, Card, CardBody, CardColumns, CardGroup, Col, Container, Row } from "reactstrap";

const OrderDetails = () => {
  return (
    <div className="page-content">
      <Container>
        <Row>
          <Col xxl={12}>
            <Row>
              <Col lg={6}>
                <h2>Номер заказа #1</h2>
              </Col>
              <Col
                lg={6}
                className="d-flex justify-content-end align-item-center mb-3"
              >
                <Button
                  type="button"
                  color="outline-primary"
                  className="btn btn-outline-primary me-2"
                >
                  <i className="ri-printer-line"></i> Распечатать
                </Button>
                <Button
                  type="button"
                  color="primary"
                  className="btn btn-primary"
                >
                  <i className="ri-file-pdf-line"></i> Скачать как PDF
                </Button>
              </Col>
              <Col lg={6} className="mb-3">
                <Row>
                  <Col lg={3}>
                    <h3 className="text-muted fs-14">Дата заказа</h3>
                    <h3 className="fs-14 fw-semibold">15.01.2023</h3>
                  </Col>
                  <Col lg={3}>
                    <h3 className="text-muted fs-14">Номер заказа</h3>
                    <h3 className="fs-14 fw-semibold">1234</h3>
                  </Col>
                  <Col lg={3}>
                    <h3 className="text-muted fs-14">Статус заказа</h3>
                    <h3 className="fs-14 fw-semibold">В ожидании</h3>
                  </Col>
                  <Col lg={3}>
                    <h3 className="text-muted fs-14">Стоимость заказа</h3>
                    <h3 className="fs-14 fw-semibold text-primary">499$</h3>
                  </Col>
                </Row>
              </Col>
              <Col xxl={12}>
                <Card>
                    <CardBody>
                        <div className="d-flex justify-content-between">
                            <div>
                                
                            </div>
                        </div>
                    </CardBody>
                </Card>
              </Col>
            </Row>
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default OrderDetails;
