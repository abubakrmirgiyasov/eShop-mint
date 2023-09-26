import React, { FC } from "react";
import { Badge, Card, CardBody, CardHeader } from "reactstrap";
import { Swiper, SwiperSlide } from "swiper/react";
import { Navigation } from "swiper/modules";

interface IHistory {
  data: any;
}

const History: FC<IHistory> = ({ data }) => {
  return (
    <React.Fragment>
      <Card>
        <CardHeader>
          <Badge color={"warning"} className={"fs-14"}>
            <i className={"ri-record-circle-line fs-14 me-1"}></i> ВЫ НЕДАВНО
            СМОТРЕЛИ
          </Badge>
        </CardHeader>
        <CardBody>
          <Swiper
            modules={[Navigation]}
            navigation={true}
            slidesPerView={3}
            spaceBetween={40}
            className={"p-2"}
          >
            <SwiperSlide
              className={"bg-primary rounded text-light"}
              style={{ height: "400px" }}
            >
              slide 1
            </SwiperSlide>
            <SwiperSlide
              className={"bg-success rounded text-light"}
              style={{ height: "400px" }}
            >
              slide 2
            </SwiperSlide>
            <SwiperSlide
              className={"bg-warning rounded text-light"}
              style={{ height: "400px" }}
            >
              slide 3
            </SwiperSlide>
            <SwiperSlide
              className={"bg-dark rounded text-light"}
              style={{ height: "400px" }}
            >
              slide 4
            </SwiperSlide>
            <SwiperSlide
              className={"bg-success rounded text-light"}
              style={{ height: "400px" }}
            >
              slide 5
            </SwiperSlide>
            <SwiperSlide
              className={"bg-info rounded text-light"}
              style={{ height: "400px" }}
            >
              slide 6
            </SwiperSlide>
          </Swiper>
        </CardBody>
      </Card>
    </React.Fragment>
  );
};

export default History;
