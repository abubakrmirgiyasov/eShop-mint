import React, { useCallback, useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import {
  Button,
  Card,
  CardBody,
  CardHeader,
  Col,
  Container,
  Form,
  Input,
  Label,
  Row,
  Spinner,
} from "reactstrap";
import Select from "react-select";
import Popover from "../../../components/Popover/Popover";
import Breadcrumb from "../../../components/Breadcrumb/Breadcrumb";
import PreviewSingleImage from "../../components/Dropzone/PreviewSingleImage";
import { BadgesStyle } from "../../../constants/Common";
import { fetchWrapper } from "../../../helpers/fetchWrapper";
import { Error } from "../../../components/Notification/Error";
import SubCategories from "../SubCategory/SubCategories";

const CategoryAction = ({ handleNewData }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [manufactures, setManufactures] = useState([]);
  const [subCategories, setSubCategories] = useState(false);
  const [parentData, setParentData] = useState([]);
  const [setSelectedImage, setSetSelectedImage] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    setIsLoading(true);

    fetchWrapper
      .get("api/subcategory/getsubcategoriesonly")
      .then((response) => setParentData(response))
      .catch((error) => setError(error));

    fetchWrapper
      .get("api/manufacture/getonlymanufactures")
      .then((response) => {
        setIsLoading(false);
        setManufactures(response);
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  }, []);

  const toggle = useCallback(() => {
    if (subCategories) {
      setSubCategories(false);
    } else {
      setSubCategories(true);
    }
  }, [subCategories]);

  const handleSubmit = (e) => {
    setIsLoading(true);

    const formData = new FormData();
    // formData.append("externalLink", e.target.externalLink.value);
    formData.append("subCategoryId", e.target.subCategory.value);
    formData.append("displayOrder", e.target.displayOrder.value);
    formData.append("name", e.target.name.value);
    formData.append("fullName", e.target.fullName.value);
    formData.append("manufactureId", e.target.manufacture.value);
    formData.append("badgeText", e.target.badgeText.value);
    formData.append("badgeStyle", e.target.badgeStyle.value);

    if (setSelectedImage) {
      formData.append("photo", setSelectedImage[0]);
      formData.append("fileType", "category");
    }
    fetchWrapper
      .post("api/category/addcategory", formData, false)
      .then((response) => {
        setIsLoading(false);
        handleNewData(response);
        navigate("/api/category");
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  };

  function handleSetSelectedImage(image) {
    setSetSelectedImage(image);
  }

  return (
    <div className="page-content">
      {error ? <Error message={error} /> : null}
      <Container fluid>
        <Breadcrumb
          title={"Добавить"}
          pageTitle={"Катерии"}
          link={"/admin/categories"}
        />
        <Card>
          <CardHeader>
            <h3 className={"fs-20 fw-bold"}>
              <div
                className={"d-flex justify-content-start align-items-center"}
              >
                <Link className={"btn btn-light me-2"} to={"/admin/categories"}>
                  <i className={"ri-arrow-left-line"}></i>
                </Link>{" "}
                Добавить новую категорию
              </div>
            </h3>
          </CardHeader>
          <CardBody>
            {isLoading ? (
              <div
                className={"d-flex justify-content-center align-items-center"}
              >
                <div className={"spinner-grow text-success"} role={"status"}>
                  <span className={"visually-hidden"}>Loading...</span>
                </div>
              </div>
            ) : (
              <Form
                onSubmit={(e) => {
                  e.preventDefault();
                  handleSubmit(e);
                  return false;
                }}
              >
                <Row>
                  {/*<Col lg={12} className={"mb-3"}>*/}
                  {/*  <Row className={"align-items-center"}>*/}
                  {/*    <Col xl={2}>*/}
                  {/*      <Label className={"form-label fw-bold"}>*/}
                  {/*        Внешняя ссылка{" "}*/}
                  {/*        <Popover*/}
                  {/*          placement={"right"}*/}
                  {/*          text={`*/}
                  {/*          Альтернативная внешняя ссылка для этой категории в главном*/}
                  {/*          меню и в списках категорий. Например, на целевую страницу, */}
                  {/*          содержащую обратную ссылку на категорию.*/}
                  {/*      `}*/}
                  {/*          id={"externalLink"}*/}
                  {/*        />*/}
                  {/*      </Label>*/}
                  {/*    </Col>*/}
                  {/*    <Col xl={10}>*/}
                  {/*      <Input*/}
                  {/*        type={"text"}*/}
                  {/*        name={"externalLink"}*/}
                  {/*        className={"form-control"}*/}
                  {/*        placeholder={"Внешняя ссылка"}*/}
                  {/*        defaultValue={"" || ""}*/}
                  {/*      />*/}
                  {/*    </Col>*/}
                  {/*  </Row>*/}
                  {/*</Col>*/}
                  <Col lg={12}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <Label className={"form-label fw-bold"}>
                          Родительская категория{" "}
                          <Popover
                            placement={"right"}
                            text={`Выберите родительскую категорию для этой категории. Оставьте это поле пустым, чтобы сделать это категорией корневого уровня.`}
                            id={"parentItem"}
                          />
                        </Label>
                      </Col>
                      <Col xl={8} className={"mb-3"}>
                        <Select
                          className={"basic-select"}
                          placeholder={"Выберете родителя"}
                          name={"subCategory"}
                          options={parentData || []}
                          defaultValue={[]}
                        />
                      </Col>
                      <Col xl={2} className={"mb-3"}>
                        <Button
                          type={"button"}
                          className={"btn btn-icon fs-16 w-100"}
                          color={"primary"}
                          onClick={toggle}
                        >
                          <i className={"ri-table-line"}></i>
                        </Button>
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <Label className={"form-label fw-bold"}>
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
                          type={"number"}
                          name={"displayOrder"}
                          className={"form-control"}
                          placeholder={"Отобразить по порядку"}
                          defaultValue={"" || ""}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <Label className={"form-label fw-bold"}>
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
                          type={"text"}
                          name={"name"}
                          className={"form-control"}
                          placeholder={"Название"}
                          defaultValue={"" || ""}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <Label className={"form-label fw-bold"}>
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
                          type={"text"}
                          name={"fullName"}
                          className={"form-control"}
                          placeholder={"Полное имя"}
                          defaultValue={"" || ""}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <Label className={"form-label fw-bold"}>
                          Производитель{" "}
                          <Popover
                            placement={"right"}
                            text={`Название производителя.`}
                            id={"manufacture"}
                          />
                        </Label>
                      </Col>
                      <Col xl={10}>
                        <Select
                          name={"manufacture"}
                          className={""}
                          options={manufactures}
                          // onChange={validation.handleChange}
                          // onBlur={validation.handleBlur}
                          defaultValue={[]} // validation.values.category
                          placeholder={"Выберете производителя"}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <Label className={"form-label fw-bold"}>
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
                          type={"text"}
                          name={"badgeText"}
                          className={"form-control"}
                          placeholder={"Полное имя"}
                          defaultValue={"" || ""}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <Label className={"form-label fw-bold"}>
                          Стиль значка{" "}
                          <Popover
                            placement={"right"}
                            text={`Получает или задает текст значка, который будет отображаться рядом со ссылкой на категорию в меню.`}
                            id={"badgeStyle"}
                          />
                        </Label>
                      </Col>
                      <Col xl={10}>
                        <Select
                          name={"badgeStyle"}
                          options={BadgesStyle}
                          placeholder={"Выберете цвет"}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <Label className={"form-label fw-bold"}>
                          Картинка{" "}
                          <Popover
                            placement={"right"}
                            text={`Картинка категории.`}
                            id={"image"}
                          />
                        </Label>
                      </Col>
                      <Col xl={10}>
                        <PreviewSingleImage
                          setSelectedImage={handleSetSelectedImage}
                          image={[]}
                          name={[]}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col
                    className={"d-flex justify-content-end align-items-center"}
                    xl={12}
                  >
                    <Button
                      type={"submit"}
                      color={"primary"}
                      className={"btn btn-primary"}
                    >
                      {isLoading ? (
                        <Spinner size={"sm"} className="me-2">
                          Loading...
                        </Spinner>
                      ) : null}
                      Сохранить
                    </Button>
                  </Col>
                </Row>
              </Form>
            )}
          </CardBody>
        </Card>
      </Container>
      <SubCategories isOpen={subCategories} toggle={toggle} />
    </div>
  );
};

export default CategoryAction;
