import React, { useEffect, useState } from "react";
import { Button, Card, CardBody, Col, Container, Input, Row } from "reactstrap";
import Breadcrumb from "../../components/Breadcrumb/Breadcrumb";
import { useParams } from "react-router-dom";
import { Error } from "../../components/Notification/Error";
import {
  ProductCardRow,
  ProductCardTable,
} from "../../components/Products/ProductCard";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { ProductSort } from "../../components/Sort/ProductSort";

const SingleCategory = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [data, setData] = useState([]);
  const [isRow, setIsRow] = useState(false);

  const params = useParams();

  useEffect(() => {
    setIsLoading(true);

    fetchWrapper
      .get("api/product/getproductsbycategory/" + params.name)
      .then((response) => {
        setData(response);
        setIsLoading(false);
      })
      .catch((error) => {
        setError(error);
        setIsLoading(false);
      });
  }, [params]);

  const handleTableClick = () => {
    setIsRow(false);
  };

  const handleRowClick = () => {
    setIsRow(true);
  };

  console.log(data);

  return (
    <div className={"page-content"}>
      <Breadcrumb
        title={data.length ? data[0].category : null}
        pageTitle={"Категории"}
        link={"/categories"}
      />
      {error ? <Error message={error} /> : null}
      <Container fluid={true}>
        {isLoading ? (
          <div className={"d-flex justify-content-center align-items-center"}>
            <div className={"spinner-grow text-success"} role={"status"}>
              <span className={"visually-hidden"}>Loading...</span>
            </div>
          </div>
        ) : (
          <Row>
            <Col lg={3}>
              <Card>
                <CardBody>
                  <div className={"app-search d-none d-md-block mt-0 mb-0 p-0"}>
                    <div className={"position-relative p-0"}>
                      <Input
                        type={"text"}
                        className={"form-control mt-0 mb-0"}
                        placeholder={"Поиск..."}
                        defaultValue={""}
                        // onChange={() => {}}
                      />
                      <span
                        className={"mdi mdi-magnify search-widget-icon"}
                      ></span>
                      <span
                        className={
                          "mdi mdi-close-circle search-widget-icon search-widget-icon-close d-none"
                        }
                        id={"search-close-options"}
                      ></span>
                    </div>
                  </div>
                </CardBody>
              </Card>
            </Col>
            <Col lg={9}>
              <Card>
                <CardBody>
                  <div
                    className={
                      "d-flex justify-content-between align-items-center"
                    }
                  >
                    <div>
                      <h3 className={"fs-16"}>Attirbutes</h3>
                    </div>
                    <div className={""}>
                      <Button
                        color={"light"}
                        className={isRow ? "fs-16 me-2 active" : "fs-16 me-2"}
                        onClick={handleRowClick}
                      >
                        <i className={"ri-layout-top-fill"}></i>
                      </Button>
                      <Button
                        color={"light"}
                        className={!isRow ? "fs-16 active" : "fs-16"}
                        onClick={handleTableClick}
                      >
                        <i className={"ri-grid-fill"}></i>
                      </Button>
                    </div>
                  </div>
                </CardBody>
              </Card>
            </Col>
            <Col lg={3}>
              <Card>
                <CardBody>
                  <ProductSort />
                </CardBody>
              </Card>
            </Col>
            <Col lg={9}>
              {data.length ? (
                isRow ? (
                  data?.map((item, key) => (
                    <ProductCardRow product={item} key={key} />
                  ))
                ) : (
                  <Row>
                    {data?.map((item, key) => (
                      <Col md={12} lg={4} className={"mb-4 mb-lg-0"}>
                        <ProductCardTable product={item} key={key} />
                      </Col>
                    ))}
                  </Row>
                )
              ) : (
                <Card>
                  <CardBody>
                    <h3>Упс, товаров пока нету</h3>
                  </CardBody>
                </Card>
              )}
            </Col>
          </Row>
        )}
      </Container>
    </div>
  );
};

export default SingleCategory;
