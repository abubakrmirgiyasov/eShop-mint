import React, { useState } from "react";
import { Error } from "../../components/Notification/Error";
import { Success } from "../../components/Notification/Success";
import {
  Button,
  Container,
  Input,
  Label,
  ListGroup,
  ListGroupItem,
  TabPane,
} from "reactstrap";

const Shipping = ({ next, setShipping }) => {
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);
  const [shippingDetail, setShippingDetail] = useState(null);

  const handleNextClick = () => {
    setShipping(shippingDetail);
    next(4);
  };

  const handlePrevClick = () => {
    next(2);
  };

  return (
    <React.Fragment>
      {error ? <Error message={error} /> : null}
      {success ? <Success message={success} /> : null}
      <TabPane tabId={3}>
        <div className={"d-flex justify-content-between"}>
          <h3>Выберите способ доставки</h3>
          <div>
            <Button
              color={"outline-primary"}
              className={"btn btn-outline-primary btn-icon me-2"}
              onClick={handlePrevClick}
            >
              <i className={"ri-arrow-left-line"}></i>
            </Button>
            <Button
              color={"primary"}
              className={"btn btn-primary btn-icon"}
              onClick={handleNextClick}
              disabled={shippingDetail === null}
            >
              <i className={"ri-arrow-right-line"}></i>
            </Button>
          </div>
        </div>
        <Container className={"mt-3"}>
          <ListGroup>
            <ListGroupItem
              color={
                shippingDetail?.shipping === "Самовывоз в магазине"
                  ? "warning"
                  : ""
              }
              style={{ height: "100px" }}
            >
              <div className={"form-check mb-2 mt-3"}>
                <Input
                  className={"form-check-input"}
                  type={"radio"}
                  name={"shipping"}
                  id={"store"}
                  onChange={() =>
                    setShippingDetail({ shipping: "Самовывоз в магазине" })
                  }
                />
                <Label className={"form-check-label"} htmlFor={"store"}>
                  Самовывоз в магазине
                </Label>
              </div>
              <p className={"text-muted"}>Забрать свои вещи в магазине</p>
            </ListGroupItem>
            <ListGroupItem
              color={shippingDetail?.shipping === "На дом" ? "warning" : ""}
              style={{ height: "100px" }}
            >
              <div className={"form-check mt-3 mb-2"}>
                <Input
                  className={"form-check-input"}
                  type={"radio"}
                  name={"shipping"}
                  id={"home"}
                  onChange={() => setShippingDetail({ shipping: "На дом" })}
                />
                <Label className={"form-check-label"} htmlFor={"home"}>
                  На дом
                </Label>
              </div>
              <p className={"text-muted mb-0"}>Доставляем сразу на дом.</p>
            </ListGroupItem>
          </ListGroup>
        </Container>
      </TabPane>
    </React.Fragment>
  );
};

export default Shipping;
