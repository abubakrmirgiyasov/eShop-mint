import React from "react";
import { Badge, Card, CardBody, CardHeader, Col, Container, Row } from "reactstrap";
import HomeBanner from "../../components/Sliders/HomeBanner";
import { Error } from "../../components/Notification/Error";
import TopProducts from "../../components/HomeItems/TopProducts";

const Home = () => {
  return (
    <div className="page-content">
      <Container>
        <Row>
          <Col className="mb-3" xxl={12}>
            <HomeBanner />
          </Col>
        </Row>
        <TopProducts />
      </Container>
    </div>
  );
};

export default Home;
