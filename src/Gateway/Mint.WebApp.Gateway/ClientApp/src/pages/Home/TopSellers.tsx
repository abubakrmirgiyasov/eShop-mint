import React, { FC } from "react";
import { Col, Row } from "reactstrap";
import { SectionDivider } from "../../components/Common/StyledDivider";
import { Swiper, SwiperSlide } from "swiper/react";
import {
  A11y,
  Autoplay,
  Navigation,
  Pagination,
  Scrollbar,
} from "swiper/modules";

interface ITopSellers {
  data: any;
}

const TopSellers: FC<ITopSellers> = ({ data }) => {
  const sectionH1 = {
    fontSize: "24px",
    textAlign: "center",
    textTransform: "uppercase",
    color: "var(--vz-success)",
  };

  return (
    <React.Fragment>
      <Row className={"mb-3"}>
        <Col sm={12}>
          <h1 style={sectionH1}>ТОП ПРОДОВЦЫ</h1>
          <SectionDivider />
        </Col>
        <Col lg={12}>
          <Swiper
            modules={[Navigation, Pagination, Scrollbar, A11y, Autoplay]}
            slidesPerView={1}
            autoplay={{ delay: 2500, disableOnInteraction: false }}
            navigation={true}
            pagination={{ clickable: true }}
            scrollbar={{ draggable: true }}
            style={{ height: "400px" }}
          >
            <SwiperSlide>Slide 1</SwiperSlide>
            <SwiperSlide>Slide 2</SwiperSlide>
            <SwiperSlide>Slide 3</SwiperSlide>
            <SwiperSlide>Slide 4</SwiperSlide>
          </Swiper>
        </Col>
      </Row>
    </React.Fragment>
  );
};

export default TopSellers;
