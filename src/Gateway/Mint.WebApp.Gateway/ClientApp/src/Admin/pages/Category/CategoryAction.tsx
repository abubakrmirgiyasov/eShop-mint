import React, { FC, ReactNode, useState } from "react";
import { Error } from "../../../components/Notifications/Error";
import {
  Card,
  CardBody,
  CardHeader,
  Col,
  Container,
  Row,
  Spinner,
} from "reactstrap";
import BreadCrumb from "../../../components/Common/BreadCrumb";
import { Link, useParams } from "react-router-dom";
import ReactSelect, { StylesConfig } from "react-select";
import Popover from "../../../components/Common/Popover";
import { BadgeStyles, IBadgeStyle } from "../../../constants/commonList";
import chroma from "chroma-js";
import SingleImage from "../../../components/Dropzone/SingleImage";

const CategoryAction: FC<ReactNode> = () => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  const params = useParams();

  const dot = (color = "transparent") => ({
    alignItems: "center",
    display: "flex",
    ":before": {
      backgroundColor: color,
      borderRadius: 10,
      content: '" "',
      display: "block",
      marginRight: 8,
      height: 10,
      width: 10,
    },
  });

  const colorStyles: StylesConfig<IBadgeStyle> = {
    control: (styles) => ({ ...styles }),
    option: (styles, { data, isDisabled, isFocused, isSelected }) => {
      const color = chroma(data.color);
      return {
        ...styles,
        backgroundColor: isDisabled
          ? undefined
          : isSelected
          ? data.color
          : isFocused
          ? color.alpha(0.1).css()
          : undefined,
        color: isDisabled
          ? "#ccc"
          : isSelected
          ? chroma.contrast(color, "white") > 2
            ? "white"
            : "black"
          : data.color,
        cursor: isDisabled ? "not-allowed" : "default",
        ":active": {
          backgroundColor: !isDisabled
            ? isSelected
              ? data.color
              : color.alpha(0.3).css()
            : undefined,
        },
      };
    },
    input: (styles) => ({ ...styles, ...dot() }),
    placeholder: (styles) => ({ ...styles, ...dot("#ccc") }),
    singleValue: (styles, { data }) => ({ ...styles, ...dot(data.color) }),
  };

  return (
    <div className={"page-content"}>
      {error && <Error message={error} />}
      <Container fluid>
        <BreadCrumb
          currentPage={params.id ? "Изменить" : "Добавить"}
          linkToPage={"/admin/categories"}
          pageTitle={"Категории"}
        />
        <Card>
          <CardHeader>
            <h3 className={"fs-20 fw-bold mb-0"}>
              <Link to={"/admin/manufactures"} className={"btn btn-light me-2"}>
                <i className={"ri-arrow-left-line"}></i>
              </Link>{" "}
              {params.id ? "Изменить категорию" : "Добавить новую категорию"}
            </h3>
          </CardHeader>
          <CardBody>
            {isLoading ? (
              <div
                className={"d-flex justify-content-center align-items-center"}
              >
                <Spinner color={"success"} sm={"sm"}>
                  Loading...
                </Spinner>
              </div>
            ) : (
              <form>
                <Row>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label className={"form-label fw-bold mb-0"}>
                          Отобразить по порядку{" "}
                          <Popover
                            placement={"right"}
                            text={`Задает порядок отображения.  1 представляет вершину списка.`}
                            id={"displayOrder"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <input
                          type={"number"}
                          name={"displayOrder"}
                          className={"form-control"}
                          placeholder={"Отобразить по порядку"}
                          defaultValue={""}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label className={"form-label fw-bold mb-0"}>
                          Название{" "}
                          <Popover
                            placement={"right"}
                            text={"Здесь указывается название основного меню."}
                            id={"name"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <input
                          type={"text"}
                          id={"name"}
                          className={"form-control"}
                          placeholder={"Введите название"}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          htmlFor={"defaultLink"}
                        >
                          Ссылка по умолчанию
                          <Popover
                            id={"defaultLink"}
                            placement={"right"}
                            text={`
                              Альтернативная ссылка по умолчанию для этой категории в главном
                              меню и в списках категорий. Например, на страницу с продуктами, 
                              содержащую обратную ссылку на категорию.
                            `}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <input
                          type={"text"}
                          name={"defaultLink"}
                          className={"form-control"}
                          placeholder={"Ссылка по умолчанию (example/child)"}
                          defaultValue={""}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col className={"mb-3"} lg={12}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          id={"tags"}
                        >
                          Аттрибуты{" "}
                          <Popover
                            placement={"right"}
                            text={`Выберите несколько меток или характеристик для облегчения поиска.`}
                            id={"tags"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <ReactSelect
                          isMulti
                          options={[]}
                          isSearchable={true}
                          placeholder={"Выберите тегы для категории"}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          htmlFor={"child"}
                        >
                          Дочерные категории{" "}
                          <Popover
                            placement={"right"}
                            text={
                              "Если вы не выберете несколько дочерних категорий, то данное меню будет отображаться как главный."
                            }
                            id={"child"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <ReactSelect
                          className={"basic-select"}
                          placeholder={"Выберете дочерние категории"}
                          name={"child"}
                          options={[]}
                          isSearchable={true}
                          isMulti
                          // defaultValue={{}}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          htmlFor={"ico"}
                        >
                          Иконка
                          <Popover
                            id={"ico"}
                            placement={"right"}
                            text={
                              "Для выбора необходимой иконки меню, пожалуйста, нажмите на кнопку."
                            }
                          />
                        </label>
                      </Col>
                      <Col xl={9}>
                        <input
                          type={"text"}
                          readOnly={true}
                          className={"form-control"}
                          id={"ico"}
                          placeholder={"Поле для название иконки"}
                        />
                      </Col>
                      <Col xl={1}>
                        <button
                          type={"button"}
                          className={"btn btn-icon btn-outline-success w-100"}
                        >
                          <i className={"ri-table-line fs-18"}></i>
                        </button>
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          htmlFor={"badgeText"}
                        >
                          Текст значка
                          <Popover
                            id={"badgeText"}
                            placement={"right"}
                            text={
                              "Пожалуйста, предоставьте текст значка, который будет отображаться над названием меню."
                            }
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <input
                          type={"text"}
                          readOnly={true}
                          className={"form-control"}
                          id={"badgeText"}
                          placeholder={"Поле для название значка"}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          htmlFor={"badgeStyle"}
                        >
                          Стиль значка
                          <Popover
                            id={"badgeStyle"}
                            placement={"right"}
                            text={
                              "Пожалуйста, выберите цвет для заднего фона значка."
                            }
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <ReactSelect
                          className={"basic-select"}
                          id={"badgeStyle"}
                          placeholder={"Выберите цвет значка"}
                          options={BadgeStyles}
                          isSearchable={true}
                          styles={colorStyles}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label className={"form-label fw-bold mb-0"}>
                          Производитель{" "}
                          <Popover
                            placement={"right"}
                            text={`Название производителя.`}
                            id={"manufacture"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <ReactSelect
                          name={"manufacture"}
                          options={[]}
                          placeholder={"Выберете производителя"}
                          isSearchable={true}
                          isMulti
                          // defaultValue={}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label className={"form-label fw-bold mb-0"}>
                          Картинка{" "}
                          <Popover
                            placement={"right"}
                            text={`Картинка категории.`}
                            id={"image"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <SingleImage
                          currentImage={""}
                          name={""}
                          onChange={() => {}}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col
                    className={"d-flex justify-content-end align-items-center"}
                    xl={12}
                  >
                    <button type={"submit"} className={"btn btn-success"}>
                      {isLoading ? (
                        <Spinner size={"sm"} className={"me-2"}>
                          Loading...
                        </Spinner>
                      ) : (
                        <i className={"ri-check-double-fill me-2"}></i>
                      )}
                      Сохранить
                    </button>
                  </Col>
                </Row>
              </form>
            )}
          </CardBody>
        </Card>
      </Container>
    </div>
  );
};

export default CategoryAction;
