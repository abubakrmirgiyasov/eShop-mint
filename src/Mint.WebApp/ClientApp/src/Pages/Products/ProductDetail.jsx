import React, { useCallback, useEffect, useState } from "react";
import {
  Button,
  Card,
  CardBody,
  Col,
  Container,
  Nav,
  NavItem,
  NavLink,
  Row,
  Spinner,
  TabContent,
  TabPane,
  Tooltip,
} from "reactstrap";
import Breadcrumb from "../../components/Breadcrumb/Breadcrumb";
import { Swiper, SwiperSlide } from "swiper/react";
import { Error } from "../../components/Notification/Error";
import { Success } from "../../components/Notification/Success";

import SwiperCore, { FreeMode, Navigation, Thumbs } from "swiper";

import "swiper/css";
import "swiper/css/free-mode";
import "swiper/css/navigation";
import "swiper/css/thumbs";
import { Link, useNavigate, useParams } from "react-router-dom";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { useDispatch, useSelector } from "react-redux";
import Rating from "react-rating";
import { PricingWidget } from "../../components/Widgets/PricingWidget";
import classNames from "classnames";
import SimpleBar from "simplebar-react";
import ProductReview from "../../components/Widgets/ProductReview";
import PrivateComponent from "../../helpers/privateComponent";
import AddComment from "./AddComment";
import { newLike } from "../../Common/Likes/likes";

// import { NEW_LIKE } from "../../store/liked/actionType";
import { Roles } from "../../constants/Roles";

SwiperCore.use([FreeMode, Navigation, Thumbs]);

