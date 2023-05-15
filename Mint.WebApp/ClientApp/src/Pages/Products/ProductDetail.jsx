import React, { useEffect, useState } from "react";
import {
  Card,
  CardBody,
  Col,
  Container,
  Nav,
  NavItem,
  NavLink,
  Row,
  TabContent,
  TabPane,
  Tooltip,
} from "reactstrap";
import Breadcrumb from "../../components/Breadcrumb/Breadcrumb";
import { Swiper, SwiperSlide } from "swiper/react";
import { Error } from "../../components/Notification/Error";

import SwiperCore, { FreeMode, Navigation, Thumbs } from "swiper";

import "swiper/css";
import "swiper/css/free-mode";
import "swiper/css/navigation";
import "swiper/css/thumbs";
import { Link, useNavigate, useParams } from "react-router-dom";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { useSelector } from "react-redux";
import Rating from "react-rating";
import { PricingWidget } from "../../components/Widgets/PricingWidget";
import classNames from "classnames";
import SimpleBar from "simplebar-react";
import ProductReview from "../../components/Widgets/ProductReview";

SwiperCore.use([FreeMode, Navigation, Thumbs]);

const ProductDetail = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [thumbsSwiper, setThumbsSwiper] = useState(null);
  const [editToolTip, setEditToolTip] = useState(false);
  const [customActiveTab, setCustomActiveTab] = useState(1);
  const [product, setProduct] = useState(null);
  const [isMyProduct, setIsMyProduct] = useState(false);

  const params = useParams();
  const navigate = useNavigate();

  const { myStore, isLoggedIn } = useSelector((state) => ({
    myStore: state.MyStore.myStore,
    isLoggedIn: state.Signin.isLoggedIn,
  }));

  useEffect(() => {
    if (params.id) {
      setIsLoading(true);

      fetchWrapper
        .get("api/product/getproductbyid/" + params.id)
        .then((response) => {
          setProduct(response);

          if (isLoggedIn && response && myStore) {
            if (response.storeId === myStore.id) {
              setIsLoading(false);
              setIsMyProduct(true);
            } else {
              setIsMyProduct(false);
              setIsLoading(false);
            }
          } else {
            setIsLoading(false);
          }
        })
        .catch((error) => {
          setIsLoading(false);
          setError(error);
        });
    } else {
      navigate("/categories");
    }
  }, [params]);

  const tabChangeToggle = (tab) => {
    if (customActiveTab !== tab) setCustomActiveTab(tab);
  };

  const toggleToolTip = () => {
    setEditToolTip(!editToolTip);
  };

  document.title = product?.name + " - Mint";
  return (
    <React.Fragment>
      {error ? <Error message={error} /> : null}
      <div className={"page-content"}>
        <Container fluid>
          <Breadcrumb title={"test"} pageTitle={"ads"} link={"test"} />
          {isLoading ? (
            <div className={"d-flex justify-content-center align-items-center"}>
              <div className={"spinner-grow text-success"} role={"status"}>
                <span className={"visually-hidden"}>Loading...</span>
              </div>
            </div>
          ) : (
            <Row>
              <Col lg={12}>
                <Card>
                  <CardBody>
                    <Row className={"gx-lg-5"}>
                      <Col xl={4} md={8} className={"mx-auto"}>
                        <div className={"product-img-slider sticky-side-div"}>
                          <Swiper
                            navigation={true}
                            // thumbs={{ swiper: thumbsSwiper }}
                            className={
                              "swiper product-thumbnail-slider p-2 rounded bg-light"
                            }
                          >
                            <div className={"swiper-wrapper"}>
                              {product?.photos?.map((photo, key) => (
                                <SwiperSlide key={key}>
                                  <img
                                    src={photo}
                                    alt={product.name}
                                    className={"img-fluid d-block"}
                                  />
                                </SwiperSlide>
                              ))}
                            </div>
                          </Swiper>

                          <div className={"product-nav-slider mt-2"}>
                            <Swiper
                              onSwiper={setThumbsSwiper}
                              slidesPerView={4}
                              freeMode={true}
                              watchSlidesProgress={true}
                              spaceBetween={10}
                              className="swiper product-nav-slider mt-2 overflow-hidden"
                            >
                              <div className={"swiper-wrapper"}>
                                {product?.photos?.map((photo, key) => (
                                  <SwiperSlide key={key}>
                                    <div className={"nav-slide-item"}>
                                      <img
                                        src={photo}
                                        alt={product?.name}
                                        height={120}
                                        className={
                                          "object-cover d-block rounded"
                                        }
                                      />
                                    </div>
                                  </SwiperSlide>
                                ))}
                              </div>
                            </Swiper>
                          </div>
                        </div>
                      </Col>
                      <Col xl={8}>
                        <div className={"mt-xl-0 mt-5"}>
                          <div className={"d-flex"}>
                            <div className={"flex-grow-1"}>
                              <h4>{product?.name}</h4>
                              <div className={"hstack gap-3 flex-wrap"}>
                                <div>
                                  Производитель:{" "}
                                  <Link
                                    to={
                                      "/manufacture/" + product?.manufactureId
                                    }
                                    className={"fw-medium"}
                                    color={"primary"}
                                  >
                                    {product?.manufacture}
                                  </Link>
                                </div>
                                <div className="vr"></div>
                                <div className={"text-muted"}>
                                  Продовец:{" "}
                                  <Link
                                    to={"/stores/" + product?.storeUrl}
                                    className={"fw-medium"}
                                    color={"primary"}
                                  >
                                    {product?.store}
                                  </Link>
                                </div>
                                <div className={"text-muted"}>
                                  Дата релиза:{" "}
                                  <span className={"text-body fw-medium"}>
                                    {`${new Date(
                                      product?.commonCharacteristic?.releaseDate
                                    ).getDate()} / ${
                                      new Date(
                                        product?.commonCharacteristic?.releaseDate
                                      ).getMonth() + 1
                                    } / ${new Date(
                                      product?.commonCharacteristic?.releaseDate
                                    ).getFullYear()}`}
                                  </span>
                                </div>
                              </div>
                            </div>
                            <div className={"flex-shrink-0"}>
                              {isMyProduct ? (
                                <div>
                                  <Tooltip
                                    target={"TooltipTop"}
                                    placement={"top"}
                                    isOpen={editToolTip}
                                    toggle={toggleToolTip}
                                  >
                                    Изменить
                                  </Tooltip>
                                  <Link
                                    to={"/admin/products/edit/" + params.id}
                                    id={"TooltipTop"}
                                    className={"btn btn-light"}
                                  >
                                    <i className="ri-pencil-fill align-bottom"></i>
                                  </Link>
                                </div>
                              ) : null}
                            </div>
                          </div>
                          <div
                            className={
                              "d-flex flex-wrap gap-2 align-items-center mt-3"
                            }
                          >
                            <div className={"text-muted fs-16"}>
                              <Rating
                                initialRating={
                                  product?.commonCharacteristic?.rate
                                }
                                emptySymbol={"mdi mdi-star-outline text-muted"}
                                fullSymbol={"mdi mdi-star text-warning"}
                                className={"me-1"}
                              />
                            </div>
                            <div className={"text-muted"}>(10 отзывов)</div>
                          </div>
                          <Row className={"mt-4"}>
                            <PricingWidget
                              ico={"bx bx-money"}
                              label={"Цена"}
                              detail={"₽ " + product?.price}
                            />
                            {product?.isDiscount ? (
                              <PricingWidget
                                ico={"bx bxs-discount"}
                                label={"Скидка"}
                                detail={"% " + product?.percent}
                              />
                            ) : null}
                            <PricingWidget
                              ico={"ri-e-bike-2-line"}
                              label={"Цена доставки"}
                              detail={
                                product?.isFreeTax ? (
                                  <span className={"text-success"}>
                                    Бесплатная доставка
                                  </span>
                                ) : (
                                  <span className={"text-warning"}>
                                    ₽ {product?.taxPrice}
                                  </span>
                                )
                              }
                            />
                            <PricingWidget
                              ico={"ri-calendar-2-line"}
                              label={"Доставим"}
                              detail={`от ${product?.deliveryMinDay} до ${product?.deliveryMaxDay} дней`}
                            />
                          </Row>
                        </div>
                        <div className={"mt-5 text-muted"}>
                          <h5 className={"fs-14"}>Описание: </h5>
                          <p
                            dangerouslySetInnerHTML={{
                              __html: product?.fullDescription,
                            }}
                          />
                        </div>
                        <div className={"product-content mt-5"}>
                          <h5 className={"fs-14 mb-3"}>
                            Общие характеристики:
                          </h5>
                          <Nav
                            tabs={true}
                            className={"nav-tabs-custom nav-success"}
                          >
                            <NavItem>
                              <NavLink
                                style={{ cursor: "pointer" }}
                                className={classNames({
                                  active: customActiveTab === 1,
                                })}
                                onClick={() => tabChangeToggle(1)}
                              >
                                Спецификация
                              </NavLink>
                            </NavItem>
                            <NavItem>
                              <NavLink
                                style={{ cursor: "pointer" }}
                                className={classNames({
                                  active: customActiveTab === 2,
                                })}
                                onClick={() => tabChangeToggle(2)}
                              >
                                Детали
                              </NavLink>
                            </NavItem>
                          </Nav>
                          <TabContent
                            activeTab={customActiveTab}
                            className={"border border-top-0 p-4"}
                            id={"nav-tabContent"}
                          >
                            <TabPane id={"nav-speci"} tabId={1}>
                              <div className={"table-responsive"}>
                                <table className={"table mb-0"}>
                                  <tbody>
                                    <tr>
                                      <th
                                        scope={"row"}
                                        style={{ width: "200px" }}
                                      >
                                        Категория
                                      </th>
                                      <td>{product?.category}</td>
                                    </tr>
                                    <tr>
                                      <th
                                        scope={"row"}
                                        style={{ width: "200px" }}
                                      >
                                        Производитель
                                      </th>
                                      <td>{product?.manufacture}</td>
                                    </tr>
                                    <tr>
                                      <th
                                        scope={"row"}
                                        style={{ width: "200px" }}
                                      >
                                        Материал
                                      </th>
                                      <td>
                                        {
                                          product?.commonCharacteristic
                                            ?.material
                                        }
                                      </td>
                                    </tr>
                                    <tr>
                                      <th
                                        scope={"row"}
                                        style={{ width: "200px" }}
                                      >
                                        Вес
                                      </th>
                                      <td>
                                        {product?.commonCharacteristic?.weight}{" "}
                                        г.
                                      </td>
                                    </tr>
                                    <tr>
                                      <th
                                        scope={"row"}
                                        style={{ width: "200px" }}
                                      >
                                        Длина
                                      </th>
                                      <td>
                                        {product?.commonCharacteristic?.length}{" "}
                                        см.
                                      </td>
                                    </tr>
                                  </tbody>
                                </table>
                              </div>
                            </TabPane>
                            {/*<TabPane id={"nav-detail"} tabId={2}></TabPane>*/}
                          </TabContent>
                        </div>
                        <div className={"mt-5"}>
                          <div>
                            <h5 className={"fs-14 mb-3"}>Рейтинги и обзоры</h5>
                          </div>
                          <Row className={"gy-4 gx-0"}>
                            <Col lg={4}>
                              <div>
                                <div className={"pb-3"}>
                                  <div
                                    className={
                                      "bg-light px-3 py-2 rounded-2 mb-2"
                                    }
                                  >
                                    <div
                                      className={"d-flex align-items-center"}
                                    >
                                      <Rating
                                        initialRating={
                                          product?.commonCharacteristic?.rate
                                        }
                                        emptySymbol={
                                          "mdi mdi-star-outline text-muted"
                                        }
                                        fullSymbol={"mdi mdi-star text-warning"}
                                        className={"me-1"}
                                      />
                                      <div className={"flex-shrink-0"}>
                                        {product?.commonCharacteristic?.rate} из
                                        5
                                      </div>
                                    </div>
                                  </div>
                                  <div className={"text-center"}>
                                    <div className={"text-muted"}>
                                      Количество отзывов: {97}
                                    </div>
                                  </div>
                                </div>
                                <div className={"mt-3"}>
                                  <Row className={"align-items-center g-2"}>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0"}>5 звезд</h6>
                                      </div>
                                    </Col>
                                    <Col>
                                      <div className={"p-2"}>
                                        <div
                                          className={
                                            "progress animated-progress progress-sm"
                                          }
                                        >
                                          <div
                                            className={
                                              "progress-bar bg-success"
                                            }
                                            role={"progressbar"}
                                            style={{ width: "50.16%" }}
                                            aria-valuenow={50.16}
                                            aria-valuemin={0}
                                            aria-valuemax={100}
                                          ></div>
                                        </div>
                                      </div>
                                    </Col>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0 text-muted"}>
                                          1235
                                        </h6>
                                      </div>
                                    </Col>
                                  </Row>
                                  <Row className={"align-items-center g-2"}>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0"}>4 звезды</h6>
                                      </div>
                                    </Col>
                                    <Col>
                                      <div className={"p-2"}>
                                        <div
                                          className={
                                            "progress animated-progress progress-sm"
                                          }
                                        >
                                          <div
                                            className={
                                              "progress-bar bg-success"
                                            }
                                            role={"progressbar"}
                                            style={{ width: "39%" }}
                                            aria-valuenow={39}
                                            aria-valuemin={0}
                                            aria-valuemax={100}
                                          ></div>
                                        </div>
                                      </div>
                                    </Col>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0 text-muted"}>
                                          666
                                        </h6>
                                      </div>
                                    </Col>
                                  </Row>
                                  <Row className={"align-items-center g-2"}>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0"}>3 звезды</h6>
                                      </div>
                                    </Col>
                                    <Col>
                                      <div className={"p-2"}>
                                        <div
                                          className={
                                            "progress animated-progress progress-sm"
                                          }
                                        >
                                          <div
                                            className={
                                              "progress-bar bg-warning"
                                            }
                                            role={"progressbar"}
                                            style={{ width: "23%" }}
                                            aria-valuenow={23}
                                            aria-valuemin={0}
                                            aria-valuemax={100}
                                          ></div>
                                        </div>
                                      </div>
                                    </Col>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0 text-muted"}>
                                          333
                                        </h6>
                                      </div>
                                    </Col>
                                  </Row>
                                  <Row className={"align-items-center g-2"}>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0"}>3 звезды</h6>
                                      </div>
                                    </Col>
                                    <Col>
                                      <div className={"p-2"}>
                                        <div
                                          className={
                                            "progress animated-progress progress-sm"
                                          }
                                        >
                                          <div
                                            className={
                                              "progress-bar bg-warning"
                                            }
                                            role={"progressbar"}
                                            style={{ width: "13%" }}
                                            aria-valuenow={13}
                                            aria-valuemin={0}
                                            aria-valuemax={100}
                                          ></div>
                                        </div>
                                      </div>
                                    </Col>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0 text-muted"}>
                                          32
                                        </h6>
                                      </div>
                                    </Col>
                                  </Row>
                                  <Row className={"align-items-center g-2"}>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0"}>3 звезды</h6>
                                      </div>
                                    </Col>
                                    <Col>
                                      <div className={"p-2"}>
                                        <div
                                          className={
                                            "progress animated-progress progress-sm"
                                          }
                                        >
                                          <div
                                            className={"progress-bar bg-danger"}
                                            role={"progressbar"}
                                            style={{ width: "3%" }}
                                            aria-valuenow={3}
                                            aria-valuemin={0}
                                            aria-valuemax={100}
                                          ></div>
                                        </div>
                                      </div>
                                    </Col>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0 text-muted"}>3</h6>
                                      </div>
                                    </Col>
                                  </Row>
                                </div>
                              </div>
                            </Col>
                            <Col lg={8}>
                              <div className={"ps-lg-4"}>
                                <div
                                  className={
                                    "d-flex flex-wrap align-items-start gap-3"
                                  }
                                >
                                  <h5 className={"fs-14"}>Отзывы</h5>
                                </div>
                                <SimpleBar className={"pe-lg-4"}>
                                  <ul className={"list-unstyled mb-0"}>
                                    {[].map((review, key) => (
                                      <React.Fragment key={key}>
                                        <ProductReview review={review} />
                                      </React.Fragment>
                                    ))}
                                  </ul>
                                </SimpleBar>
                              </div>
                            </Col>
                          </Row>
                        </div>
                      </Col>
                    </Row>
                  </CardBody>
                </Card>
              </Col>
            </Row>
          )}
        </Container>
      </div>
    </React.Fragment>
  );
};

export default ProductDetail;
