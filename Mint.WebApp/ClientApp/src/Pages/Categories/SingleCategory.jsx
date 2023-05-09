import React, { useEffect, useState } from "react";
import {
  Accordion,
  AccordionItem,
  Button,
  Card,
  CardBody,
  Col,
  Collapse,
  Container,
  Input,
  Label,
  Row,
} from "reactstrap";
import Breadcrumb from "../../components/Breadcrumb/Breadcrumb";
import classnames from "classnames";
import { useDispatch, useSelector } from "react-redux";
import { Link, useNavigate, useParams } from "react-router-dom";
import { Error } from "../../components/Notification/Error";
import { products } from "../../Common/Products/products";
import Rating from "react-rating";

const SingleCategory = () => {
  const [isLoading, setIsLoading] = useState(false);
  // const [error, setError] = useState(null);
  const [title, setTitle] = useState(null);
  const [data, setData] = useState([]);

  const params = useParams();
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const { menu, allProducts, message } = useSelector((state) => ({
    menu: state.Categories.menu,
    allProducts: state.Products.products,
    message: state.Message,
  }));

  useEffect(() => {
    setIsLoading(true);

    const fetchData = async () => {
      await dispatch(products())
        .then(() => {
          setIsLoading(false);
        })
        .catch((error) => {
          console.log(error);
          setIsLoading(false);
        });
    };

    fetchData().then((r) => setIsLoading(false));

    if (allProducts && allProducts.length) {
      setIsLoading(false);

      const filteredData = allProducts.filter(
        (item) => item.categoryId === title?.value
      );
      setData(filteredData);
    } else {
      setIsLoading(false);
    }

    console.log(params.name);
    console.log(data);

    if (params.name) {
      menu.map((item) =>
        item.menuChildViewModels.map((child) => {
          if (child.link === params.name) {
            setTitle({ label: child.childName, value: child.id });
          }
        })
      );
    } else {
      navigate("/categories");
    }
  }, [params, dispatch]);

  return (
    <div className={"page-content"}>
      <Breadcrumb
        title={title?.label}
        pageTitle={"Категории"}
        link={"/categories"}
      />
      {message ? <Error message={message} /> : null}
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
                      <Button color={"light"} className={"fs-16 me-2 active"}>
                        <i className={"ri-layout-top-fill"}></i>
                      </Button>
                      <Button color={"light"} className={"fs-16"}>
                        <i className={"ri-grid-fill"}></i>
                      </Button>
                    </div>
                  </div>
                </CardBody>
              </Card>
            </Col>
            <Col lg={3}>
              <Card>
                <CardBody></CardBody>
              </Card>
            </Col>
            <Col lg={9}>
              {data?.map((item, key) => (
                <Card key={key} className={"mb-3"}>
                  <CardBody>
                    <Row>
                      <Col lg={10}>
                        <Row>
                          <Col xl={3}>
                            <div style={{ float: "left" }}>
                              {/*style={{ width: "100%", height: "100px" }}*/}
                              <img
                                src={item.photos[0]}
                                alt={item.name}
                                height={100}
                                width={150}
                                className={"rounded"}
                                // style={{ objectFit: "scale-down" }}
                              />
                            </div>
                          </Col>
                          <Col xl={9}>
                            <Row>
                              <Col lg={12}>
                                <Link
                                  to={"/product-details/" + item.id}
                                  color={"primary"}
                                  className={"fs-18"}
                                  style={{ float: "left" }}
                                >
                                  {item.name}
                                </Link>
                              </Col>
                            </Row>
                            <Col lg={12} className={"mb-2"}>
                              <h5
                                className={"text-muted fs-14"}
                                dangerouslySetInnerHTML={{
                                  __html: item.shortDescription,
                                }}
                              ></h5>
                            </Col>
                            <Col lg={12} className={"mb-1"}>
                              <div
                                className={
                                  "d-flex justify-content-start align-items-center"
                                }
                              >
                                <div className={"form-check fs-15 me-3"}>
                                  <Label className={"form-check-label"}>
                                    <Input
                                      defaultChecked={false}
                                      className={"form-check-input"}
                                      type={"checkbox"}
                                    />
                                    Сравнить
                                  </Label>
                                </div>
                                <div className={""}>
                                  <Rating
                                    initialRating={
                                      item.commonCharacteristic?.rate
                                    }
                                    emptySymbol={
                                      "mdi mdi-star-outline text-muted"
                                    }
                                    fullSymbol={"mdi mdi-star text-warning"}
                                    className={"me-1"}
                                  />
                                  <span className={"text-info"}>
                                    {item.commonCharacteristic?.rate}
                                  </span>
                                </div>
                              </div>
                            </Col>
                            <Col lg={12}>
                              <Link to={"/#"}>Доставим за два часа</Link>
                            </Col>
                          </Col>
                        </Row>
                      </Col>
                      <Col lg={2}>
                        <div className={"d-flex flex-column"}>
                          <div className={"mb-3"}>
                            <span
                              className={
                                "fs-12 text-muted text-decoration-line-through"
                              }
                              style={{ float: "right" }}
                            >
                              {item.percent > 0 ? item.price : ""}
                            </span>
                            <span
                              className={"fs-18 text-danger  me-2"}
                              style={{ float: "right" }}
                            >
                              {item.percent > 0
                                ? (item.price * item.percent) / 100
                                : item.price}
                            </span>
                          </div>
                          <div
                            className={
                              "d-flex justify-content-end align-items-center"
                            }
                          >
                            <Button color={"outline-danger"} className={"me-2"}>
                              <i className={"bx bx-heart"}></i>
                            </Button>
                            <Button color={"outline-success"}>
                              <i className={"bx bx-shopping-bag"}></i>
                            </Button>
                          </div>
                        </div>
                      </Col>
                    </Row>
                  </CardBody>
                </Card>
              ))}
            </Col>
          </Row>
        )}
      </Container>
    </div>
  );
};

export default SingleCategory;
