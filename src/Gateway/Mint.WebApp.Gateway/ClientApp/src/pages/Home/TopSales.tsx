import React, { FC } from "react";
import { Badge, Card, CardBody, CardHeader } from "reactstrap";
import { useSelector } from "react-redux";
import { ITag } from "../../services/admin/ITag";
import { Swiper, SwiperSlide } from "swiper/react";
import { Navigation } from "swiper/modules";

interface ITopSales {
  data: any;
}

type Breakpoints = {
  [key: number]: {
    width: number;
    slidesPerView: number;
  };
};

const TopSales: FC<ITopSales> = ({ data }) => {
  const { tags }: { tags: ITag[] } = useSelector((state) => ({
    tags: state.Tags.tags,
  }));

  const breakpoints: Breakpoints = {
    // 350: {
    //   width: 350,
    //   slidesPerView: 1,
    // },
    // 600: {
    //   width: 600,
    //   slidesPerView: 2,
    // },
  };

  return (
    <React.Fragment>
      <Card>
        <CardHeader>
          <Badge color={"danger"} className={"fs-14"}>
            <i className={"ri-record-circle-line fs-14 me-1"}></i> ТОП СКИДКИ
          </Badge>
        </CardHeader>
        <CardBody>
          <Swiper sliderPerView={5} spaceBetween={50} className={"p-2"}>
            {tags?.slice(0, 7).map((tag, key) => (
              <SwiperSlide key={key}>{tag.label}</SwiperSlide>
            ))}
          </Swiper>
          <Swiper
            modules={[Navigation]}
            navigation={true}
            slidesPerView={3}
            spaceBetween={40}
            className={"p-2"}
            breakpoints={breakpoints}
          >
            <SwiperSlide
              className={"bg-warning rounded text-light"}
              style={{ height: "400px" }}
            >
              Slide 1
            </SwiperSlide>
            <SwiperSlide
              className={"bg-info rounded text-light"}
              style={{ height: "400px" }}
            >
              Slide 2
            </SwiperSlide>
            <SwiperSlide
              className={"bg-danger rounded text-light"}
              style={{ height: "400px" }}
            >
              Slide 3
            </SwiperSlide>
            <SwiperSlide
              className={"bg-primary rounded text-light"}
              style={{ height: "400px" }}
            >
              Slide 4
            </SwiperSlide>
            <SwiperSlide
              className={"bg-dark rounded text-light"}
              style={{ height: "400px" }}
            >
              Slide 5
            </SwiperSlide>
            <SwiperSlide
              className={"bg-success rounded text-light"}
              style={{ height: "400px" }}
            >
              Slide 6
            </SwiperSlide>
          </Swiper>
        </CardBody>
      </Card>
    </React.Fragment>
  );
};

export default TopSales;
