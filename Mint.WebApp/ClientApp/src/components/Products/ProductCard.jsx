import React, { useState } from "react";
import { Badge, Button, Card, CardBody, Col, Row } from "reactstrap";
import { Link } from "react-router-dom";
import Rating from "react-rating";
import { dateConverter } from "../../helpers/dateConverter";
import { addToCart } from "../../store/cart";
import { useDispatch } from "react-redux";
import { Success } from "../Notification/Success";

const ProductCardRow = ({ product }) => {
  // const date = dateConverter(product.commonCharacteristic?.releaseDate);

  const [success, setSuccess] = useState(false);

  const dispatch = useDispatch();

  const handleCartAddClick = (item) => {
    console.log(item);
    dispatch(addToCart({ ...item }));
    setSuccess("Успешно добавлено");
  };

  const date = "2020-01-01";

  return (
    <React.Fragment>
      {success ? <Success message={success} /> : null}
      <Card className={"position-relative"}>
        {product.isDiscount ? (
          <div
            className={"d-flex justify-content-end p-3 position-absolute"}
            style={{ left: 0, zIndex: 1 }}
          >
            <div
              className={
                "bg-danger rounded-circle d-flex align-items-center justify-content-center shadow-1-strong"
              }
              style={{ width: "35px", height: "35px" }}
            >
              <p className={"text-white mb-0 small"}>% {product.percent}</p>
            </div>
          </div>
        ) : null}
        <CardBody>
          <Row>
            <Col className={"mb-4 mb-lg-0"} md={12} lg={3}>
              <div className={"bg-image rounded hover-zoom hover-overlay"}>
                <img
                  src={product.photos[0]}
                  className={"fluid w-100"}
                  alt={product.name}
                />
                <Link to={"/product-details/" + product.id}>
                  <div
                    className={"mask"}
                    style={{
                      backgroundColor: "rgba(251,251,251,0.15)",
                    }}
                  ></div>
                </Link>
              </div>
            </Col>
            <Col md={6}>
              <Link
                to={"/product-details/" + product.id}
                className={"fs-16"}
                color={"primary"}
              >
                {product.name}
              </Link>
              <div className="d-flex flex-row">
                <div className="text-danger mb-1 me-2">
                  <Rating
                    initialRating={product.commonCharacteristic?.rate}
                    emptySymbol={"mdi mdi-star-outline text-muted"}
                    fullSymbol={"mdi mdi-star text-warning"}
                    className={"me-1"}
                  />
                </div>
                <span>{product.commonCharacteristic?.rate}</span>
              </div>
              <div className="mt-1 mb-0 text-muted small">
                <span>Год релиза: {date}</span>
                <span className="text-primary"> • </span>
                <span>Материал: {product.commonCharacteristic?.material}</span>
                <span className="text-primary"> • </span>
                <span>
                  <br />
                </span>
              </div>
              <div className="mb-2 text-muted small">
                <span>
                  Срок годности: {product.commonCharacteristic?.garanty} мес
                </span>
              </div>
              <p className="mb-4 mb-md-0">
                {product.shortDescription.length > 200
                  ? product.shortDescription.substring(0, 199) + "..."
                  : product.shortDescription}
              </p>
            </Col>
            <Col md={6} lg={3} className={"border-sm-start-none border-start"}>
              <div className={"d-flex flex-row align-items-center mb-1"}>
                {product.isDiscount ? (
                  <>
                    <h4 className={"mb-1 me-1"}>
                      ₽{" "}
                      {product.price - (product.price * product.percent) / 100}
                    </h4>
                    <span className={"text-danger"}>
                      <s>₽ {product.price}</s>
                    </span>
                  </>
                ) : (
                  <h4 className={"mb-1 me-1"}>₽ {product.price}</h4>
                )}
              </div>
              {product.isFreeTax ? (
                <h6 className="text-success">Бесплатная доставка</h6>
              ) : (
                <h6 className="text-warning">
                  Цена доставки: ₽ {product.taxPrice}
                </h6>
              )}
              <div className={"d-flex flex-column mt-4"}>
                <Link
                  to={"/product-details/" + product.id}
                  color={"success"}
                  className={"btn btn-success"}
                  size={"md"}
                >
                  Подробнее
                </Link>
                <Button
                  color={"outline-success"}
                  size={"md"}
                  className={"mt-2"}
                  onClick={() => handleCartAddClick(product)}
                >
                  <i className={"bx bx-shopping-bag"}></i> Добавить в корзину
                </Button>
              </div>
            </Col>
          </Row>
        </CardBody>
      </Card>
    </React.Fragment>
  );
};

const ProductCardTable = ({ product }) => {
  const [success, setSuccess] = useState(false);

  const dispatch = useDispatch();

  const handleCartAddClick = (item) => {
    console.log(item);
    dispatch(addToCart({ ...item }));
    setSuccess("Успешно добавлено");
  };

  return (
    <React.Fragment>
      {success ? <Success message={success} /> : null}
      <Card style={{ height: "370px" }} className={"position-relative"}>
        {product.isDiscount ? (
          <div
            className={"d-flex justify-content-end p-3 position-absolute"}
            style={{ right: 0 }}
          >
            <div
              className={
                "bg-danger rounded-circle d-flex align-items-center justify-content-center shadow-1-strong"
              }
              style={{ width: "35px", height: "35px" }}
            >
              <p className={"text-white mb-0 small"}>% {product.percent}</p>
            </div>
          </div>
        ) : null}
        <img
          src={product.photos[0]}
          alt={product.name}
          className={"fluid p-3"}
          style={{ objectFit: "scale-down", height: "200px" }}
        />
        <CardBody className={"d-flex flex-column justify-content-end"}>
          <div className={"d-flex justify-content-between"}>
            <p className={"small"}>
              <Link to={"/product-details/" + product.id} color={"primary"}>
                {product.name.length > 100
                  ? product.name.substring(0, 100) + "..."
                  : product.name}
              </Link>
            </p>
          </div>
          <div className={"d-flex justify-content-between mb-3"}>
            <h5 className={"mb-0"}>{product.category}</h5>
            <h5 className={"text-dark mb-0 position-relative"}>
              {product.isDiscount ? (
                <>
                  ₽ {product.price - (product.price * product.percent) / 100}
                  <Badge
                    pill={true}
                    className={
                      "position-absolute translate-middle fw-normal text-decoration-line-through"
                    }
                    color={"transparent"}
                    style={{ left: "60%", top: "-5px" }}
                  >
                    <span className={"text-danger fs-12"}>
                      {"₽ " + product.price}
                    </span>
                  </Badge>
                </>
              ) : (
                "₽" + product.price
              )}
            </h5>
          </div>
          <div className={"d-flex justify-content-between mb-2"}>
            <p className={"text-muted mb-0"}>
              <Button
                color={"success"}
                className={"me-2"}
                onClick={() => handleCartAddClick(product)}
              >
                <i className={"bx bx-shopping-bag"}></i>
              </Button>
              <Link
                to={"/product-details/" + product.id}
                color={"outline-success"}
                className={"btn btn-outline-success"}
              >
                Подробнее
              </Link>
            </p>
            <div className={"ms-auto text-warning"}>
              <Rating
                initialRating={product.commonCharacteristic?.rate}
                emptySymbol={"mdi mdi-star-outline text-muted"}
                fullSymbol={"mdi mdi-star text-warning"}
                className={"me-1"}
              />
            </div>
          </div>
        </CardBody>
      </Card>
    </React.Fragment>
  );
};

export { ProductCardRow, ProductCardTable };
