import React, { FC, ReactNode, useEffect, useState } from "react";
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
import * as Yup from "yup";
import { useForm, Controller } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { IManufactureFull } from "../../../services/admin/IManufacture";
import CustomErrorStyle from "../../../components/Common/CustomErrorStyle";
import { fetch } from "../../../helpers/fetch";
import { useSelector } from "react-redux";

const ManufactureAction: FC<ReactNode> = () => {
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");
  const [phone, setPhone] = useState<string>("");
  const [photo, setPhoto] = useState<File[]>([]);
  const [manufacturesIsLoading, setManufacturesIsLoading] =
    useState<boolean>(false);

  const params = useParams();

  const { tags } = useSelector((state) => ({
    tags: state.Tags.tags,
  }));

  console.log(tags);

  useEffect(() => {}, []);

  const handlePhotoChange = (img: File[]) => setPhoto(img);
  const handlePhoneChange = (phone: string) => setPhone(phone);

  const validation = Yup.object().shape({
    country: Yup.object().required("Выберите страну"),
    name: Yup.string()
      .required("Заполните обязательное поле")
      .min(3, "Минимальная длина строки 3 символа")
      .max(100, "Максимальная длина строки 100 символов"),
    email: Yup.string()
      .required("Заполните обязательное поле")
      .email("Электронная почта недействительна"),
    phone: Yup.string().required("Заполните обязательное поле"),
    fullAddress: Yup.string().required("Заполните обязательное поле"),
    description: Yup.string(),
    website: Yup.string().required("Заполните обязательное поле"),
    displayOrder: Yup.number()
      .required("Заполните обязательное поле")
      .min(1, "Число должно быть в диапазоне от 1 до 99.")
      .max(99, "Число должно быть в диапазоне от 1 до 99"),
    manufactureCategories: Yup.object(),
    manufactureTags: Yup.object().required("Выберите аттрибуты"),
  });

  const {
    register,
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<IManufactureFull>({
    resolver: yupResolver(validation),
  });

  const onSubmit = (values: IManufactureFull) => {
    setIsLoading(true);

    const formData = new FormData();
    formData.append("name", values.name);
    formData.append("description", values.description);
    formData.append("country", values.country);
    formData.append("email", values.email);
    formData.append("phone", values.phone);
    formData.append("fullAddress", values.fullAddress);
    formData.append("website", values.website);
    formData.append("displayOrder", values.displayOrder);
    formData.append("manufactureTags", JSON.stringify(values.manufactureTags));
    formData.append(
      "manufactureCategories",
      JSON.stringify(values.manufactureCategories)
    );
  };

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
                <form onSubmit={handleSubmit(onSubmit)}>
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
                          type={"number"}
                          className={`form-control ${
                            errors.displayOrder ? "is-invalid" : ""
                          }`}
                          id={"displayNumber"}
                          placeholder={"Введите число"}
                          {...register("displayOrder")}
                        />
                        <FormFeedback type={"invalid"}>
                          {errors.displayOrder?.message}
                        </FormFeedback>
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
                          id={"name"}
                          type={"text"}
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
                        <Controller
                          render={({ ...field }) => (
                            <ReactSelect
                              {...field}
                              id={"country"}
                              placeholder={"Выберите страну"}
                              options={Countries}
                              isSearchable={true}
                            />
                          )}
                          name={"country"}
                          control={control}
                        />
                        <CustomErrorStyle message={errors.country?.message} />
                      </Col>
                    </Row>
                  </Col>
                  <Col className={"mb-3"} lg={12}>
                    <Row className={"align-items-center"}>
                      <Col xl={2}>
                        <label
                          className={"form-label fw-bold mb-0"}
                          id={"categories"}
                        >
                          Категории{" "}
                          <Popover
                            placement={"right"}
                            text={`Выберите категории, связанные с этим производителем.`}
                            id={"categories"}
                          />
                        </label>
                      </Col>
                      <Col xl={10}>
                        <Controller
                          render={({ ...field }) => (
                            <ReactSelect
                              {...field}
                              id={"categories"}
                              placeholder={"Выберите категории"}
                              options={[]}
                              isSearchable={true}
                              isMulti
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
                              options={tags}
                              isSearchable={true}
                              placeholder={"Выберите тегы для производителя"}
                            />
                          )}
                          name={"manufactureTags"}
                          control={control}
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
                          className={`form-control ${
                            errors.email ? "is-invalid" : ""
                          }`}
                          type={"email"}
                          id={"email"}
                          placeholder={"Введите адрес электроной почты"}
                          {...register("email")}
                        />
                        <FormFeedback type={"invalid"}>
                          {errors.email?.message}
                        </FormFeedback>
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
                        <Controller
                          render={({ ...field }) => (
                            <PhoneInput
                              {...field}
                              inputClass={"w-100"}
                              type={"number"}
                              id={"displayNumber"}
                              country={"ru"}
                              // onChange={handlePhoneChange}
                            />
                          )}
                          name={"phone"}
                          control={control}
                        />
                        <CustomErrorStyle message={errors.phone?.message} />
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
                          className={`form-control ${
                            errors.website ? "is-invalid" : ""
                          }`}
                          type={"text"}
                          id={"website"}
                          placeholder={"Введите ссылку на ресурс"}
                          {...register("website")}
                        />
                        <FormFeedback type={"invalid"}>
                          {errors.website?.message}
                        </FormFeedback>
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
                          className={`form-control ${
                            errors.fullAddress ? "is-invalid" : ""
                          }`}
                          type={"text"}
                          id={"fullAddress"}
                          placeholder={"Введите полный адрес"}
                          {...register("fullAddress")}
                        />
                        <FormFeedback type={"invalid"}>
                          {errors.fullAddress?.message}
                        </FormFeedback>
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
                          onChange={handlePhotoChange}
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
