import React from "react";
import { Badge, Card, CardBody, CardHeader, Col, Row } from "reactstrap";

const NewProducts = () => {
  return (
    <React.Fragment>
      <Card>
        <CardHeader>
          <Badge color={"info"} className={"bg-primary fs-14"}>
            <i className={"mdi mdi-circle-medium fs-14"}></i> Новинки
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

export default NewProducts;
