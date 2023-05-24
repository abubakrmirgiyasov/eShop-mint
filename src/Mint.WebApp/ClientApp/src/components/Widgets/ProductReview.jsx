import React from "react";
import { Badge } from "reactstrap";
import { Link } from "react-router-dom";

const ProductReview = ({ review }) => {
  return (
    <React.Fragment>
      <li className={"py-2"}>
        <div className={"border border-dashed rounded p-3"}>
          <div className={"d-flex align-items-start mb-3"}>
            <div className={"hstack gap-3"}>
              <Badge
                pill={true}
                className={"badge rounded-pill bg-success mb-0"}
                color={"success"}
              >
                <i className="mdi mdi-star"></i> {review.rating}
              </Badge>
              <div className="vr"></div>
              <div className="flex-grow-1">
                <p className="text-muted mb-0">{review.text}</p>
              </div>
            </div>
          </div>
          <div className={"d-flex flex-grow-1 gap-2 mb-3"}>
            {review.photos?.map((item, key) => (
              <Link to={"#"} key={key}>
                <img
                  className={"avatar-sm rounded object-cover"}
                  alt={review.comment}
                  src={item}
                />
              </Link>
            ))}
          </div>
          <div className={"d-flex align-items-end"}>
            <div className={"flex-grow-1"}>
              <h5 className={"fs-14 mb-0"}>{review.fullName}</h5>
            </div>
            <div className={"flex-shrink-0"}>
              <p className={"text-muted fs-13 mb-0"}>{`${new Date(
                review.dateCreate
              ).getDay()} / ${
                new Date(review.dateCreate).getMonth() + 1
              } / ${new Date(review.dateCreate).getFullYear()}`}</p>
            </div>
          </div>
        </div>
      </li>
    </React.Fragment>
  );
};

export default ProductReview;
