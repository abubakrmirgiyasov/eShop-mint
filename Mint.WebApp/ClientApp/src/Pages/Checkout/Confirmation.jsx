import React, { useState } from "react";
import {
  Button,
  Card,
  CardBody,
  CardHeader,
  Col,
  Container,
  Input,
  Label,
  Row,
  Spinner,
  TabPane,
} from "reactstrap";
import { Error } from "../../components/Notification/Error";
import { Success } from "../../components/Notification/Success";
import { Link } from "react-router-dom";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { CKEditor } from "@ckeditor/ckeditor5-react";
import { useSelector } from "react-redux";
import { fetchWrapper } from "../../helpers/fetchWrapper";

const Confirmation = ({
  userId,
  next,
  address,
  cartData,
  shipping,
  payment,
  setNewOrder,
}) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);
  const [agree, setAgree] = useState(false);
  const [description, setDescription] = useState("");

  const handleNextClick = () => {
    setIsLoading(true);

    const data = {
      userId: userId,
      orderProducts: cartData.map((item) => {
        return { id: item.id, quantity: item.quantity };
      }),
      paymentType: payment.payment,
      shippingType: shipping.shipping,
      address: address.id,
    };

    console.log(data);

    fetchWrapper
      .post("api/order/createorder", data)
      .then((response) => {
        setIsLoading(false);
        setNewOrder(response);
        next(6);
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  };

  const handlePrevClick = () => {
    next(4);
  };

  const handleAgreeClick = () => {
    setAgree(!agree);
  };

  return (
    <React.Fragment>
      {error ? <Error message={error} /> : null}
      {success ? <Success message={success} /> : null}
      <TabPane tabId={5}>
        <div className={"d-flex justify-content-between"}>
          <h3>Пожалуйста, подтвердите ваш заказ.</h3>
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
              disabled={!agree}
            >
              {isLoading ? (
                <Spinner size={"sm"}>Loading...</Spinner>
              ) : (
                <i className={"ri-arrow-right-line"}></i>
              )}
            </Button>
          </div>
        </div>
        <Container className={"mt-3"}>
          <p className={"text-muted"}>
            Пожалуйста, проверьте общую сумму заказа и специфику платежного
            адреса и, при необходимости, адреса доставки. Вы можете внести
            исправления в свою запись в любое время, нажав кнопку «
            <span className={"fw-bold"}>Назад</span>» . Если все в порядке,
            доставьте нам свой заказ, нажав «
            <span className={"fw-bold"}>Подтвердить</span>» .
          </p>
          <Card className={"bg-light mb-2"}>
            <CardBody>
              <div className={"form-check mb-0"}>
                <Input
                  className={"form-check-input"}
                  id={"confirm"}
                  type={"checkbox"}
                  onChange={handleAgreeClick}
                />
                <Label className={"form-check-label"} htmlFor={"confirm"}>
                  Я согласен с{" "}
                  <Link to={"/"} color={"primary"}>
                    условиями предоставления услуг
                  </Link>{" "}
                  и безоговорочно их придерживаюсь. Я ознакомился с{" "}
                  <Link to={"/"} color={"primary"}>
                    условиями конфиденциальности и
                  </Link>{" "}
                  с тем, что предоставленные мной данные могут храниться в
                  электронном виде.
                </Label>
              </div>
            </CardBody>
          </Card>
          <Card className={"bg-light"}>
            <CardBody>
              <Row>
                <Col lg={4}>
                  <h4 className={"fs-14 fw-semibold"}>Адрес доставки</h4>
                  <p>
                    Страна:{" "}
                    <span className={"fw-semibold"}>{address?.country}</span>
                  </p>
                  <p>
                    Город:{" "}
                    <span className={"fw-semibold"}>{address?.city}</span>
                  </p>
                  <p>
                    Улица:{" "}
                    <span className={"fw-semibold"}>{address?.street}</span>
                  </p>
                  <p>
                    Почтовый индекс:{" "}
                    <span className={"fw-semibold"}>{address?.zipCode}</span>
                  </p>
                </Col>
                <Col lg={4}>
                  <h4 className={"fs-14 fw-semibold"}>Способ доставки</h4>
                  <p>{shipping?.shipping}</p>
                </Col>
                <Col lg={4}>
                  <h4 className={"fs-14 fw-semibold"}>Способ оплаты</h4>
                  <p>{payment?.payment}</p>
                </Col>
              </Row>
            </CardBody>
          </Card>
          <Card>
            <CardHeader className={"bg-light"}>
              Вы хотите что-то рассказать нам об этом заказе?
            </CardHeader>
            <CardBody>
              <CKEditor
                editor={ClassicEditor}
                id="text"
                onChange={(event, editor) => {
                  setDescription(editor.getData());
                }}
                data={""}
              />
            </CardBody>
          </Card>
          <Card>
            <CardHeader className={"bg-light"}>name</CardHeader>
            <CardBody>
              {cartData.map((item, key) => (
                <div className={""} key={key}>
                  {item.name}
                </div>
              ))}
            </CardBody>
          </Card>
        </Container>
      </TabPane>
    </React.Fragment>
  );
};

export default Confirmation;
