import React from "react";
import { Link } from "react-router-dom";
import {
  Card,
  CardBody,
  CardHeader,
  Col,
  Container,
  Input,
  Label,
  Row,
} from "reactstrap";
import Select from "react-select";
import Popover from "../../../components/Popover/Popover";
import Breadcrumb from "../../../components/Breadcrumb/Breadcrumb";
import PreviewSingleImage from "../../components/Dropzone/PreviewSingleImage";

const CategoryAction = () => {
  return (
    <div className="page-content">
      <Container fluid>
        <Breadcrumb
          title={"Добавить"}
          pageTitle={"Катерии"}
          link={"/admin/categories"}
        />
        <Card>
          <CardHeader>
            <h3 className="fs-20 fw-bold">
              <Link className="btn btn-light" to="/admin/categories">
                <i className="ri-arrow-left-line"></i>
              </Link>{" "}
              Добавить новую категорию
            </h3>
          </CardHeader>
          <CardBody>
            <Row>
              <Col lg={12} className="mb-3">
                <Row className="align-items-center">
                  <Col xl={2}>
                    <Label className="form-label fw-bold">
                      Внешняя ссылка{" "}
                      <Popover
                        placement={"right"}
                        text={`
                            Альтернативная внешняя ссылка для этой категории в главном
                            меню и в списках категорий. Например, на целевую страницу, 
                            содержащую обратную ссылку на категорию.
                        `}
                        id={"externalLink"}
                      />
                    </Label>
                  </Col>
                  <Col xl={10}>
                    <Input
                      type="text"
                      name="externalLink"
                      className="form-control"
                      placeholder="Внешняя ссылка"
                      defaultValue={"" || ""}
                    />
                  </Col>
                </Row>
              </Col>
              <Col lg={12} className="mb-3">
                <Row className="align-items-center">
                  <Col xl={2}>
                    <Label className="form-label fw-bold">
                      Родительская категория{" "}
                      <Popover
                        placement={"right"}
                        text={`Выберите родительскую категорию для этой категории. Оставьте это поле пустым, чтобы сделать это категорией корневого уровня.`}
                        id={"parentItem"}
                      />
                    </Label>
                  </Col>
                  <Col xl={10}>
                    <Select />
                  </Col>
                </Row>
              </Col>
              <Col lg={12} className="mb-3">
                <Row className="align-items-center">
                  <Col xl={2}>
                    <Label className="form-label fw-bold">
                      Отобразить по порядку{" "}
                      <Popover
                        placement={"right"}
                        text={`Задает порядок отображения.  1 представляет вершину списка.`}
                        id={"displayOrder"}
                      />
                    </Label>
                  </Col>
                  <Col xl={10}>
                    <Input
                      type="number"
                      name="displayOrder"
                      className="form-control"
                      placeholder="Отобразить по порядку"
                      defaultValue={"" || ""}
                    />
                  </Col>
                </Row>
              </Col>
              <Col lg={12} className="mb-3">
                <Row className="align-items-center">
                  <Col xl={2}>
                    <Label className="form-label fw-bold">
                      Название{" "}
                      <Popover
                        placement={"right"}
                        text={`Название категории.`}
                        id={"name"}
                      />
                    </Label>
                  </Col>
                  <Col xl={10}>
                    <Input
                      type="text"
                      name="name"
                      className="form-control"
                      placeholder="Название"
                      defaultValue={"" || ""}
                    />
                  </Col>
                </Row>
              </Col>
              <Col lg={12} className="mb-3">
                <Row className="align-items-center">
                  <Col xl={2}>
                    <Label className="form-label fw-bold">
                      Полное имя{" "}
                      <Popover
                        placement={"right"}
                        text={`Полное имя отображается в качестве заголовка на странице категории.`}
                        id={"fullName"}
                      />
                    </Label>
                  </Col>
                  <Col xl={10}>
                    <Input
                      type="text"
                      name="fullName"
                      className="form-control"
                      placeholder="Полное имя"
                      defaultValue={"" || ""}
                    />
                  </Col>
                </Row>
              </Col>
              <Col lg={12} className="mb-3">
                <Row className="align-items-center">
                  <Col xl={2}>
                    <Label className="form-label fw-bold">
                      Категория{" "}
                      <Popover
                          placement={"right"}
                          text={`Название категории.`}
                          id={"category"}
                      />
                    </Label>
                  </Col>
                  <Col xl={10}>
                    <Select
                        name={"category"}
                        className={""}
                        // onChange={validation.handleChange}
                        // onBlur={validation.handleBlur}
                        defaultValue={[]} // validation.values.category
                    />
                  </Col>
                </Row>
              </Col>
              <Col lg={12} className="mb-3">
                <Row className="align-items-center">
                  <Col xl={2}>
                    <Label className="form-label fw-bold">
                      Текст значка{" "}
                      <Popover
                        placement={"right"}
                        text={`Получает или задает текст значка, который будет отображаться рядом со ссылкой на категорию в меню.`}
                        id={"badgeText"}
                      />
                    </Label>
                  </Col>
                  <Col xl={10}>
                    <Input
                      type="text"
                      name="badgeText"
                      className="form-control"
                      placeholder="Полное имя"
                      defaultValue={"" || ""}
                    />
                  </Col>
                </Row>
              </Col>
              <Col lg={12} className="mb-3">
                <Row className="align-items-center">
                  <Col xl={2}>
                    <Label className="form-label fw-bold">
                      Стиль значка{" "}
                      <Popover
                        placement={"right"}
                        text={`Получает или задает текст значка, который будет отображаться рядом со ссылкой на категорию в меню.`}
                        id={"badgeStyle"}
                      />
                    </Label>
                  </Col>
                  <Col xl={10}>
                    <Select />
                  </Col>
                </Row>
              </Col>
              <Col lg={12} className="mb-3">
                <Row className="align-items-center">
                  <Col xl={2}>
                    <Label className="form-label fw-bold">
                      Картинка{" "}
                      <Popover
                        placement={"right"}
                        text={`Картинка категории.`}
                        id={"image"}
                      />
                    </Label>
                  </Col>
                  <Col xl={10}>
                    <PreviewSingleImage />
                  </Col>
                </Row>
              </Col>
            </Row>
          </CardBody>
        </Card>
      </Container>
    </div>
  );
};

export default CategoryAction;
