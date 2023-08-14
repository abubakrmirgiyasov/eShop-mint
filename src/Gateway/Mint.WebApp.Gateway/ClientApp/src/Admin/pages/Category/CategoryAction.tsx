import React, { FC, ReactNode, useState } from "react";
import { Error } from "../../../components/Notifications/Error";
import {
  Card,
  CardBody,
  CardHeader,
  Col,
  Container,
  FormFeedback,
  Row,
  Spinner,
} from "reactstrap";
import BreadCrumb from "../../../components/Common/BreadCrumb";
import { Link, useParams } from "react-router-dom";
import ReactSelect, { StylesConfig } from "react-select";
import Popover from "../../../components/Common/Popover";
import { BadgeStyles, IBadgeStyle, Icons } from "../../../constants/commonList";
import chroma from "chroma-js";
import SingleImage from "../../../components/Dropzone/SingleImage";
import * as Yup from "yup";
import { useForm, Controller } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { ICategoryFull } from "../../../services/admin/ICategory";
import CustomErrorStyle from "../../../components/Common/CustomErrorStyle";
import { fetch } from "../../../helpers/fetch";

const CategoryAction: FC<ReactNode> = () => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");
  const [photo, setPhoto] = useState<File[]>([]);

  const params = useParams();

  const handlePhotoChange = (img: File[]) => setPhoto(img);

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

  const badgeText = [
    { label: "test0", value: "test0" },
    { label: "test1", value: "test1" },
    { label: "test2", value: "test2" },
  ];

  const validation = Yup.object().shape({
    displayOrder: Yup.number()
      .min(1, "Число должно быть в диапазоне от 1 до 99.")
      .max(99, "Число должно быть в диапазоне от 1 до 99"),
    name: Yup.string()
      .required("Заполните обязательное поле")
      .min(3, "Минимальная длина строки 3 символа")
      .max(100, "Максимальная длина строки 100 символов"),
    defaultLink: Yup.string()
      .required("Заполните обязательное поле")
      .min(3, "Минимальная длина строки 3 символа")
      .max(60, "Максимальная длина строки 60 символов"),
    categoryTags: Yup.object().required("Выберите аттрибуты"),
    childs: Yup.object(),
    ico: Yup.object().required("Выберите иконку"),
    manufactureCategories: Yup.object().required("Выберите производителя"),
    badgeText: Yup.object(),
    badgeStyle: Yup.object(),
  });

  const {
    register,
    handleSubmit,
    reset,
    control,
    formState: { errors },
  } = useForm<ICategoryFull>({
    resolver: yupResolver(validation),
  });

  const onSubmit = (values: ICategoryFull) => {
    // setIsLoading(true);

    const data: ICategoryFull = {
      badgeStyle: values.badgeStyle,
      badgeText: values.badgeText,
      categoryTags: values.categoryTags,
      childs: values.childs,
      defaultLink: values.defaultLink,
      displayOrder: values.displayOrder,
      folder: "category",
      ico: values.ico,
      id: values.id,
      manufactureCategories: values.manufactureCategories,
      name: values.name,
      photo: photo,
    };

    console.log(data);

    // fetch()
    //   .post("/category/newcategory", data)
    //   .then((response) => {
    //     setIsLoading(false);
    //   })
    //   .catch((error) => {
    //     setIsLoading(false);
    //     setError(error);
    //   });
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
              <form onSubmit={handleSubmit(onSubmit)}>
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
                          className={`form-control ${
                            errors.displayOrder ? "is-invalid" : ""
                          }`}
                          placeholder={"Отобразить по порядку"}
                          defaultValue={""}
                          {...register("displayOrder")}
                        />
                        <FormFeedback type={"invalid"}>
                          {errors.displayOrder?.message}
                        </FormFeedback>
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
                          className={`form-control ${
                            errors.name ? "is-invalid" : ""
                          }`}
                          placeholder={"Введите название"}
                          {...register("name")}
                        />
                        <FormFeedback type={"invalid"}>
                          {errors.name?.message}
                        </FormFeedback>
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
                          className={`form-control ${
                            errors.defaultLink ? "is-invalid" : ""
                          }`}
                          placeholder={"Ссылка по умолчанию (example/child)"}
                          defaultValue={""}
                          {...register("defaultLink")}
                        />
                        <FormFeedback type={"invalid"}>
                          {errors.defaultLink?.message}
                        </FormFeedback>
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
                        <Controller
                          render={({ ...field }) => (
                            <ReactSelect
                              {...field}
                              isMulti
                              options={[]}
                              isSearchable={true}
                              placeholder={"Выберете дочерние категории"}
                              className={"basic-select"}
                            />
                          )}
                          name={"childs"}
                          control={control}
                        />
                        <CustomErrorStyle message={errors.childs?.message} />
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
                        <Controller
                          render={({ ...field }) => (
                            <ReactSelect
                              {...field}
                              isMulti
                              options={[]}
                              isSearchable={true}
                              placeholder={"Выберете производителя"}
                              className={"basic-select"}
                            />
                          )}
                          name={"manufactureCategories"}
                          control={control}
                        />
                        <CustomErrorStyle
                          message={errors.manufactureCategories?.message}
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
                        <Controller
                          render={({ ...field }) => (
                            <ReactSelect
                              {...field}
                              isMulti
                              options={[]}
                              isSearchable={true}
                              placeholder={"Выберите тегы для категории"}
                            />
                          )}
                          name={"categoryTags"}
                          control={control}
                        />
                        <CustomErrorStyle
                          message={errors.categoryTags?.message}
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
                      <Col xl={10}>
                        <Controller
                          render={({ ...field }) => (
                            <ReactSelect
                              {...field}
                              isSearchable={true}
                              className={"basic-select"}
                              options={Icons}
                              placeholder={"Выберите иконку"}
                              formatOptionLabel={(option) => (
                                <div>
                                  <i className={option.svg}></i>{" "}
                                  <span>{option.label}</span>
                                </div>
                              )}
                            />
                          )}
                          name={"ico"}
                          control={control}
                        />
                        <CustomErrorStyle message={errors.ico?.message} />
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
                        <Controller
                          render={({ ...field }) => (
                            <ReactSelect
                              {...field}
                              isSearchable={true}
                              className={"basic-select"}
                              options={badgeText}
                              placeholder={"Поле для название значка"}
                            />
                          )}
                          name={"badgeText"}
                          control={control}
                        />
                        <CustomErrorStyle message={errors.badgeText?.message} />
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
                        <Controller
                          render={({ ...field }) => (
                            <ReactSelect
                              {...field}
                              className={"basic-select"}
                              id={"badgeStyle"}
                              placeholder={"Выберите цвет значка"}
                              options={BadgeStyles}
                              isSearchable={true}
                              styles={colorStyles}
                            />
                          )}
                          name={"badgeStyle"}
                          control={control}
                        />
                        <CustomErrorStyle
                          message={errors.badgeStyle?.message}
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
                          onChange={handlePhotoChange}
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
