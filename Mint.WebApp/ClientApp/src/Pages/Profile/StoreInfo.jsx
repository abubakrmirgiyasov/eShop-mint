import React, { useEffect, useState } from "react";
import { Card, CardBody, Col, Row } from "reactstrap";

const StoreInfo = ({ data }) => {
  return (
    <React.Fragment>
      <Row>
        <Col lg={12}>
          {data?.Name}
          {data?.url}
          {data?.country}
          {data?.city}
          {data?.street}
          {data?.zipCode}
          {data?.addressDescription}
          {data?.isOwnStorage}
          <img src={data?.photo} />
        </Col>
      </Row>
    </React.Fragment>
  );
};

export default StoreInfo;
