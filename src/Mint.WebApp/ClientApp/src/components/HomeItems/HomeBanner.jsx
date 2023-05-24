import React from "react";
import { Pagination, Autoplay, Navigation } from "swiper";
import { Swiper, SwiperSlide } from "swiper/react";

// images
import apple from "../../assets/images/banners/hero_iphone14pro_spring__9xo85pm6sbmm_large.png";
import samsung from "../../assets/images/banners/1440x640__NeoQLED.png";

const HomeBanner = () => {
  return (
    <div>
      <Swiper
        className="mySwiper swiper pagination-dynamic-swiper rounded"
        loop={true}
        modules={[Pagination, Autoplay, Navigation]}
        navigation={true}
        autoPlay={{
          delay: 2500,
          disableOnInteraction: false,
        }}
        pagination={{
          clickable: true,
          dynamicBullets: true,
        }}
      >
        <div className={"swiper-wrapper"}>
          <SwiperSlide>
            <img src={apple} alt={""} className={"img-fluid w-100"} />
          </SwiperSlide>
          <SwiperSlide>
            <img src={samsung} alt={""} className={"img-fluid w-100"} />
          </SwiperSlide>
        </div>
      </Swiper>
    </div>
  );
};

export default HomeBanner;
