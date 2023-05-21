import React from "react";

import ErrorImage from "../../assets/images/error400-cover.png";

const Error = () => {
  return (
    <div className={"page-content"}>
      <div className={"d-flex justify-content-center align-items-center"}>
        <img
          src={ErrorImage}
          className={"img-thumbnail rounded shadow-1"}
          alt={"error-image"}
        />
      </div>
    </div>
  );
};

export default Error;
