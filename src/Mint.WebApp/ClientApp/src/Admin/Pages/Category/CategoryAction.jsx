import React, { useCallback, useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
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

const CategoryAction = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [manufactures, setManufactures] = useState([]);
  const [subCategories, setSubCategories] = useState(false);
  const [parentData, setParentData] = useState([]);
  const [setSelectedImage, setSetSelectedImage] = useState(null);
  const [updateData, setUpdateData] = useState([]);
  const navigate = useNavigate();
  const params = useParams();

  useEffect(() => {
    setIsLoading(true);

    Promise.all([
      params.id
        ? fetchWrapper.get("api/category/getcategorybyid/" + params.id)
        : Promise.resolve(),

      fetchWrapper.get("api/subcategory/getsubcategoriesonly"),

      fetchWrapper.get("api/manufacture/getonlymanufactures"),
    ])
      .then((response) => {
        const [updateData, parentData, manufactures] = response;
        setUpdateData(updateData);
        setParentData(parentData);
        setManufactures(manufactures);
        setIsLoading(false);
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  }, [subCategories]);

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
    formData.append("id", params.id ? params.id : "");
    formData.append("subCategoryId", e.target.subCategory.value);
    formData.append("displayOrder", e.target.displayOrder.value);
    formData.append("name", e.target.name.value);
    formData.append("fullName", e.target.fullName.value);
    formData.append("manufactureId", e.target.manufacture.value);
    formData.append("badgeText", e.target.badgeText.value);
    formData.append("badgeStyle", e.target.badgeStyle.value);
    formData.append("defaultLink", e.target.defaultLink.value);

    if (setSelectedImage) {
      formData.append("photo", setSelectedImage[0]);
      formData.append("fileType", "category");
    }

    if (params.id) {
      fetchWrapper
        .put("api/category/updatecategory", formData, false)
        .then((response) => {
          setIsLoading(false);
          navigate("/admin/categories");
        })
        .catch((error) => {
          setIsLoading(false);
          setError(error);
        });
    } else {
      fetchWrapper
        .post("api/category/addcategory", formData, false)
        .then((response) => {
          setIsLoading(false);
          navigate("/admin/categories");
        })
        .catch((error) => {
          setIsLoading(false);
          setError(error);
        });
    }
  };

  function handleSetSelectedImage(image) {
    setSetSelectedImage(image);
  }

  return (
    <div className="page-content">
      {error ? <Error message={error} /> : null}
      <Container fluid>
        <Breadcrumb
          title={params.id ? "Изменить" : "Добавить"}
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
                {params.id ? "Изменить категорию" : "Добавить новую категорию"}
              </div>
            </h3>
          </CardHeader>
          <CardBody>
            {isLoading ? (
              <div
                className={"d-flex justify-content-center align-items-center"}
              >
                <Spinner color={"success"} size={"sm"}>
              Loading...
            </Spinner>
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
                          defaultValue={parentData.filter(
                            (item) => item.label === updateData?.subCategory
                          )}
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
                          defaultValue={updateData?.displayOrder || ""}
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
                          defaultValue={updateData?.name || ""}
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
                          defaultValue={updateData?.fullName || ""}
                        />
                      </Col>
                    </Row>
                  </Col>
                  <Col lg={12} className={"mb-3"}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <Label className={"form-label fw-bold"}>
                          Ссылка по умолчанию{" "}
                          <Popover
                            placement={"right"}
                            text={`
                            Альтернативная ссылка по умолчанию для этой категории в главном
                            меню и в списках категорий. Например, на страницу с продуктами, 
                            содержащую обратную ссылку на категорию.
                        `}
                            id={"defaultLink"}
                          />
                        </Label>
                      </Col>
                      <Col xl={10}>
                        <Input
                          type={"text"}
                          name={"defaultLink"}
                          className={"form-control"}
                          placeholder={"Ссылка по умолчанию (example/child)"}
                          defaultValue={updateData?.defaultLink || ""}
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
                          options={manufactures}
                          defaultValue={
                            manufactures.filter(
                              (item) => item.label === updateData?.manufacture
                            ) || []
                          }
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
                          placeholder={"Текст значка"}
                          defaultValue={updateData?.badgeText || ""}
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
                          defaultValue={
                            BadgesStyle.filter(
                              (item) => item.label === updateData?.badgeStyle
                            ) || []
                          }
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
                          image={updateData?.photo}
                          name={updateData?.name}
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
                        <Spinner size={"sm"}>Loading...</Spinner>
                      ) : null}
                      <i className={"ri-check-double-fill"}></i> Сохранить
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
