import React, { useState, useEffect } from "react";
import { useDispatch } from "react-redux";
import { Link } from "react-router-dom";
import { Col, Dropdown, DropdownMenu, DropdownToggle, Row, Spinner } from "reactstrap";
import SimpleBar from "simplebar-react";
import { removeLike } from "../../Common/Likes/likes";
import { Success } from "../Notification/Success";
import { Error } from "../Notification/Error";

const LikesList = ({ isLoggedIn, likes, userId }) => {
  const [isLikeDropdown, setIsLikeDropdown] = useState(false);
  const [isRemoving, setIsRemoving] = useState(false);
  const [sum, setSum] = useState(0);
  const [success, setSuccess] = useState(null);
  const [error, setError] = useState(null);

  const dispatch = useDispatch();

  const toggleLikeDropdown = () => {
    setIsLikeDropdown(!isLikeDropdown);
  };

  const handleRemoveClick = (id) => {
    if (isLoggedIn) {
      setIsRemoving(true);

    const data = {
      userId: userId,
      productId: id,
    };

    dispatch(removeLike(data))
      .then(() => {
        setIsRemoving(false);
        setSuccess("Удалено, успешно");
      })
      .catch((error) => {
        setIsRemoving(false);
        setError(error);
      });
    }
  };

  useEffect(() => {
    let res = 0;
    likes.map((item) => {
      const locSum = item.product?.price * (item.product?.quantity + 1);
      res += locSum;
    });
    setSum(res);
  }, [dispatch, isLikeDropdown, likes]);

  return (
    <React.Fragment>
      {success ? <Success message={success} /> : null}
      {error ? <Error message={error} /> : null}
      <Dropdown
        isOpen={isLikeDropdown}
        toggle={toggleLikeDropdown}
        className={"topbar-head-dropdown ms-1 header-item"}
      >
        <DropdownToggle
          type={"button"}
          tag={"button"}
          className={
            "btn btn-icon btn-topbar btn-ghost-secondary rounded-circle"
          }
        >
          <i className={"bx bx-heart fs-22"}></i>
          <span
            className={
              "position-absolute cartitem-badge topbar-badge fs-10 translate-middle badge rounded-pill bg-danger"
            }
          >
            {likes?.length}
          </span>
        </DropdownToggle>
        <DropdownMenu
          className={
            "dropdown-menu-xl dropdown-menu-end p-0 dropdown-menu-cart"
          }
          aria-labelledby={"page-header-cart-dropdown"}
        >
          <div
            className={
              "p-3 border-top-0 border-start-0 border-end-0 border-dashed border"
            }
          >
            <Row className={"align-items-center"}>
              <Col>
                <h6 className={"m-0 fs-16 fw-semibol"}>Список желаний</h6>
              </Col>
              <Col className={"col-auto"}>
                <span className={"badge badge-soft-danger fs-13"}>
                  <span className={"cartitem-badge"}>
                    Товаров в списке: {likes?.length === 0 ? 0 : likes?.length}
                  </span>
                </span>
              </Col>
            </Row>
          </div>
          <SimpleBar>
            <div className={"p-2"}>
              <div
                className={`text-center empty-cart ${
                  likes?.length === 0 ? "" : "d-none"
                }`}
                id={"empty-cart"}
              >
                <div className={"avatar-md mx-auto my-3"}>
                  <div
                    className={
                      "avatar-title bg-soft-info text-info fs-36 rounded-circle"
                    }
                  >
                    <i className={"bx bx-cart"}></i>
                  </div>
                </div>
                <h5 className={"mb-3"}>Упс, тут пусто!</h5>
                <Link
                  to={"/categories"}
                  className={"btn btn-danger w-md mb-3"}
                >
                  К покупкам
                </Link>
              </div>
              {likes?.map((item, key) => (
                <div
                  className={
                    "d-block dropdown-item text-wrap dropdown-item-cart px-3 py-2"
                  }
                  key={key}
                >
                  <div className={"d-flex align-items-center"}>
                    <img
                      src={item.product?.photos?.at(0)}
                      className={"me-3 rounded-circle avatar-sm p-2 bg-light"}
                      style={{ objectFit: "scale-down" }}
                      alt={""}
                    />
                    <div className={"flex-1"}>
                      <h6 className={"mt-0 mb-1 fs-14"}>
                        <Link
                          to={"/product-details/" + item.product?.id} // here /id also
                          color={"primary"}
                        >
                          {item.product?.name}
                        </Link>
                      </h6>
                    </div>
                    <div className={"px-2"}>
                      <h5 className={"m-0 fw-normal"}>
                        ₽{" "}
                        <span className={"cart-item-price"}>
                          {item.product?.price}
                        </span>
                      </h5>
                    </div>
                    <div className={"ps-2"}>
                      <button
                        type={"button"}
                        className={
                          "btn btn-icon btn-sm btn-ghost-secondary remove-item-btn"
                        }
                        onClick={() => handleRemoveClick(item.product?.id)}
                      >
                      {isRemoving ? (<Spinner size={"sm"} />) : (
                        <i className={"ri-close-fill fs-16"}></i>
                      )}
                      </button>
                    </div>
                  </div>
                </div>
              ))}
            </div>
          </SimpleBar>
          <div
            className={
              "p-3 border-bottom-0 border-start-0 border-end-0 border-dashed border"
            }
            id={"checkout-elem"}
          >
            <div
              className={
                "d-flex justify-content-between align-items-center pb-3"
              }
            >
              <h5 className={"m-0 text-muted"}>Сумма: </h5>
              <div className={"px-2"}>
                <h5 className={"m-0"}>
                  ₽ <span id={"cart-item-total"}>{sum}</span>
                </h5>
              </div>
            </div>
            <Link to={"/likes"} className={"btn btn-danger text-center w-100"}>
              Перейти к избранным
            </Link>
          </div>
        </DropdownMenu>
      </Dropdown>
    </React.Fragment>
  );
};

export default LikesList;
