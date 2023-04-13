import React, { useEffect, useState } from "react";
import {
  Button,
  Card,
  CardBody,
  Col,
  Form,
  Input,
  Row,
  Spinner,
  TabPane,
} from "reactstrap";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { useSelector } from "react-redux";

const CustomerInfo = ({ userId }) => {
  const [isLoading, setIsLoading] = useState(true);
  const [userData, setUserData] = useState([]);
  const [error, setError] = useState("");

  useEffect(() => {
    fetchWrapper
      .get("api/user/getuserbyid/" + userId)
      .then((response) => {
        setIsLoading(false);
        setUserData(response);
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  }, []);

  return (
    <React.Fragment>
      <TabPane tabId={1}>
        {isLoading ? (
          <div className="d-flex justify-content-center align-items-center">
            <div className="spinner-grow text-success" role="status">
              <span className="visually-hidden">Loading...</span>
            </div>
          </div>
        ) : (
          <Card>
            <CardBody>
              <h2>Информация о клиенте</h2>
              <Form className="form-horizontal">
                <div className="content-group">
                  <span className="text-muted fs-16">
                    Ваши персональные данные
                  </span>
                </div>
                <Row className="fs-16">
                  <Col lg={4}>
                    <label className="col-lg-3 col-form-label w-100">Пол</label>
                  </Col>
                  <Col lg={8}>
                    <div className="form-check form-check-inline">
                      <Input
                        type="radio"
                        className="form-check-input"
                        defaultValue={"M"}
                        defaultChecked={userData.gender === "M"}
                        id="gender-male"
                        name="gender"
                      />
                      <label className="form-check-label" htmlFor="gender-male">
                        Мужской
                      </label>
                    </div>
                    <div className="form-check form-check-inline">
                      <Input
                        type="radio"
                        className="form-check-input"
                        defaultValue={"F"}
                        defaultChecked={userData.gender === "F"}
                        id="gender-female"
                        name="gender"
                      />
                      <label
                        className="form-check-label"
                        htmlFor="gender-female"
                      >
                        Женский
                      </label>
                    </div>
                  </Col>
                  <Col lg={4}>
                    <label
                      className="col-lg-3 col-form-label w-100"
                      htmlFor="firstName"
                    >
                      Фамилия
                    </label>
                  </Col>
                  <Col lg={8} className="mb-3">
                    <Input
                      type="text"
                      className="form-control"
                      defaultValue={userData.firstName}
                      id="firstName"
                      name="firstName"
                      placeholder="Введите вашу фамилию"
                    />
                  </Col>
                  <Col lg={4}>
                    <label
                      className="col-lg-3 col-form-label"
                      htmlFor="secondName"
                    >
                      Имя
                    </label>
                  </Col>
                  <Col lg={8} className="mb-3">
                    <Input
                      type="text"
                      className="form-control"
                      defaultValue={userData.secondName}
                      id="secondName"
                      name="secondName"
                      placeholder="Введите ваше имя"
                    />
                  </Col>
                  <Col lg={4}>
                    <label
                      className="col-lg-3 col-form-label w-100"
                      htmlFor="lastName"
                    >
                      Отчество
                    </label>
                  </Col>
                  <Col md={8} className="mb-3">
                    <Input
                      type="text"
                      className="form-control"
                      defaultValue={userData.lastName}
                      id="lastName"
                      name="lastName"
                      placeholder="Введите ваше отчество"
                    />
                  </Col>
                  <Col lg={4}>
                    <label className="form-label">Дата рождения</label>
                  </Col>
                  <Col md={8} className="mb-3">
                    <div className="d-flex">
                      <Input
                        type="number"
                        className="form-control me-2"
                        name="day"
                        placeholder="День"
                      />
                      <Input
                        type="number"
                        className="form-control me-2"
                        name="month"
                        placeholder="Месяц"
                      />
                      <Input
                        type="number"
                        className="form-control"
                        name="year"
                        placeholder="Год"
                      />
                    </div>
                  </Col>
                  <Col lg={4}>
                    <label className="form-label">Почта</label>
                  </Col>
                  <Col lg={8}>
                    <Input
                      type="email"
                      className="form-control me-2"
                      name="email"
                      placeholder="Введите адрес электроной почты"
                      defaultValue={userData.email}
                    />
                  </Col>
                  {!userData.isConfirmedEmail ? (
                    <Col className="mb-3">Check</Col>
                  ) : (null)}
                  <Col lg={4}>
                    <label className="form-label">Телефон</label>
                  </Col>
                  <Col lg={8} className="mt-3 mb-3">
                    <Input
                      type="tel"
                      className="form-control me-2"
                      name="tel"
                      placeholder="Введите телефон"
                      defaultValue={userData.phone}
                    />
                  </Col>
                </Row>
                <div className="d-flex justify-content-end align-items-end">
                  <Button type="submit" className="btn btn-success">
                    <i className="ri-check-double-fill"></i> Сохранить
                  </Button>
                </div>
              </Form>
            </CardBody>
          </Card>
        )}
      </TabPane>
    </React.Fragment>
  );
};

export default CustomerInfo;
