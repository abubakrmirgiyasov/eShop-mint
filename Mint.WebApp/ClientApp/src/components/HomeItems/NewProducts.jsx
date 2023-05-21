import React from "react";
import {
  Badge,
  Card,
  CardBody,
  CardHeader,
  Col,
  Row,
  Spinner,
} from "reactstrap";
import { ProductCardTable } from "../../components/Products/ProductCard";
import { Swiper, SwiperSlide } from "swiper/react";
import { Link } from "react-router-dom";

const NewProducts = ({ products, isLoading }) => {
  return (
    <React.Fragment>
      <Card>
        <CardHeader>
          <Badge color={"info"} className={"bg-primary fs-14"}>
            <i className={"mdi mdi-circle-medium fs-14"}></i> Новинки
          </Badge>
        </CardHeader>
        <CardBody
          className={
            isLoading
              ? "d-flex justify-content-center"
              : !products.length
              ? "d-flex justify-content-center"
              : ""
          }
        >
          {!isLoading && !products.length ? (
            <lord-icon
              src={"https://cdn.lordicon.com/hrqwmuhr.json"}
              trigger={"loop"}
              colors={"primary:#121331,secondary:#08a88a"}
              style={{ width: "350px", height: "350px" }}
            ></lord-icon>
          ) : (
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
                  className={
                    "mySwiper marketplace-swiper rounded gallery-light"
                  }
                  breakpoints={{
                    300: { slidesPerView: 1, spaceBetween: 15 },
                    640: { slidesPerView: 2, spaceBetween: 20 },
                    768: { slidesPerView: 3, spaceBetween: 24 },
                    1024: { slidesPerView: 3, spaceBetween: 24 },
                  }}
                >
                  <div className={"swiper-wrapper"}>
                    {products.map((product, index) => (
                      <SwiperSlide
                        className={"bg-light p-2 text-center"}
                        style={{ height: "390px" }}
                        key={index}
                      >
                        <ProductCardTable product={product} />
                      </SwiperSlide>
                    ))}
                  </div>
                </Swiper>
              </Col>
            </Row>
          )}
          {isLoading ?? (
            <Spinner size={"sm"} color={"success"}>
              Loading...
            </Spinner>
          )}
        </CardBody>
      </Card>
    </React.Fragment>
  );
};

export default NewProducts;
