import React, { FC } from "react";
import { Badge, Card, CardBody, CardHeader } from "reactstrap";
import { Swiper, SwiperSlide } from "swiper/react";
import { useSelector } from "react-redux";
import { ITag } from "../../services/admin/ITag";
import { Navigation } from "swiper/modules";

interface ITopRecommendations {
  data: any;
}

const TopRecommendations: FC<ITopRecommendations> = ({ data }) => {
  const { tags }: { tags: ITag[] } = useSelector((state) => ({
    tags: state.Tags.tags,
  }));

  return (
    <React.Fragment>
      <Card>
        <CardHeader>
          <Badge color={"primary"} className={"fs-14"}>
            <i className={"ri-record-circle-line fs-14 me-1"}></i> ТОП
            РЕКОМЕНДАЦИИ
          </Badge>
        </CardHeader>
        <CardBody>
          <Swiper sliderPerView={5} spaceBetween={50} className={"p-2"}>
            {tags?.slice(0, 7).map((tag, key) => (
              <SwiperSlide key={key}> {tag.label} </SwiperSlide>
            ))}
          </Swiper>
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

export default TopRecommendations;
