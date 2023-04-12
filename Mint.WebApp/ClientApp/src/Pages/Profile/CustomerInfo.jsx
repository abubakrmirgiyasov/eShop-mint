import React from "react";
import {
  Button,
  Card,
  CardBody,
  Col,
  Form,
  Input,
  Row,
  TabPane,
} from "reactstrap";

const CustomerInfo = () => {
  return (
    <React.Fragment>
      <TabPane tabId={1}>
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
                  <div>
                    <div className="form-check form-check-inline">
                      <Input
                        type="radio"
                        className="form-check-input"
                        defaultValue={"M"}
                        id="gender-male"
                        name="Gender"
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
                    defaultValue={""}
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
                    defaultValue={""}
                    id="secondName"
                    name="secondName"
                    placeholder="Введите ваше имя"
                  />
                </Col>
                <Col lg={4}>
                  <label className="col-lg-3 col-form-label w-100" htmlFor="lastName">
                    Отчество
                  </label>
                </Col>
                <Col md={8} className="mb-3">
                  <Input
                    type="text"
                    className="form-control"
                    defaultValue={""}
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
                <Col lg={8} className="mb-3">
                  <Input
                    type="email"
                    className="form-control me-2"
                    name="email"
                    placeholder="Введите адрес электроной почты"
                  />
                </Col>
                <Col lg={4}>
                  <label className="form-label">Телефон</label>
                </Col>
                <Col lg={8} className="mb-3">
                  <Input
                    type="tel"
                    className="form-control me-2"
                    name="tel"
                    placeholder="Введите телефон"
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
      </TabPane>
    </React.Fragment>
  );
};

export default CustomerInfo;
