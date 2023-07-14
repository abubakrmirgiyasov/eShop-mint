import React, { FC, ReactNode, useEffect, useState } from "react";
import {
  Button,
  Col,
  Dropdown,
  DropdownMenu,
  DropdownToggle,
  Row,
} from "reactstrap";
import SimpleBar from "simplebar-react";
import { Link } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { getCartProducts } from "../../store/cart/cart";
import { IProduct } from "../../services/types/IProduct";
import ShoppingCartLineIcon from "remixicon-react/ShoppingCartLineIcon";

const CartList: FC<ReactNode> = () => {
  const [isCartDropdown, setIsCartDropdown] = useState<boolean>(false);
  const [sum, setSum] = useState<number>(0);

  const dispatch = useDispatch();

  const { products }: { products: IProduct[] } = useSelector((state) => ({
    products: state.Cart.cart,
  }));

  useEffect(() => {
    let res: number = 0;
    products.map((item) => {
      const locSum = item.price * item.quantity;
      res += locSum;
    });
    setSum(res);
  }, []);

  const toggleDropdown = () => {
    setIsCartDropdown(!isCartDropdown);
    dispatch(getCartProducts(!isCartDropdown));
  };

  const removeProduct = (item) => {
    dispatch(item.id);
  };

  return (
    <React.Fragment>
      <Dropdown
        isOpen={isCartDropdown}
        toggle={toggleDropdown}
        className={"topbar-head-dropdown ms-1 header-item"}
      >
        <DropdownToggle
          type={"button"}
          tag={"button"}
          className={
            "btn btn-icon btn-topbar btn-ghost-secondary rounded-circle"
          }
        >
          <ShoppingCartLineIcon />
          <span
            className={
              "position-absolute cartitem-badge topbar-badge fs-10 translate-middle badge rounded-pill bg-info"
            }
          >
            {products.length}
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
                <span className={"badge badge-soft-success fs-13"}>
                  <span className={"cartitem-badge"}>
                    Товаров в корзине:{" "}
                    {products.length === 0 ? 0 : products.length}
                  </span>
                </span>
              </Col>
            </Row>
          </div>
          <SimpleBar>
            <div className={"p-2"}>
              <div
                className={`text-center empty-cart ${
                  products.length === 0 ? "d-block" : "d-none"
                }`}
                id={"empty-cart"}
              >
                <div className={"avatar-md mx-auto my-3"}>
                  <div
                    className={
                      "avatar-title bg-soft-info text-info fs-36 rounded-circle"
                    }
                  >
                    <ShoppingCartLineIcon />
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
              {products.map((item, key) => (
                <div
                  key={key}
                  className={
                    "d-block dropdown-item text-wrap dropdown-item-cart px-3 py-2"
                  }
                >
                  <div className={"d-flex align-items-center"}>
                    <img
                      src={item.photos.at(0)}
                      className={"me-3 rounded-circle avatar-sm p-2 bg-light"}
                      style={{ objectFit: "scale-down" }}
                      alt={item.name}
                    />
                    <div className={"flex-1"}>
                      <h6 className={"mt-0 mb-1 fs-14"}>
                        <Link
                          to={"/product-details/" + item.id}
                          color={"primary"}
                        >
                          {item.name}
                        </Link>
                      </h6>
                      <p className={"mb-0 fs-12 text-muted"}>
                        Количество:{" "}
                        <span>
                          {item.quantity + 1}{" "}
                          <i className={"ri-close-circle-fill"}></i>{" "}
                          {item.price} ₽
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
                      <Button
                        type={"button"}
                        className={
                          "btn btn-icon btn-sm btn-ghost-secondary remove-item-btn"
                        }
                        onClick={() => removeProduct(item)}
                      >
                        <i className={"ri-close-fill fs-16"}></i>
                      </Button>
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
