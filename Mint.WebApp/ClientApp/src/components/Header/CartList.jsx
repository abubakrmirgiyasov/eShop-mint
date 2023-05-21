import React, { useEffect, useRef, useState } from "react";
import { Col, Dropdown, DropdownMenu, DropdownToggle, Row } from "reactstrap";
import { Link } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import SimpleBar from "simplebar-react";
import { removeFromCart, toggleCart } from "../../store/cart";

// image
import defaultImage from "../../assets/images/default-image.png";

const CartList = () => {
  const [isCartDropdown, setIsCartDropdown] = useState(false);
  const [sum, setSum] = useState(0);

  const dispatch = useDispatch();

  const { cartData } = useSelector((state) => ({
    cartData: state.Cart.cart,
  }));

  const toggleCartDropdown = () => {
    setIsCartDropdown(!isCartDropdown);
    dispatch(toggleCart(true));
  };

  useEffect(() => {
    let res = 0;
    cartData.map((item) => {
      const locSum = item.price * (item.quantity + 1);
      res += locSum;
    });
    setSum(res);
  }, [dispatch, isCartDropdown, cartData]);

  const removeItem = (item) => {
    dispatch(removeFromCart(item.id));
  };

  return (
    <React.Fragment>
      <Dropdown
        isOpen={isCartDropdown}
        toggle={toggleCartDropdown}
        className={"topbar-head-dropdown ms-1 header-item"}
      >
        <DropdownToggle
          type={"button"}
          tag={"button"}
          className={
            "btn btn-icon btn-topbar btn-ghost-secondary rounded-circle"
          }
        >
          <i className={"bx bx-shopping-bag fs-22"}></i>
          <span
            className={
              "position-absolute cartitem-badge topbar-badge fs-10 translate-middle badge rounded-pill bg-info"
            }
          >
            {cartData.length}
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
                <h6 className={"m-0 fs-16 fw-semibol"}>Корзина</h6>
              </Col>
              <Col className={"col-auto"}>
                <span className={"badge badge-soft-warning fs-13"}>
                  <span className={"cartitem-badge"}>
                    Товаров в корзине:{" "}
                    {cartData.length === 0 ? 0 : cartData.length}
                  </span>
                </span>
              </Col>
            </Row>
          </div>
          <SimpleBar>
            <div className={"p-2"}>
              <div
                className={`text-center empty-cart ${
                  cartData.length === 0 ? "" : "d-none"
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
                <h5 className={"mb-3"}>Упс, ваша корзина пуста!</h5>
                <Link
                  to={"/categories"}
                  className={"btn btn-success w-md mb-3"}
                >
                  К покупкам
                </Link>
              </div>
              {cartData.map((item, key) => (
                <div
                  className={
                    "d-block dropdown-item text-wrap dropdown-item-cart px-3 py-2"
                  }
                  key={key}
                >
                  <div className={"d-flex align-items-center"}>
                    <img
                      src={item.photos?.length ? item.photos[0] : defaultImage}
                      className={"me-3 rounded-circle avatar-sm p-2 bg-light"}
                      style={{ objectFit: "scale-down" }}
                      alt={""}
                    />
                    <div className={"flex-1"}>
                      <h6 className={"mt-0 mb-1 fs-14"}>
                        <Link
                          to={"/product-details/" + item.id} // here /id also
                          color={"primary"}
                        >
                          {item.name}
                        </Link>
                      </h6>
                      <p className={"mb-0 fs-12 text-muted"}>
                        Количество:{" "}
                        <span>
                          {item.quantity + 1} x ₽ {item.price}
                        </span>
                      </p>
                    </div>
                    <div className={"px-2"}>
                      <h5 className={"m-0 fw-normal"}>
                        ₽{" "}
                        <span className={"cart-item-price"}>
                          {(item.quantity + 1) * item.price}
                        </span>
                      </h5>
                    </div>
                    <div className={"ps-2"}>
                      <button
                        type={"button"}
                        className={
                          "btn btn-icon btn-sm btn-ghost-secondary remove-item-btn"
                        }
                        onClick={() => removeItem(item)}
                      >
                        <i className={"ri-close-fill fs-16"}></i>
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
            <Link
              to={"/checkout"}
              className={"btn btn-success text-center w-100"}
            >
              Перейти к заказу
            </Link>
          </div>
        </DropdownMenu>
      </Dropdown>
    </React.Fragment>
  );
};

export default CartList;
