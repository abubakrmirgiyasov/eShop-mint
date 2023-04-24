import React from "react";
import { Link } from "react-router-dom";
import {
  Badge,
  Button,
  Card,
  CardBody,
  CardHeader,
  Col,
  Row,
} from "reactstrap";
import { Autoplay } from "swiper";
import { Swiper, SwiperSlide } from "swiper/react";

// media
import product1 from "../../assets/images/products/img-2.png";
import product2 from "../../assets/images/products/img-3.png";
import product3 from "../../assets/images/products/img-4.png";
import Rating from "react-rating";

const TopProducts = () => {
  return (
    <React.Fragment>
      <Card>
        <CardHeader>
          <Badge className="bg-success fs-14">
            <i className="mdi mdi-circle-medium fs-14"></i> Топ товары
          </Badge>
        </CardHeader>
        <CardBody>
          <Row>
            <Col xxl={12}>
              <Swiper
                className="mySwiper default-swiper rounded gallery-light mb-3"
                breakpoints={{
                  300: { slidesPerView: 1, spaceBetween: 15 },
                  640: { slidesPerView: 2, spaceBetween: 20 },
                  768: { slidesPerView: 3, spaceBetween: 24 },
                  1024: { slidesPerView: 4, spaceBetween: 30 },
                }}
              >
                <div className="swiper-wrapper">
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand/samsung">Samsung</Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand//huawei">Huawei</Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand/honor">Honor</Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand/xiaomi">Xiaomi</Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/test">test6</Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/test">test7</Link>
                  </SwiperSlide>
                </div>
              </Swiper>
            </Col>
            <Col xxl={12}>
              <Swiper
                className="mySwiper marketplace-swiper rounded gallery-light"
                breakpoints={{
                  300: { slidesPerView: 1, spaceBetween: 15 },
                  640: { slidesPerView: 2, spaceBetween: 20 },
                  768: { slidesPerView: 3, spaceBetween: 24 },
                  1024: { slidesPerView: 3, spaceBetween: 24 },
                }}
              >
                <div className="swiper-wrapper">
                  <SwiperSlide className="bg-light p-2">
                    <Card className="mb-0">
                      <CardBody>
                        <div className="d-flex justify-content-center align-items-center">
                          <img src={product1} width={200} height={200} />
                        </div>
                        <div className="text-start">
                          <h3 className="mb-0">
                            <Link
                              to="/brand/apple"
                              className="text-dark text-start fs-16"
                            >
                              Iphone 14 Pro
                            </Link>
                          </h3>
                          <h3>
                            <Link to="/brand/apple" className="text-muted fs-6">
                              Apple
                            </Link>
                          </h3>
                          <h4 className="text-success">350$</h4>
                          {/* <h5 className="text-info text-muted text-decoration-line-through">450$</h5> */}
                          <Rating
                            initialRating={0}
                            emptySymbol={"mdi mdi-star-outline text-muted"}
                            fullSymbol={"mdi mdi-star text-warning"}
                            className="mb-1"
                          />
                          <div className="d-flex justify-content-between align-items-center">
                            <Button
                              className="btn btn-success fs-14"
                              color="success"
                            >
                              <i className="ri-shopping-cart-line"></i> В
                              корзину
                            </Button>
                            <Button
                              className="btn btn-outline-success fs-14"
                              color="transparent"
                            >
                              <i className="ri-heart-line"></i>
                            </Button>
                          </div>
                        </div>
                      </CardBody>
                    </Card>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2">
                    <Card className="mb-0">
                      <CardBody>
                        <div className="d-flex justify-content-center align-items-center">
                          <img src={product2} width={200} height={200} />
                        </div>
                        <div className="text-start">
                          <h3 className="mb-0">
                            <Link
                              to="/brand/apple"
                              className="text-dark text-start fs-16"
                            >
                              Iphone 11 Pro
                            </Link>
                          </h3>
                          <h3>
                            <Link to="/brand/apple" className="text-muted fs-6">
                              Apple
                            </Link>
                          </h3>
                          <h4 className="text-success">559$</h4>
                          {/* <h5 className="text-info text-muted text-decoration-line-through">450$</h5> */}
                          <Rating
                            initialRating={0}
                            emptySymbol={"mdi mdi-star-outline text-muted"}
                            fullSymbol={"mdi mdi-star text-warning"}
                            className="mb-1"
                          />
                          <div className="d-flex justify-content-between align-items-center">
                            <Button
                              className="btn btn-success fs-14"
                              color="success"
                            >
                              <i className="ri-shopping-cart-line"></i> В
                              корзину
                            </Button>
                            <Button
                              className="btn btn-outline-success fs-14"
                              color="transparent"
                            >
                              <i className="ri-heart-line"></i>
                            </Button>
                          </div>
                        </div>
                      </CardBody>
                    </Card>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2">
                    <Card className="mb-0">
                      <CardBody>
                        <div className="d-flex justify-content-center align-items-center">
                          <img src={product3} width={200} height={200} />
                        </div>
                        <div className="text-start">
                          <h3 className="mb-0">
                            <Link
                              to="/brand/apple"
                              className="text-dark text-start fs-16"
                            >
                              Iphone 12 Pro
                            </Link>
                          </h3>
                          <h3>
                            <Link to="/brand/apple" className="text-muted fs-6">
                              Apple
                            </Link>
                          </h3>
                          <h4 className="text-success">299$</h4>
                          {/* <h5 className="text-info text-muted text-decoration-line-through">450$</h5> */}
                          <Rating
                            initialRating={0}
                            emptySymbol={"mdi mdi-star-outline text-muted"}
                            fullSymbol={"mdi mdi-star text-warning"}
                            className="mb-1"
                          />
                          <div className="d-flex justify-content-between align-items-center">
                            <Button
                              className="btn btn-success fs-14"
                              color="success"
                            >
                              <i className="ri-shopping-cart-line"></i> В
                              корзину
                            </Button>
                            <Button
                              className="btn btn-outline-success fs-14"
                              color="transparent"
                            >
                              <i className="ri-heart-line"></i>
                            </Button>
                          </div>
                        </div>
                      </CardBody>
                    </Card>
                  </SwiperSlide>
                </div>
              </Swiper>
            </Col>
          </Row>
        </CardBody>
      </Card>
    </React.Fragment>
  );
};

export default TopProducts;