const ProductDetail = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [thumbsSwiper, setThumbsSwiper] = useState(null);
  const [editToolTip, setEditToolTip] = useState(false);
  const [customActiveTab, setCustomActiveTab] = useState(1);
  const [product, setProduct] = useState(null);
  const [reviews, setReviews] = useState([]);
  const [isMyProduct, setIsMyProduct] = useState(false);
  const [isCommentOpen, setIsCommentOpen] = useState(false);
  const [success, setSuccess] = useState("");
  const [isLikeAdding, setIsLikeAdding] = useState(false);

  const params = useParams();
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const { myStore, isLoggedIn, user, message } = useSelector((state) => ({
    myStore: state.MyStore.myStore,
    isLoggedIn: state.Signin.isLoggedIn,
    user: state.Signin.user,
    message: state.Message.message,
  }));

  useEffect(() => {
    if (params.id) {
      setIsLoading(true);

      Promise.all([
        fetchWrapper.get("api/product/getproductbyid/" + params.id),
        fetchWrapper.get("api/review/getproductreviewsbyid/" + params.id),
      ])
        .then((response) => {
          const [product, reviews] = response;
          setProduct(product);
          setReviews(reviews);

          if (isLoggedIn && response.length && myStore) {
            if (product.storeId === myStore.id) {
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
  }, [params, isLoggedIn, myStore, navigate]);

  const tabChangeToggle = (tab) => {
    if (customActiveTab !== tab) setCustomActiveTab(tab);
  };

  const toggleToolTip = () => {
    setEditToolTip(!editToolTip);
  };

  const handleOpenModalClick = () => {
    setIsCommentOpen(true);
  };

  const commentToggle = useCallback(() => {
    if (isCommentOpen) {
      setIsCommentOpen(false);
    } else {
      setIsCommentOpen(true);
    }
  }, [isCommentOpen]);

  // const fiveRateSum = reviews.reduce((sum, item) => {
  //   if (item.rating === 5) {
  //     return sum + item.rating;
  //   } else {
  //     return sum;
  //   }
  // }, 0);

  const handleNewLikeClick = () => {
    if (isLoggedIn) {
      setIsLikeAdding(true);
      const data = {
        userId: user.id,
        productId: params.id,
      };

      dispatch(newLike(data))
        .then(() => {
          setIsLikeAdding(false);
          setSuccess("Добавлено, успешно!");
        })
        .catch((error) => {
          setError(error);
          setIsLikeAdding(false);
        });
    } else {
      setError("Чтобы добавить, вам нужно войти.");
    }
  };

  document.title = product?.name + " - Mint";
  return (
    <React.Fragment>
      {error || message ? <Error message={error || message} /> : null}
      {message ? <Error message={message} /> : null}
      {success ? <Success message={success} /> : null}
      <div className={"page-content"}>
        <Container fluid>
          <Breadcrumb title={"test"} pageTitle={"ads"} link={"test"} />
          {isLoading ? (
            <div className={"d-flex justify-content-center align-items-center"}>
              <Spinner color={"success"} size={"sm"}>
                Loading...
              </Spinner>
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
                                    className={"img-fluid d-block m-auto"}
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
                                    <div
                                      className={"nav-slide-item"}
                                      style={{ width: "fit-content" }}
                                    >
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
                              <div className={"d-flex justify-content-end"}>
                                <div className={"me-2"}>
                                  <Button
                                    className={"btn btn-icon"}
                                    color={"danger"}
                                    onClick={handleNewLikeClick}
                                    disabled={isLikeAdding}
                                  >
                                    {isLikeAdding ? (
                                      <Spinner color={"light"} size={"sm"}>
                                        Loading...
                                      </Spinner>
                                    ) : (
                                      <i
                                        className={"bx bx-heart align-bottom"}
                                      ></i>
                                    )}
                                  </Button>
                                </div>
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
                                      className={"btn btn-outline-success"}
                                    >
                                      <i className="ri-pencil-fill align-bottom"></i>
                                    </Link>
                                  </div>
                                ) : null}
                              </div>
                            </div>
                          </div>
                          <div
                            className={
                              "d-flex flex-wrap gap-2 align-items-center mt-3"
                            }
                          >
                            <div className={"text-muted fs-16"}>
                              <Rating
                                initialRating={product?.rating}
                                emptySymbol={"mdi mdi-star-outline text-muted"}
                                fullSymbol={"mdi mdi-star text-warning"}
                                className={"me-1"}
                              />
                            </div>
                            <div className={"text-muted"}>
                              ({reviews.length} отзывов)
                            </div>
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
                                        initialRating={product?.rating || 0}
                                        emptySymbol={
                                          "mdi mdi-star-outline text-muted"
                                        }
                                        fullSymbol={"mdi mdi-star text-warning"}
                                        className={"me-1"}
                                      />
                                      <div className={"flex-shrink-0"}>
                                        {product?.rating || 0} из 5
                                      </div>
                                    </div>
                                  </div>
                                  <div className={"text-center"}>
                                    <div className={"text-muted"}>
                                      Количество отзывов: {reviews.length}
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
                                            style={{
                                              width: `${
                                                reviews.length
                                                  ? reviews
                                                      .at(0)
                                                      .rateArr.at(0)
                                                      .fifthStar.at(2)
                                                  : 0
                                              }%`,
                                            }}
                                            aria-valuenow={
                                              reviews.length
                                                ? reviews
                                                    .at(0)
                                                    .rateArr.at(0)
                                                    .fifthStar.at(2)
                                                : 0
                                            }
                                            aria-valuemin={0}
                                            aria-valuemax={100}
                                          ></div>
                                        </div>
                                      </div>
                                    </Col>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0 text-muted"}>
                                          {reviews.length
                                            ? reviews
                                                .at(0)
                                                .rateArr.at(0)
                                                .fifthStar.at(0)
                                            : 0}
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
                                            style={{
                                              width: `${
                                                reviews.length
                                                  ? reviews
                                                      .at(0)
                                                      .rateArr.at(0)
                                                      .fourthStar.at(2)
                                                  : 0
                                              }%`,
                                            }}
                                            aria-valuenow={
                                              reviews.length
                                                ? reviews
                                                    .at(0)
                                                    .rateArr.at(0)
                                                    .fourthStar.at(2)
                                                : 0
                                            }
                                            aria-valuemin={0}
                                            aria-valuemax={100}
                                          ></div>
                                        </div>
                                      </div>
                                    </Col>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0 text-muted"}>
                                          {reviews.length
                                            ? reviews
                                                .at(0)
                                                .rateArr.at(0)
                                                .fourthStar.at(0)
                                            : 0}
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
                                            style={{
                                              width: `${
                                                reviews.length
                                                  ? reviews
                                                      .at(0)
                                                      .rateArr.at(0)
                                                      .thirdStar.at(2)
                                                  : 0
                                              }%`,
                                            }}
                                            aria-valuenow={
                                              reviews.length
                                                ? reviews
                                                    .at(0)
                                                    .rateArr.at(0)
                                                    .thirdStar.at(2)
                                                : 0
                                            }
                                            aria-valuemin={0}
                                            aria-valuemax={100}
                                          ></div>
                                        </div>
                                      </div>
                                    </Col>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0 text-muted"}>
                                          {reviews.length
                                            ? reviews
                                                .at(0)
                                                .rateArr.at(0)
                                                .thirdStar.at(0)
                                            : 0}
                                        </h6>
                                      </div>
                                    </Col>
                                  </Row>
                                  <Row className={"align-items-center g-2"}>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0"}>2 звезды</h6>
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
                                            style={{
                                              width: `${
                                                reviews.length
                                                  ? reviews
                                                      .at(0)
                                                      .rateArr.at(0)
                                                      .secondStar.at(2)
                                                  : 0
                                              }%`,
                                            }}
                                            aria-valuenow={
                                              reviews.length
                                                ? reviews
                                                    .at(0)
                                                    .rateArr.at(0)
                                                    .secondStar.at(2)
                                                : 0
                                            }
                                            aria-valuemin={0}
                                            aria-valuemax={100}
                                          ></div>
                                        </div>
                                      </div>
                                    </Col>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0 text-muted"}>
                                          {reviews.length
                                            ? reviews
                                                .at(0)
                                                .rateArr.at(0)
                                                .secondStar.at(0)
                                            : 0}
                                        </h6>
                                      </div>
                                    </Col>
                                  </Row>
                                  <Row className={"align-items-center g-2"}>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0"}>1 звезды</h6>
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
                                            style={{
                                              width: `${
                                                reviews.length
                                                  ? reviews
                                                      .at(0)
                                                      .rateArr.at(0)
                                                      .oneStar.at(2)
                                                  : 0
                                              }%`,
                                            }}
                                            aria-valuenow={
                                              reviews.length
                                                ? reviews
                                                    .at(0)
                                                    .rateArr.at(0)
                                                    .oneStar.at(2)
                                                : 0
                                            }
                                            aria-valuemin={0}
                                            aria-valuemax={100}
                                          ></div>
                                        </div>
                                      </div>
                                    </Col>
                                    <Col className={"col-auto"}>
                                      <div className={"p-2"}>
                                        <h6 className={"mb-0 text-muted"}>
                                          {reviews.length
                                            ? reviews
                                                .at(0)
                                                .rateArr.at(0)
                                                .oneStar.at(0)
                                            : 0}
                                        </h6>
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
                                    "d-flex justify-content-start align-items-center gap-3"
                                  }
                                >
                                  <h5 className={"fs-14 mb-0"}>Отзывы</h5>
                                  <PrivateComponent>
                                    <Button
                                      className={"btn btn-icon"}
                                      color={"primary"}
                                      size={"sm"}
                                      onClick={handleOpenModalClick}
                                      // roles={[Roles.Admin]}
                                    >
                                      <i className={"ri-add-line"}></i>
                                    </Button>
                                  </PrivateComponent>
                                </div>
                                <SimpleBar className={"pe-lg-4"}>
                                  <ul className={"list-unstyled mb-0"}>
                                    {reviews.length ? (
                                      reviews.map((review, key) => (
                                        <React.Fragment key={key}>
                                          <ProductReview review={review} />
                                        </React.Fragment>
                                      ))
                                    ) : (
                                      <h4>Отзывов нет!</h4>
                                    )}
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
      <AddComment
        isOpen={isCommentOpen}
        toggle={commentToggle}
        userId={user?.id}
        productId={params.id}
      />
    </React.Fragment>
  );
};

export default ProductDetail;
