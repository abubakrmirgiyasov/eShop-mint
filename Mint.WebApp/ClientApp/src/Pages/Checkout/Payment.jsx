import React, { useCallback, useState } from "react";
import {
  Button,
  Container,
  Input,
  Label,
  ListGroup,
  ListGroupItem,
  TabPane,
} from "reactstrap";
import { Error } from "../../components/Notification/Error";
import { Success } from "../../components/Notification/Success";
import PaymentAction from "./PaymentAction";

const Payment = ({ next, setPayment }) => {
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);
  const [paymentDetail, setPaymentDetail] = useState(null);
  const [isOpen, setIsOpen] = useState(false);

  const handleNextClick = () => {
    setPayment(paymentDetail);
    next(5);
  };

  const handlePrevClick = () => {
    next(3);
  };

  const handleCreditCardClick = () => {
    setIsOpen(true);
  };

  const toggle = useCallback(() => {
    if (isOpen) {
      setIsOpen(false);
    } else {
      setIsOpen(true);
    }
  }, [isOpen]);

  const handleCloseClick = () => {
    setPaymentDetail({ payment: "Оплата при доставке" });
  };

  return (
    <React.Fragment>
      {error ? <Error message={error} /> : null}
      {success ? <Success message={success} /> : null}
      <TabPane tabId={4}>
        <div className={"d-flex justify-content-between"}>
          <h3>Выберите способ оплаты</h3>
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
              disabled={paymentDetail === null}
            >
              <i className={"ri-arrow-right-line"}></i>
            </Button>
          </div>
        </div>
        <Container className={"mt-3"}>
          <ListGroup>
            <ListGroupItem
              color={
                paymentDetail?.payment === "Оплата при доставке"
                  ? "warning"
                  : ""
              }
              style={{ height: "100px" }}
            >
              <div className="form-check mb-2 mt-3">
                <Input
                  className={"form-check-input"}
                  type={"radio"}
                  name={"payment"}
                  id={"ship"}
                  onChange={() =>
                    setPaymentDetail({ payment: "Оплата при доставке" })
                  }
                  checked={paymentDetail?.payment === "Оплата при доставке"}
                />
                <Label className={"form-check-label"} htmlFor={"ship"}>
                  Оплата при доставке
                </Label>
              </div>
              <p className={"text-muted"}>
                После оформления заказа наши сотрудники свяжутся с вами для
                подтверждения заказа.
              </p>
            </ListGroupItem>
            <ListGroupItem
              color={
                paymentDetail?.payment === "Кредитная карта (вручную)"
                  ? "warning"
                  : ""
              }
              style={{ height: "100px" }}
            >
              <div className={"form-check mt-sm-4"}>
                <Input
                  className={"form-check-input"}
                  type={"radio"}
                  name={"payment"}
                  id={"card"}
                  onChange={() =>
                    setPaymentDetail({ payment: "Кредитная карта (вручную)" })
                  }
                  onClick={handleCreditCardClick}
                  checked={
                    paymentDetail?.payment === "Кредитная карта (вручную)"
                  }
                />
                <Label className={"form-check-label"} htmlFor={"card"}>
                  Кредитная карта (вручную)
                </Label>
              </div>
            </ListGroupItem>
          </ListGroup>
        </Container>
        <PaymentAction
          isOpen={isOpen}
          toggle={toggle}
          close={handleCloseClick}
        />
      </TabPane>
    </React.Fragment>
  );
};

export default Payment;
