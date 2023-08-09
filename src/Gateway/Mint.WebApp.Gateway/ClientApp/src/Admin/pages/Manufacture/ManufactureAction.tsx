import React, { FC, ReactNode, useState } from "react";
import {
  Card,
  CardBody,
  CardHeader,
  Col,
  Container,
  Row,
  Spinner,
} from "reactstrap";
import { Link, useParams } from "react-router-dom";
import { Error } from "../../../components/Notifications/Error";
import BreadCrumb from "../../../components/Common/BreadCrumb";
import Popover from "../../../components/Common/Popover";
import ReactSelect from "react-select";
import PhoneInput from "react-phone-input-2";
import SingleImage from "../../../components/Dropzone/SingleImage";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { CKEditor } from "@ckeditor/ckeditor5-react";
import { Countries } from "../../../constants/commonList";

interface IManufactureAction {}

const ManufactureAction: FC<ReactNode> = () => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  const [manufacturesIsLoading, setManufacturesIsLoading] =
    useState<boolean>(false);

  const params = useParams();

  return (
    <div className={"page-content"}>
      {error && <Error message={error} />}
      <Container fluid>
        <BreadCrumb
          currentPage={
            !params.id
              ? "Добавить нового производителя"
              : "Изменить производителя"
          }
          linkToPage={"/admin/manufactures"}
          pageTitle={"Производители"}
        />
        <Card>
          <CardHeader>
            <h3 className={"fs-20 fw-bold"}>
              <Link to={"/admin/manufactures"} className={"btn btn-light me-2"}>
                <i className={"ri-arrow-left-line"}></i>
              </Link>{" "}
              {!params.id
                ? "Добавить нового производителя"
                : "Изменить пользователя"}
            </h3>
          </CardHeader>
          <CardBody>
            {params.id && manufacturesIsLoading ? (
              <div
                className={"d-flex justify-content-center align-items-center"}
              >
                <Spinner size={"sm"} color={"success"}>
                  Loading...
                </Spinner>
              </div>
            ) : (
              <Row>
                <form>
                  <Col className={"mb-3"} lg={12}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          id={"displayNumber"}
                        >
                          Отобразить по порядку{" "}
                          <Popover
                            placement={"right"}
                            text={`Задает порядок отображения.  1 представляет вершину списка`}
                            id={"displayOrder"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <input
                          className={"form-control"}
                          type={"number"}
                          id={"displayNumber"}
                          placeholder={"Введите число"}
                          min={0}
                          max={999}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col className={"mb-3"} lg={12}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          id={"name"}
                        >
                          Название{" "}
                          <Popover
                            placement={"right"}
                            text={"Имя или название компании-производителя"}
                            id={"name"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <input
                          className={"form-control"}
                          type={"text"}
                          id={"name"}
                          placeholder={"Введите название"}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col className={"mb-3"} lg={12}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          id={"country"}
                        >
                          Страна{" "}
                          <Popover
                            placement={"right"}
                            text={`Выберите страну производителя из раскрывающегося списка.`}
                            id={"country"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <ReactSelect
                          id={"country"}
                          placeholder={"Выберите страну"}
                          options={Countries}
                          isSearchable={true}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col className={"mb-3"} lg={12}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          id={"email"}
                        >
                          Email{" "}
                          <Popover
                            placement={"right"}
                            text={
                              "Поле для указания электронной почты производителя."
                            }
                            id={"email"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <input
                          className={"form-control"}
                          type={"text"}
                          id={"email"}
                          placeholder={"Введите адрес электроной почты"}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col className={"mb-3"} lg={12}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          id={"phone"}
                        >
                          Телефон{" "}
                          <Popover
                            placement={"right"}
                            text={`Место для ввода контактного номера производителя.`}
                            id={"phone"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <PhoneInput
                          inputClass={"w-100"}
                          type={"number"}
                          id={"displayNumber"}
                          country={"ru"}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col className={"mb-3"} lg={12}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          id={"website"}
                        >
                          Сайт{" "}
                          <Popover
                            placement={"right"}
                            text={`Веб-сайт или ссылка на ресурс, связанный с производителем.`}
                            id={"website"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <input
                          className={"form-control"}
                          type={"text"}
                          id={"website"}
                          placeholder={"Введите ссылку на ресурс"}
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
                          placeholder={"Выберите тегы для производителя"}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col className={"mb-3"} lg={12}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          id={"fullAddress"}
                        >
                          Полный адрес{" "}
                          <Popover
                            placement={"right"}
                            text={`В этом поле указывается местоположение офиса производителя.`}
                            id={"fullAddress"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <input
                          className={"form-control"}
                          type={"text"}
                          id={"fullAddress"}
                          placeholder={"Введите полный адрес"}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col className={"mb-3"} lg={12}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          id={"photo"}
                        >
                          Картинка{" "}
                          <Popover
                            placement={"right"}
                            text={`Перенесите или выберите изображение логотипа производителя.`}
                            id={"photo"}
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
                  <Col className={"mb-3"} lg={12}>
                    <Row className={"align-items-center mb-0"}>
                      <Col xl={2}>
                        <label className={"form-label fw-bold"} id={"photo"}>
                          Описание{" "}
                          <Popover
                            placement={"right"}
                            text={`Область для сжатого изложения информации о производителе.`}
                            id={"photo"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <CKEditor
                          editor={ClassicEditor}
                          id={"text"}
                          onChange={(event, editor) => {
                            // validation.values.description = editor.getData();
                          }}
                          data={""}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col
                    lg={12}
                    className={"d-flex justify-content-end align-items-end"}
                  >
                    <button
                      className={"btn btn-success"}
                      type={"submit"}
                      disabled={isLoading}
                    >
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
                </form>
              </Row>
            )}
          </CardBody>
        </Card>
      </Container>
    </div>
  );
};

export default ManufactureAction;
