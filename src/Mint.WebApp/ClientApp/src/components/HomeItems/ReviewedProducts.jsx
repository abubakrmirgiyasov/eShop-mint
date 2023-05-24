import React from "react";
import { Badge, Card, CardBody, CardHeader, Col, Row } from "reactstrap";

const ReviewedProducts = () => {
  return (
    <React.Fragment>
      <Card>
        <CardHeader>
          <Badge color={"warning"} className={"bg-primary fs-14"}>
            <i className={"mdi mdi-circle-medium fs-14"}></i> Недавные продукты
          </Badge>
        </CardHeader>
        <CardBody>
          <Row>
            <Col></Col>
          </Row>
        </CardBody>
      </Card>
    </React.Fragment>
  );
};

export default ReviewedProducts;
