import React, { FC } from "react";
import { Swiper, SwiperSlide } from "swiper/react";
import { Badge, Card, CardBody, CardHeader } from "reactstrap";

interface ITopBrands {
  data: any;
}

const TopBrands: FC<ITopBrands> = ({ data }) => {
  return (
    <React.Fragment>
      <Card>
        <CardHeader>
          <Badge color={"info"} className={"fs-14"}>
            <i className={"ri-record-circle-line fs-14 me-1"}></i> ТОП БРЕНДЫ
          </Badge>
        </CardHeader>
        <CardBody>
          <Swiper
            slidesPerView={5}
            spaceBetween={50}
            className={"mySwiper p-2"}
          >
            <SwiperSlide
              className={"bg-primary rounded text-light shadow"}
              style={{ height: "100px" }}
            >
              first
            </SwiperSlide>
            <SwiperSlide
              className={"bg-warning text-light rounded"}
              style={{ height: "100px" }}
            >
              second
            </SwiperSlide>
            <SwiperSlide
              className={"bg-danger text-light rounded"}
              style={{ height: "100px" }}
            >
              third
            </SwiperSlide>
            <SwiperSlide
              className={"bg-dark text-light rounded"}
              style={{ height: "100px" }}
            >
              fourth
            </SwiperSlide>
            <SwiperSlide
              className={"bg-light text-dark rounded"}
              style={{ height: "100px" }}
            >
              fifth
            </SwiperSlide>
            <SwiperSlide
              className={"bg-success text-light rounded"}
              style={{ height: "100px" }}
            >
              sixth
            </SwiperSlide>
          </Swiper>
        </CardBody>
      </Card>
    </React.Fragment>
  );
};

export default TopBrands;
