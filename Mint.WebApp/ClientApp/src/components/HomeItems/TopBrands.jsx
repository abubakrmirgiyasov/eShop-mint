import React from "react";
import { Link } from "react-router-dom";
import { Card, CardBody, Col, Row } from "reactstrap";
import { Autoplay } from "swiper";
import { Swiper, SwiperSlide } from "swiper/react";

// media 
import xiaomi from "../../assets/images/brands/xiaomi.png"
import zte from "../../assets/images/brands/ZTE.png"
import honor from "../../assets/images/brands/honor.png"
import realme from "../../assets/images/brands/realme.png"
import apple from "../../assets/images/brands/apple.png"
import huawei from "../../assets/images/brands/huawei.png"
import samsung from "../../assets/images/brands/samsung.jpg"

const TopBrands = () => {
  return (
    <React.Fragment>
      <Row>
        <Col xxl={12}>
          <Card>
            <CardBody>
              <Swiper
                className="mySwiper default-swiper rounded gallery-light mb-3"
                modules={[Autoplay]}
                slidesPerView={6}
                spaceBetween={30}
                loop={true}
                autoplay={{ delay: 2500, disableOnInteraction: false }}
                breakpoints={{
                  300: { slidesPerView: 1, spaceBetween: 15 },
                  640: { slidesPerView: 2, spaceBetween: 20 },
                  768: { slidesPerView: 3, spaceBetween: 24 },
                  1024: { slidesPerView: 4, spaceBetween: 24 },
                }}
              >
                <div className="swiper-wrapper">
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand/xiaomi">
                      <img src={xiaomi} width={100} height={50} />
                    </Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand/xiaomi">
                      <img src={zte} width={100} height={50} />
                    </Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand/xiaomi">
                      <img src={honor} width={100} height={50} />
                    </Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand/xiaomi">
                      <img src={realme} width={100} height={50} />
                    </Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand/xiaomi">
                      <img src={apple} width={100} height={50} />
                    </Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand/xiaomi">
                      <img src={huawei} width={100} height={50} />
                    </Link>
                  </SwiperSlide>
                  <SwiperSlide className="bg-light p-2 text-center">
                    <Link to="/brand/xiaomi">
                      <img src={samsung} width={100} height={50} />
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
