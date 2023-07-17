import React, { FC, useState } from "react";
import { IUser } from "../../services/types/IUser";
import {
  Card,
  CardBody,
  Col,
  Form,
  Input,
  Label,
  Row,
  Spinner,
  TabPane,
} from "reactstrap";
import { Link } from "react-router-dom";
import CustomDivider from "../../components/Common/CustomDivider";

interface ICustomerInfo {
  user: IUser;
  activeTab: number;
}

const CustomerInfo: FC<ICustomerInfo> = ({ user, activeTab }) => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [isEdit, setIsEdit] = useState<boolean>(true);

  return (
    <React.Fragment>
      <TabPane tabId={1}>
        {isLoading ? (
          <Spinner size={"sm"} />
        ) : (
          <Card>
            <CardBody>
              <h2>Личная информация</h2>
              <CustomDivider />
              <Form className={"form-horizontal"}>
                <div className={"content-group"}>
                  <span className={"text-muted fs-16"}>
                    Ваши персональные данные
                  </span>
                </div>
                <Row className={"fs-14"} style={{ gap: "1em 0" }}>
                  <Col lg={4}>
                    <Label className={"col-lg-3 col-form-label w-100"}>
                      Пол
                    </Label>
                  </Col>
                  <Col lg={8}>
                    <div className={"form-check form-check-inline"}>
                      <Input
                        type={"radio"}
                        name={"gender"}
                        id={"gender-male"}
                        defaultValue={"M"}
                        defaultChecked={user?.gender === "M"}
                        disabled={isEdit}
                        label={"Мужской"}
                      />
                    </div>
                    <div className={"form-check form-check-inline"}>
                      <Input
                        type={"radio"}
                        name={"gender"}
                        id={"gender-male"}
                        defaultValue={"F"}
                        defaultChecked={user?.gender === "F"}
                        disabled={isEdit}
                        label={"Женский"}
                      />
                    </div>
                    <div className={"form-check form-check-inline"}>
                      <Input
                        type={"radio"}
                        name={"gender"}
                        id={"gender-male"}
                        defaultValue={"N"}
                        defaultChecked={user?.gender === "N"}
                        disabled={isEdit}
                        label={"Не указать"}
                      />
                    </div>
                  </Col>
                  <Col lg={4}>
                    <label
                      className={"col-lg-3 col-form-label w-100"}
                      htmlFor={"firstName"}
                    >
                      Фамилия
                    </label>
                  </Col>
                  <Col lg={8}>
                    <Input
                      type={"text"}
                      name={"firstName"}
                      id={"firstName"}
                      placeholder={"Введите вашу фамилию"}
                      required={true}
                      value={user?.firstName || ""}
                      disabled={isEdit}
                    />
                  </Col>
                  <Col lg={4}>
                    <label
                      className={"col-lg-3 col-form-label w-100"}
                      htmlFor={"secondName"}
                    >
                      Имя
                    </label>
                  </Col>
                  <Col lg={8}>
                    <Input
                      type={"text"}
                      name={"secondName"}
                      id={"secondName"}
                      placeholder={"Введите ваше имя"}
                      required={true}
                      value={user?.secondName || ""}
                      disabled={isEdit}
                    />
                  </Col>
                  <Col lg={4}>
                    <label
                      className={"col-lg-3 col-form-label w-100"}
                      htmlFor={"secondName"}
                    >
                      Отчество
                    </label>
                  </Col>
                  <Col lg={8}>
                    <Input
                      type={"text"}
                      name={"lastName"}
                      id={"lastName"}
                      placeholder={"Введите ваше отчество"}
                      required={false}
                      value={user?.lastName || ""}
                      disabled={isEdit}
                    />
                  </Col>
                  <Col lg={4}>
                    <label
                      className={"form-label col-lg-3 col-form-label w-100"}
                      htmlFor={"dateBirth"}
                    >
                      Дата рождения
                    </label>
                  </Col>
                  <Col md={8}>
                    <Input
                      type={"date"}
                      name={"dateBirth"}
                      id={"dateBirth"}
                      value={user?.dateBirth || ""}
                      disabled={isEdit}
                      required={true}
                    />
                  </Col>
                  <Col lg={4}>
                    <label
                      className={"form-label col-lg-3 col-form-label w-100"}
                      htmlFor={"email"}
                    >
                      Почта
                    </label>
                  </Col>
                  <Col md={8}>
                    <Input
                      type={"email"}
                      name={"email"}
                      id={"email"}
                      value={user?.email || ""}
                      disabled={isEdit}
                      required={true}
                    />
                  </Col>
                  {!user?.isEmailConfirmed && (
                    <>
                      <Col lg={4}>Подтвердите почту</Col>
                      <Col lg={8}>
                        <Link
                          to={"/confirm-email"}
                          className={"text-decoration-underline"}
                        >
                          Подтвердить сейчас
                        </Link>
                      </Col>
                    </>
                  )}
                  <Col lg={4}>
                    <label
                      className={"form-label col-lg-3 col-form-label w-100"}
                      htmlFor={"phone"}
                    >
                      Телефон
                    </label>
                  </Col>
                  <Col md={8}>
                    <Input
                      type={"tel"}
                      name={"phone"}
                      id={"phone"}
                      value={user?.phone || ""}
                      disabled={isEdit}
                      required={true}
                    />
                  </Col>
                  {!user?.isPhoneConfirmed && (
                    <>
                      <Col lg={4}>Подтвердите телефон</Col>
                      <Col lg={8}>
                        <Link
                          to={"/confirm-phone"}
                          className={"text-decoration-underline"}
                        >
                          Подтвердить сейчас
                        </Link>
                      </Col>
                    </>
                  )}
                </Row>
              </Form>
            </CardBody>
          </Card>
        )}
      </TabPane>
    </React.Fragment>
  );
};

export default CustomerInfo;
