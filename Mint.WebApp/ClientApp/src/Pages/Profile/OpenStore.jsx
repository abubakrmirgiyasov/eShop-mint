import React, { useState } from "react";
import {
  Button,
  Col,
  Collapse,
  FormFeedback,
  Input,
  Label,
  Row,
  Spinner,
} from "reactstrap";
import Popover from "../../components/Popover/Popover";
import Select from "react-select";
import { Countries } from "../../constants/Common";
import { CKEditor } from "@ckeditor/ckeditor5-react";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import PreviewSingleImage from "../../Admin/components/Dropzone/PreviewSingleImage";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { Error } from "../../components/Notification/Error";
import * as Yup from "yup";
import { useFormik } from "formik";

const OpenStore = ({ userId }) => {
  const [isFormOpened, setIsFormOpened] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setEror] = useState(null);
  const [selectedImage, setSelectedImage] = useState(null);

  const toggleForm = () => {
    setIsFormOpened(!isFormOpened);
  };

  function setImage(image) {
    setSelectedImage(image);
  }

  const validation = useFormik({
    initialValues: {
      name: "",
      url: null,
      country: null,
      city: null,
      street: null,
      zipCode: 0,
      logo: null,
      addressDescription: null,
      isOwnStore: false,
    },
    validationSchema: Yup.object({
      name: Yup.string().required("Заполните обязательное поле"),
      url: Yup.string().required("Заполните обязательное поле"),
      city: Yup.string().required("Заполните обязательное поле"),
      street: Yup.string().required("Заполните обязательное поле"),
      zipCode: Yup.number().required("Заполните обязательное поле"),
      isOwnStore: Yup.bool().required("Выберете вид склада"),
      // country: Yup.object()
      //   .shape({
      //     value: Yup.string().required("Выберете страну"),
      //     label: Yup.string().required("Выберете страну"),
      //   })
    }),
    onSubmit: (values) => {
      setIsLoading(true);

      const formData = new FormData();
      formData.append("name", values.name);
      formData.append("url", values.url);
      formData.append("country", "values.country");
      formData.append("city", values.city);
      formData.append("street", values.street);
      formData.append("zipCode", values.zipCode);
      formData.append("addressDescription", values.addressDescription);
      formData.append("userId", userId);
      formData.append("isOwnStore", values.isOwnStore);

      if (selectedImage) {
        formData.append("fileType", "storeLogos");
        formData.append("photo", selectedImage[0]);
      }

      fetchWrapper
        .post("api/store/createstore", formData, false)
        .then((response) => {
          setIsLoading(false);
        })
        .catch((error) => {
          setIsLoading(false);
          setEror(error);
        });
    },
  });

  return (
    <React.Fragment>
      {error ? <Error message={error} /> : null}
      <form
        className={"form-horizontal"}
        onSubmit={(e) => {
          e.preventDefault();
          validation.handleSubmit(e);
          return false;
        }}
      >
        <span className={"text-muted"}>
          У вас еще нет магазина, хотите открыть?
        </span>
        <div
          className={
            "d-flex justify-content-start align-items-center mt-3 mb-3"
          }
        >
          <Button
            type={"button"}
            color={"primary"}
            className={"btn btn-primary"}
            onClick={toggleForm}
          >
            <i className={"ri-store-2-line"}></i> Октрыть магазин
          </Button>
        </div>
        <Collapse isOpen={isFormOpened}>
          <Row>
            <Col lg={12} className={"mb-3"}>
              <Label className={"form-label"} id={"name"}>
                Название{" "}
                <Popover
                  id={"name"}
                  placement={"right"}
                  text={"Здесь вы вводите название вашего магазина."}
                />
              </Label>
              <Input
                type={"text"}
                id={"name"}
                name={"name"}
                className={"form-control"}
                placeholder={"Введите название магазина"}
                onChange={validation.handleChange}
                onBlur={validation.handleBlur}
                defaultValue={validation.values.name || ""}
                invalid={!!(validation.touched.name && validation.errors.name)}
              />
              {validation.touched.name && validation.errors.name ? (
                <FormFeedback type="invalid">
                  {validation.errors.name}
                </FormFeedback>
              ) : null}
            </Col>
            <Col lg={12} className={"mb-3"}>
              <Label className={"form-label"} id={"url"}>
                Путь магазина{" "}
                <Popover
                  id={"url"}
                  placement={"right"}
                  text={
                    "Здесь вы вводите путь до вашего магазина. Например: mystore/"
                  }
                />
              </Label>
              <Input
                type={"text"}
                id={"url"}
                name={"url"}
                className={"form-control"}
                placeholder={"Введите путь до вашего магазина"}
                onChange={validation.handleChange}
                onBlur={validation.handleBlur}
                defaultValue={validation.values.url || ""}
                invalid={!!(validation.touched.url && validation.errors.url)}
              />
              {validation.touched.url && validation.errors.url ? (
                <FormFeedback type="invalid">
                  {validation.errors.url}
                </FormFeedback>
              ) : null}
            </Col>
            <Col lg={12} className={"mb-3"}>
              <Label className={"form-label"} id={"country"}>
                Страна{" "}
                <Popover
                  id={"country"}
                  placement={"right"}
                  text={"Здесь вы выбыраете страну, где ваш магазин находится."}
                />
              </Label>
              <Select
                name={"country"}
                placeholder={"Выберете страну"}
                options={Countries}
                // onChange={validation.handleChange}
                // onBlur={validation.handleBlur}
                // defaultValue={validation.values.country || ""}
                // invalid={
                //   !!(validation.touched.country && validation.errors.country)
                // }
              />
              {/*{validation.touched.country && validation.errors.country ? (*/}
              {/*  <FormFeedback type="invalid">*/}
              {/*    {validation.errors.country}*/}
              {/*  </FormFeedback>*/}
              {/*) : null}*/}
            </Col>
            <Col lg={12} className={"mb-3"}>
              <Label className={"form-label"} id={"city"}>
                Город{" "}
                <Popover
                  id={"city"}
                  placement={"right"}
                  text={"Здесь вы вводите город вашего магазина."}
                />
              </Label>
              <Input
                type={"text"}
                id={"city"}
                name={"city"}
                className={"form-control"}
                placeholder={"Введите город"}
                onChange={validation.handleChange}
                onBlur={validation.handleBlur}
                defaultValue={validation.values.city || ""}
                invalid={!!(validation.touched.city && validation.errors.city)}
              />
              {validation.touched.city && validation.errors.city ? (
                <FormFeedback type="invalid">
                  {validation.errors.city}
                </FormFeedback>
              ) : null}
            </Col>
            <Col lg={12} className={"mb-3"}>
              <Label className={"form-label"} id={"street"}>
                Улица{" "}
                <Popover
                  id={"street"}
                  placement={"right"}
                  text={"Здесь вы вводите улицу вашего магазина."}
                />
              </Label>
              <Input
                type={"text"}
                id={"street"}
                name={"street"}
                className={"form-control"}
                placeholder={"Введите улицу"}
                onChange={validation.handleChange}
                onBlur={validation.handleBlur}
                defaultValue={validation.values.street || ""}
                invalid={
                  !!(validation.touched.street && validation.errors.street)
                }
              />
              {validation.touched.street && validation.errors.street ? (
                <FormFeedback type="invalid">
                  {validation.errors.street}
                </FormFeedback>
              ) : null}
            </Col>
            <Col lg={12} className={"mb-3"}>
              <Label className={"form-label"} id={"zipCode"}>
                Почтовый индекс{" "}
                <Popover
                  id={"zipCode"}
                  placement={"right"}
                  text={"Здесь вы вводите почтовый индекс."}
                />
              </Label>
              <Input
                type={"text"}
                id={"zipCode"}
                name={"zipCode"}
                className={"form-control"}
                placeholder={"Введите почтовый индекс"}
                onChange={validation.handleChange}
                onBlur={validation.handleBlur}
                defaultValue={validation.values.zipCode || ""}
                invalid={
                  !!(validation.touched.zipCode && validation.errors.zipCode)
                }
              />
              {validation.touched.zipCode && validation.errors.zipCode ? (
                <FormFeedback type="invalid">
                  {validation.errors.zipCode}
                </FormFeedback>
              ) : null}
            </Col>
            <Col lg={12} className={"mb-3"}>
              <Label className={"form-label"} id={"isOwnStore"}>
                Свой скалд{" "}
                <Popover
                  id={"isOwnStore"}
                  placement={"right"}
                  text={"PAGES/PROFILE/OPENSTORE.jsx-290"}
                />
              </Label>
              <Input
                type={"checkbox"}
                className={"form-checkbox"}
                name={"isOwnStore"}
                id={"isOwnStore"}
                onChange={validation.handleChange}
                onBlur={validation.handleBlur}
                defaultChecked={validation.values.isOwnStore || false}
                invalid={
                  !!(
                    validation.touched.isOwnStore &&
                    validation.errors.isOwnStore
                  )
                }
              />
              {validation.touched.isOwnStore && validation.errors.isOwnStore ? (
                <FormFeedback type="invalid">
                  {validation.errors.isOwnStore}
                </FormFeedback>
              ) : null}
            </Col>
            <Col lg={12} className={"mb-3"}>
              <Label className={"form-label"} id={"logo"}>
                Логотип{" "}
                <Popover
                  id={"logo"}
                  placement={"right"}
                  text={"Поле для логотипа вашего магазина."}
                />
              </Label>
              <PreviewSingleImage
                setSelectedImage={setImage}
                name={""}
                image={null}
              />
            </Col>
            <Col lg={12} className={"mb-3"}>
              <Label className={"form-label"} id={"addressDescription"}>
                Описание для адреса{" "}
                <Popover
                  id={"addressDescription"}
                  placement={"right"}
                  text={"Здесь вы можете описать локацию вашего магазина."}
                />
              </Label>
              <CKEditor
                editor={ClassicEditor}
                id="text"
                onChange={(event, editor) => {
                  validation.values.addressDescription = editor.getData();
                }}
                data={""}
              />
            </Col>
            <Col
              lg={12}
              className={"d-flex justify-content-end align-items-center"}
            >
              <Button
                type={"submit"}
                color={"success"}
                className={"btn btn-success"}
                disabled={isLoading}
              >
                {isLoading ? (
                  <Spinner size={"sm"} className="me-2">
                    Loading...
                  </Spinner>
                ) : null}
                <i className="ri-check-double-fill"></i> Создать
              </Button>
            </Col>
          </Row>
        </Collapse>
      </form>
    </React.Fragment>
  );
};

export default OpenStore;
