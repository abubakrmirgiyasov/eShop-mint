import { FC, ReactNode } from "react";

// media
import ErrorImage from "../../assets/images/404-error.png";

const Error: FC<ReactNode> = () => {
  return (
    <div className={"page-content"}>
      <div className={"d-flex justify-content-center align-items-center"}>
        <img
          src={ErrorImage}
          className={"img-thumbnail rounded shadow-1"}
          alt={"error"}
        />
      </div>
    </div>
  );
};

export default Error;
