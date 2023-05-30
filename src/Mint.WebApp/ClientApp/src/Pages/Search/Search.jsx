import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import Breadcrumb from "../../components/Breadcrumb/Breadcrumb";
import { Error } from "../../components/Notification/Error";
import {
  Button,
  Card,
  CardBody,
  Col,
  Container,
  Input,
  Row,
  Spinner,
} from "reactstrap";
import { ProductSort } from "../../components/Sort/ProductSort";
import {
  ProductCardRow,
  ProductCardTable,
} from "../../components/Products/ProductCard";

const Search = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [data, setData] = useState([]);
  const [isRow, setIsRow] = useState(false);
  const [searchParam] = useState(["name", "fullDescription"]);
  const [dataForSearch, setDataForSearch] = useState([]);

  const params = useParams();

  useEffect(() => {
    setIsLoading(true);

    fetchWrapper
      .get("api/common/search/" + params.query)
      .then((response) => {
        setData(response);
        setDataForSearch(response);
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

  const handleFilteredData = (newData) => {
    setDataForSearch(newData);
  };

  const handleSearch = (e) => {
    if (e.target.value !== "") {
      const newData = dataForSearch.filter((item) => {
        return searchParam.some((newItem) => {
          return (
            item[newItem]
              .toString()
              .toLowerCase()
              .indexOf(e.target.value.toLowerCase()) > -1
          );
        });
      });
      setDataForSearch(newData);
    } else {
      setDataForSearch(data);
    }
  };

  document.title = "Поиск - Mint";
  return (
    <div className={"page-content"}>
      <Breadcrumb title={"Поиск"} pageTitle={"Категории"} link={"/categories"} />
      {error ? <Error message={error} /> : null}
      <Container fluid={true}>
        {isLoading ? (
          <div className={"d-flex justify-content-center align-items-center"}>
            <Spinner color={"success"} size={"sm"}>
              Loading...
            </Spinner>
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
                        onChange={handleSearch}
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
                  <ProductSort
                    data={data}
                    dataForSearch={dataForSearch}
                    filteredData={handleFilteredData}
                  />
                </CardBody>
              </Card>
            </Col>
            <Col lg={9}>
              {dataForSearch.length ? (
                isRow ? (
                  dataForSearch?.map((item, key) => (
                    <ProductCardRow product={item} key={key} />
                  ))
                ) : (
                  <Row>
                    {dataForSearch?.map((item, key) => (
                      <Col md={12} lg={4} className={"mb-4 mb-lg-0"} key={key}>
                        <ProductCardTable product={item} />
                      </Col>
                    ))}
                  </Row>
                )
              ) : (
                <Card>
                  <CardBody
                    className={
                      "d-flex flex-column justify-content-center align-items-center"
                    }
                  >
                    <h3>Упс! По запросу "{params.query}" ничего нет</h3>
                    <lord-icon
                      src="https://cdn.lordicon.com/msoeawqm.json"
                      trigger="loop"
                      delay="2000"
                      colors="primary:#121331,secondary:#08a88a"
                      style={{ width: "250px", height: "250px" }}
                    ></lord-icon>
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

export default Search;
