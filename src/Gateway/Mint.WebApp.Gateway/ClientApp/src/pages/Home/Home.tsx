import React from "react";
import { Link } from "react-router-dom";
import { Container } from "reactstrap";
import { Swiper, SwiperSlide } from "swiper/react";
import {
  Navigation,
  Pagination,
  Scrollbar,
  A11y,
  Autoplay,
} from "swiper/modules";
import History from "./History";
import TopSellers from "./TopSellers";
import TopSales from "./TopSales";
import TopRecommendations from "./TopRecommendations";
import TopBrands from "./TopBrands";

const Home = () => {
  return (
    <div className={"page-content"}>
      <Container fluid>
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
        <div className={"top-brands mt-3"}>
          <TopBrands data={[]} />
        </div>
        <div className={"top-recommendations"}>
          <TopRecommendations data={[]} />
        </div>
        <div className={"top-sales"}>
          <TopSales data={[]} />
        </div>
        <div className={"top-sellers"}>
          <TopSellers data={[]} />
        </div>
        {/*<div className={"custom-box"}>custom box</div>*/}
        <div className={"history"}>
          <History data={[]} />
        </div>
      </Container>
    </div>
  );
};

export default Home;
