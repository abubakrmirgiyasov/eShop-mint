import React from "react";
import { Badge, Card, CardBody, CardHeader, Col, Container, Row } from "reactstrap";
import HomeBanner from "../../components/Sliders/HomeBanner";
import { Error } from "../../components/Notification/Error";
import TopProducts from "../../components/HomeItems/TopProducts";
import TopSales from "../../components/HomeItems/TopSales";
import TopBrands from "../../components/HomeItems/TopBrands";

const Home = () => {
  return (
    <div className="page-content">
      <Container>
        <Row>
          <Col className="mb-3" xxl={12}>
            <HomeBanner />
          </Col>
        </Row>
        <TopBrands />
        <TopProducts />
        <TopSales />
      </Container>
    </div>
  );
};

export default Home;
