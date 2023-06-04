import React, { useEffect, useState } from "react";
import {
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Col,
  Container,
  Input,
  Row,
  UncontrolledAlert,
} from "reactstrap";
import Breadcrumb from "../../components/Breadcrumb/Breadcrumb";
import { Link } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { decrement, increment } from "../../store/cart";
import { removeFromCart } from "../../store/cart";

const Cart = () => {
  const [sum, setSum] = useState(0);

  const dispatch = useDispatch();

  const { products } = useSelector((state) => ({
    products: state.Cart.cart,
  }));

  useEffect(() => {
    let  res = 0;

    products.map((product) => {
        res += product.price;
    });

    setSum(res);
  }, [products]);

  const handleIncrementClick = (id) => {
    dispatch(increment(id));
  };

  const handleDecrementClick = (id) => {
    dispatch(decrement(id));
  };

  const handleRemoveClick = (id) => {
    dispatch(removeFromCart(id));
  };

  return (
    <div className={"page-content"}>
      <Breadcrumb
        title={"Корзина"}
        pageTitle={"К покупкам"}
        link={"/categories"}
      />
      <Container fluid={true}>
        <Row>
          <Col lg={8} sm={8}>
            <Card>
              <CardHeader className={"border-bottom-dashed"}>
                Корзина
              </CardHeader>
              <CardBody>
                <Row>
                  <Col lg={12}>
                    {products && products.length ? (
                      <>
                        {products.map((item, key) => (
                          <Card
                            className={"product mb-2"}
                            color={"light"}
                            key={key}
                          >
                            <CardBody>
                              <Row className={"gy-3"}>
                                <Col className={"col-sm-auto"}>
                                  <div class={"avatar-lg bg-light rounded p-1"}>
                                    <img
                                      src={item.photos?.at(0)}
                                      alt={item.name}
                                      width={96}
                                      height={96}
                                      style={{
                                        objectFit: "scale-down",
                                        mixBlendMode: "multiply",
                                      }}
                                    />
                                  </div>
                                </Col>
                                <Col className={"col-sm"}>
                                  <h5 className={"fs-14 text-truncate"}>
                                    <Link
                                      className={"text-dark"}
                                      to={"/product-details/" + item.id}
                                    >
                                      {item.name}
                                    </Link>
                                  </h5>
                                  <ul className={"list-inline text-muted"}>
                                    <li className={"list-inline-item"}>
                                      Скидка:{" "}
                                      <span className={"fw-medium"}>
                                        {item.percent} %
                                      </span>
                                      <span className={"fw-medium"}></span>
                                    </li>
                                    <li className={"list-inline-item"}>
                                      Доставка:{" "}
                                      <span className={"fw-medium"}>{item.taxPrice} ₽</span>
                                    </li>
                                  </ul>
                                  <div className="input-step">
                                    <Button
                                      type={"button"}
                                      className={"minus"}
                                      onClick={() =>
                                        handleDecrementClick(item.id)
                                      }
                                    >
                                      &#8722;
                                    </Button>
                                    <Input
                                      name={"demo_vertical"}
                                      type={"text"}
                                      readOnly={true}
                                      className={
                                        "product-quantity form-control"
                                      }
                                      value={item.quantity + 1}
                                    />
                                    <Button
                                      type={"button"}
                                      className={"plus"}
                                      onClick={() =>
                                        handleIncrementClick(item.id)
                                      }
                                    >
                                      &#43;
                                    </Button>
                                  </div>
                                </Col>
                                <Col className={"col-sm-auto"}>
                                  <div className={"text-lg-end"}>
                                    <p className={"text-muted mb-1"}>
                                      Цена товара:
                                    </p>
                                    <h5 className={"fs-14"}>
                                      ₽{" "}
                                      <span
                                        id={"ticket_price"}
                                        class={"product-price"}
                                      >
                                        {item.price}
                                      </span>
                                    </h5>
                                  </div>
                                </Col>
                              </Row>
                            </CardBody>
                            <CardFooter>
                              <Row className={"align-items-center gy-3"}>
                                <Col className={"col-sm  d-flex justify-content-between"}>
                                  <div className="d-flex flex-wrap my-n1">
                                    <div>
                                      <Link
                                        className={"d-block text-body p-1 px-2"}
                                        to={"#"}
                                        onClick={() =>
                                          handleRemoveClick(item.id)
                                        }
                                      >
                                        <i
                                          className={
                                            "ri-delete-bin-fill text-muted align-bottom me-1"
                                          }
                                        ></i>{" "}
                                        Удалить
                                      </Link>
                                    </div>
                                    <div>
                                      <Link
                                        className={"d-block text-body p-1 px-2"}
                                        to="/apps-ecommerce-cart"
                                      >
                                        <i className="ri-heart-fill text-muted align-bottom me-1"></i>{" "}
                                        Добавить в избранное
                                      </Link>
                                    </div>
                                  </div>
                                  <div className="col-sm-auto">
                          <div className="d-flex align-items-center gap-2 text-muted">
                            <div>Сумма:</div>
                            <h5 className="fs-14 mb-0">
                              ₽{" "}
                              <span className="product-line-price">
                                {(((item.price - (item.price * item.percent) / 100) * (item.quantity + 1)) + item.taxPrice).toFixed(2)}
                              </span>
                            </h5>
                          </div>
                        </div>
                                </Col>
                              </Row>
                            </CardFooter>
                          </Card>
                        ))}
                        <div
                          className={
                            "d-flex justify-content-end align-items-center"
                          }
                        >
                          <Link
                            class={"btn btn-success btn-label right ms-auto"}
                            to={"/checkout"}
                          >
                            <i class="ri-arrow-right-line label-icon align-bottom fs-16 ms-2"></i>{" "}
                            Перейти к заказу
                          </Link>
                        </div>
                      </>
                    ) : (
                      <div className={"d-flex flex-column align-items-center"}>
                        <lord-icon
                          src="https://cdn.lordicon.com/nkmsrxys.json"
                          trigger="loop"
                          delay="2000"
                          colors="primary:#121331,secondary:#08a88a"
                          style={{ width: "250px", height: "250px" }}
                        ></lord-icon>
                        <h3 className={"text-muted mt-3"}>
                          У вас нет товаров в корзине
                        </h3>
                      </div>
                    )}
                  </Col>
                </Row>
              </CardBody>
            </Card>
          </Col>
          <Col lg={4} sm={4}>
            <Card>
              <CardHeader className={"border-bottom-dashed"}>Итого</CardHeader>
              <CardBody>
                <div>
                  <div className={"text-start"}>
                    <h6 className={"mb-2"}>
                      Введите <span class={"fw-semibold"}>промокод</span>
                    </h6>
                  </div>
                  <div className={"hstack gap-3 px-3 mx-n3"}>
                    <Input
                      className={"me-auto"}
                      type={"text"}
                      placeholder={"Введите код купона"}
                    />
                    <Button
                      type={"button"}
                      color={"success"}
                      className={"btn btn-icon"}
                    >
                      <i className={"ri-check-line"}></i>
                    </Button>
                  </div>
                </div>
              </CardBody>
              <CardFooter>
                <div className={"table-responsive"}>
                  <table className="table table-borderless mb-0">
                    <tbody>
                      <tr>
                        <td>Промежуточный итог:</td>
                        <td className="text-end" id="cart-subtotal">
                        ₽ {sum}
                        </td>
                      </tr>
                      <tr>
                        <td>
                          Скидка{" "}
                          <span className="text-muted">({"item.discount"})</span> :{" "}
                        </td>
                        <td className="text-end" id="cart-discount">
                          - $ 33
                        </td>
                      </tr>
                      <tr>
                        <td>Доставка: </td>
                        <td className="text-end" id="cart-tax">
                          $ 23
                        </td>
                      </tr>
                      <tr className="table-active">
                        <th>Сумма:</th>
                        <td className="text-end">
                          <span className="fw-semibold" id="cart-total">
                            $ 333
                          </span>
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </CardFooter>
            </Card>
            <UncontrolledAlert color="danger" className="border-dashed">
              <div className="d-flex align-items-center">
                <lord-icon
                  src="https://cdn.lordicon.com/nkmsrxys.json"
                  trigger="loop"
                  colors="primary:#121331,secondary:#f06548"
                  style={{ width: "80px", height: "80px" }}
                ></lord-icon>
                <div className="ms-2">
                  <h5 className="fs-14 text-danger fw-semibold">
                    {" "}
                    Buying for a loved one?
                  </h5>
                  <p className="text-black mb-1">
                    Gift wrap and personalised message on card, <br />
                    Only for <span className="fw-semibold">$9.99</span> USD
                  </p>
                  <button
                    type="button"
                    className="btn ps-0 btn-sm btn-link text-danger text-uppercase"
                  >
                    Add Gift Wrap
                  </button>
                </div>
              </div>
            </UncontrolledAlert>
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default Cart;
