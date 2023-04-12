import React, { useState } from "react";
import { Card, CardBody, Col, Container, Row } from "reactstrap";
import Breadcrumb from "../../components/Breadcrumb/Breadcrumb";
import { Swiper, SwiperSlide } from "swiper/react";

import product1 from "../../assets/images/products/img-1.png";
import product6 from "../../assets/images/products/img-6.png";
import product8 from "../../assets/images/products/img-8.png";
import SwiperCore, { FreeMode, Navigation, Thumbs } from "swiper";

import "swiper/css";
import "swiper/css/free-mode";
import "swiper/css/navigation";
import "swiper/css/thumbs";

SwiperCore.use([FreeMode, Navigation, Thumbs]);

const ProductDetail = () => {
  const [thumbsSwiper, setThumbsSwiper] = useState(null);
  const [top, setTop] = useState(false);
  const [size, setSize] = useState(false);
  const [mSize, setMsize] = useState(false);
  const [lSize, setLsize] = useState(false);
  const [xlSize, setXLsize] = useState(false);
  const [activeTab, setActiveTab] = useState(1);

  const tabChangeToggle = (tab) => {
    if (activeTab !== tab) setActiveTab(tab);
  };

  document.title = "Iphone 12 14 - Mint";
  return (
    <React.Fragment>
      <div className="page-content">
        <Container fluid>
          <Breadcrumb title="test" pageTitle={"ads"} link={"test"} />
          <Row>
            <Col lg={12}>
              <Card>
                <CardBody>
                  <Row className="gx-lg-5">
                    <Col xl={4} md={8} className="mx-auto">
                      <div className="product-img-slider sticky-side-div">
                        <Swiper
                          navigation={true}
                          thumbs={{ swiper: thumbsSwiper }}
                          className="swiper product-thumbnail-slider p-2 rounded bg-light"
                        >
                          <div className="swiper-wrapper">
                            <SwiperSlide>
                              <img
                                src={product8}
                                alt=""
                                className="img-fluid d-block"
                              />
                            </SwiperSlide>
                            <SwiperSlide>
                              <img
                                src={product6}
                                alt=""
                                className="img-fluid d-block"
                              />
                            </SwiperSlide>
                            <SwiperSlide>
                              <img
                                src={product1}
                                alt=""
                                className="img-fluid d-block"
                              />
                            </SwiperSlide>
                            <SwiperSlide>
                              <img
                                src={product8}
                                alt=""
                                className="img-fluid d-block"
                              />
                            </SwiperSlide>
                          </div>
                        </Swiper>

                        <div className="product-nav-slider mt-2">
                          <Swiper
                            onSwiper={setThumbsSwiper}
                            slidesPerView={4}
                            freeMode={true}
                            watchSlidesProgress={true}
                            spaceBetween={10}
                            className="swiper product-nav-slider mt-2 overflow-hidden"
                          >
                            <div className="swiper-wrapper">
                              <SwiperSlide className="rounded">
                                <div className="nav-slide-item">
                                  <img
                                    src={product8}
                                    alt=""
                                    className="img-fluid d-block rounded"
                                  />
                                </div>
                              </SwiperSlide>
                              <SwiperSlide>
                                <div className="nav-slide-item">
                                  <img
                                    src={product6}
                                    alt=""
                                    className="img-fluid d-block rounded"
                                  />
                                </div>
                              </SwiperSlide>
                              <SwiperSlide>
                                <div className="nav-slide-item">
                                  <img
                                    src={product1}
                                    alt=""
                                    className="img-fluid d-block rounded"
                                  />
                                </div>
                              </SwiperSlide>
                              <SwiperSlide>
                                <div className="nav-slide-item">
                                  <img
                                    src={product8}
                                    alt=""
                                    className="img-fluid d-block rounded"
                                  />
                                </div>
                              </SwiperSlide>
                            </div>
                          </Swiper>
                        </div>
                      </div>
                    </Col>
                    <Col xl={8}></Col>
                  </Row>
                </CardBody>
              </Card>
            </Col>
          </Row>
        </Container>
      </div>
    </React.Fragment>
  );
};

export default ProductDetail;
