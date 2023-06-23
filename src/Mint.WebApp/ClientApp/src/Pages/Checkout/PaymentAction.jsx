import React from "react";
import {
  Button,
  Col,
  Form,
  Input,
  Label,
  Modal,
  ModalBody,
  Row,
} from "reactstrap";

const PaymentAction = ({ isOpen, toggle, close }) => {
  const handleCloseClick = () => {
    toggle();
    close();
  };

  return (
    <React.Fragment>
      <Modal isOpen={isOpen} centered={true} toggle={handleCloseClick}>
        <ModalBody className={"mb-0"}>
          <Row>
            <Col lg={4} className={"text-center"}>
              <Button className={"btn btn-icon w-50 fs-22"} color={"light"}>
                <i className={"ri-bank-card-line"}></i>
              </Button>
            </Col>
            <Col lg={4} className={"text-center"}>
              <Button className={"btn btn-icon w-50 fs-22"} color={"light"}>
                <i className={"ri-bank-card-line"}></i>
              </Button>
            </Col>
            <Col lg={4} className={"text-center"}>
              <Button className={"btn btn-icon w-50 fs-22"} color={"light"}>
                <i className={"ri-bank-card-line"}></i>
              </Button>
            </Col>
          </Row>
          <div className={"signin-other-title mt-3 mb-3"}>
            <h5 className={"fs-13 title"}>
              или оплатить с помощью кредитной карты
            </h5>
          </div>
          <Form>
            <Row>
              <Col lg={12} className={"mb-3"}>
                <Label htmlFor={"cardHolder"}>Полное имя держателя карты</Label>
                <Input
                  type={"text"}
                  id={"cardHolder"}
                  className={"form-control"}
                  placeholder={"Введите полное имя"}
                />
              </Col>
              <Col lg={12} className={"mb-3"}>
                <Label htmlFor={"cardNumber"}>Номер карты</Label>
                <Input
                  type={"text"}
                  id={"cardNumber"}
                  className={"form-control"}
                  placeholder={"Введите номер карты"}
                />
              </Col>
              <Col lg={8} className={"mb-3"}>
                <Label htmlFor={"expiresDate"}>Срок годности</Label>
                <Input
                  type={"text"}
                  id={"expiresDate"}
                  className={"form-control"}
                  placeholder={"01/23"}
                />
              </Col>
              <Col lg={4} className={"mb-3"}>
                <Label htmlFor={"cvv"}>CVV</Label>
                <Input
                  type={"password"}
                  id={"cvv"}
                  className={"form-control"}
                  placeholder={"CVV"}
                />
              </Col>
            </Row>
            <Button className={"btn btn-primary w-100"} color={"primary"}>
              Оформить
            </Button>
          </Form>
        </ModalBody>
      </Modal>
    </React.Fragment>
  );
};

export default PaymentAction;
