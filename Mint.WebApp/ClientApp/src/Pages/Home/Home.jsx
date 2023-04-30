import React from "react";
import { Col, Container, Row } from "reactstrap";
import HomeBanner from "../../components/HomeItems/HomeBanner";
import TopProducts from "../../components/HomeItems/TopProducts";
import TopSales from "../../components/HomeItems/TopSales";
import TopBrands from "../../components/HomeItems/TopBrands";
import ReviewedProducts from "../../components/HomeItems/ReviewedProducts";
import NewProducts from "../../components/HomeItems/NewProducts";

const Home = () => {
  document.title = "Интернет магазин электроники - Mint";
  return (
    <div className="page-content">
      <Container>
        <Row>
          <Col className={"mb-3"} xxl={12}>
            <HomeBanner />
          </Col>
        </Row>
        <TopBrands />
        <NewProducts />
        <TopProducts />
        <TopSales />
        {true ? <ReviewedProducts /> : null}
      </Container>
    </div>
  );
};

export default Home;
