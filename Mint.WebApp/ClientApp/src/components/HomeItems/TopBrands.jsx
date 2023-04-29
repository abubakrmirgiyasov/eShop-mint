import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Badge, Card, CardBody, Col, Row } from "reactstrap";
import { Swiper, SwiperSlide } from "swiper/react";

// media
import xiaomi from "../../assets/images/brands/Xiaomi.png";
import zte from "../../assets/images/brands/ZTE.png";
import honor from "../../assets/images/brands/Honor.png";
import realme from "../../assets/images/brands/RealMe.png";
import apple from "../../assets/images/brands/Apple.png";
import huawei from "../../assets/images/brands/Huawei.png";
import samsung from "../../assets/images/brands/Samsung.png";

const TopBrands = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  useEffect(() => {}, []);

  return (
    <React.Fragment>
      <Row>
        <Col xxl={12}>
          <Card>
            <CardBody>
              <Badge color={"primary"} className={"bg-primary fs-14 mb-3"}>
                <i className={"mdi mdi-circle-medium fs-14"}></i> Топ бренды
              </Badge>
              <Swiper
                className="mySwiper swiper pagination-dynamic-swiper rounded"
                breakpoints={{
                  300: { slidesPerView: 1, spaceBetween: 15 },
                  640: { slidesPerView: 2, spaceBetween: 20 },
                  768: { slidesPerView: 4, spaceBetween: 24 },
                  1024: { slidesPerView: 6, spaceBetween: 30 },
                }}
              >
                <div className={"swiper-wrapper"}>
                  <SwiperSlide className={"bg-light p-2 text-center"}>
                    <Link to={"/brand/xiaomi"}>
                      <img
                        src={xiaomi}
                        width={100}
                        height={70}
                        className={"rounded"}
                      />
                    </Link>
                  </SwiperSlide>
                  <SwiperSlide className={"bg-light p-2 text-center"}>
                    <Link to={"/brand/xiaomi"}>
                      <img
                        src={zte}
                        width={100}
                        height={70}
                        className={"rounded"}
                      />
                    </Link>
                  </SwiperSlide>
                  <SwiperSlide className={"bg-light p-2 text-center"}>
                    <Link to="/brand/xiaomi">
                      <img
                        src={honor}
                        width={100}
                        height={70}
                        className="rounded"
                      />
                    </Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand/xiaomi">
                      <img
                        src={realme}
                        width={100}
                        height={70}
                        className="rounded"
                      />
                    </Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand/xiaomi">
                      <img
                        src={apple}
                        width={100}
                        height={70}
                        className="rounded"
                      />
                    </Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand/xiaomi">
                      <img
                        src={huawei}
                        width={100}
                        height={70}
                        className="rounded"
                      />
                    </Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand/xiaomi">
                      <img
                        src={samsung}
                        width={100}
                        height={70}
                        className="rounded"
                      />
                    </Link>
                  </SwiperSlide>
                </div>
              </Swiper>
            </CardBody>
          </Card>
        </Col>
      </Row>
    </React.Fragment>
  );
};

export default TopBrands;
