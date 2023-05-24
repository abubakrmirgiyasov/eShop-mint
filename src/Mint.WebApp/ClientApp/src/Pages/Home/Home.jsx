import React, { useEffect, useMemo, useState } from "react";
import { Col, Container, Row } from "reactstrap";
import HomeBanner from "../../components/HomeItems/HomeBanner";
import TopProducts from "../../components/HomeItems/TopProducts";
import TopSales from "../../components/HomeItems/TopSales";
import TopBrands from "../../components/HomeItems/TopBrands";
import NewProducts from "../../components/HomeItems/NewProducts";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { Error } from "../../components/Notification/Error";

// import ReviewedProducts from "../../components/HomeItems/ReviewedProducts";

const Home = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [topDiscountedProducts, setDiscountedProducts] = useState([]);
  const [topProducts, setTopProducts] = useState([]);
  const [topSaledProducts, setTopSaledProducts] = useState([]);
  const [topsellerswithproducts, setTopsellerswithproducts] = useState([]);
  const [newProducts, setNewProducts] = useState([]);

  useEffect(() => {
    setIsLoading(true);

    Promise.all([
      fetchWrapper.get("api/product/gettopdiscountedproducts/6"),
      fetchWrapper.get("api/product/gettopproducts/6"),
      fetchWrapper.get("api/product/gettopsaledproducts/6"),
      fetchWrapper.get("api/product/gettopnewproducts/6"),
      // fetchWrapper.get("api/product/gettopsellerswithproducts/6"),
    ])
      .then((response) => {
        const [
          topDiscountedProducts,
          topProducts,
          topSales,
          newProducts,
        ] = response;
        setIsLoading(false);
        setDiscountedProducts(topDiscountedProducts);
        setTopProducts(topProducts);
        setTopSaledProducts(topSales);
        setNewProducts(newProducts);
      })
      .catch((error) => {
        setError(error);
        setIsLoading(false);
      });
  }, []);

  document.title = "Интернет магазин электроники - Mint";
  return (
    <div className="page-content">
    {error ? <Error message={error} /> : null}
      <Container>
        <Row>
          <Col className={"mb-3"} xxl={12}>
            <HomeBanner />
          </Col>
        </Row>
        <TopBrands />
        <NewProducts isLoading={isLoading} products={newProducts} />
        <TopProducts products={topProducts} isLoading={isLoading} />
        <TopSales products={topDiscountedProducts} isLoading={isLoading} />
        {/*{true ? <ReviewedProducts /> : null}*/}
      </Container>
    </div>
  );
};

export default Home;
