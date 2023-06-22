import React, { useEffect, useState } from "react";
import {
  Button,
  Col,
  FormFeedback,
  Input,
  Label,
  Row,
  Spinner,
  TabPane,
} from "reactstrap";
import Popover from "../../../../components/Popover/Popover";
import * as Yup from "yup";
import { useFormik } from "formik";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { CKEditor } from "@ckeditor/ckeditor5-react";
import { Error } from "../../../../components/Notification/Error";
import { Success } from "../../../../components/Notification/Success";
import { fetchWrapper } from "../../../../helpers/fetchWrapper";
import { useNavigate } from "react-router-dom";
import Select from "react-select";
import { Countries } from "../../../../constants/Common";

const Info = ({ setAddingData, dataForUpdate }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [storeId, setStoreId] = useState(null);
  const [myStoreOptions, setMyStoreOptions] = useState([]);
  const [success, setSuccess] = useState(null);
  const [country, setCountry] = useState(null);

  const navigate = useNavigate();

  const myStore = JSON.parse(localStorage.getItem("my_store"));

  useEffect(() => {
    if (myStore)
      setMyStoreOptions([{ label: myStore.name, value: myStore.id }]);
    else {
      setError("Откройте сначала магазин чтобы добавить товары.");
      navigate("/admin/products");
    }
  }, []);

  const validation = useFormik({
    initialValues: {
      name: "",
      sku: "",
      gtin: 0,
      isPublished: false,
      deliveryMinDay: 1,
      deliveryMaxDay: 1,
      shortDescription: "",
      fullDescription: "",
      adminComment: "",
      storeId: "",
      quantity: 0,
    },
    validationSchema: Yup.object({
      name: Yup.string().required("Заполните обязательное поле"),
      sku: Yup.string().required("Заполните обязательное поле"),
      gtin: Yup.number().notRequired(),
      deliveryMinDay: Yup.number()
        .min(1, "Мин дней для доставки (1)")
        .notRequired(),
      deliveryMaxDay: Yup.number()
        .max(30, "Макс дней для доставки (30)")
        .notRequired(),
    }),
    onSubmit: (values) => {
      setIsLoading(true);

      const data = {
        id: dataForUpdate?.id,
        name: values.name,
        sku: values.sku,
        gtin: values.gtin,
        isPublished: values.isPublished,
        deliveryMinDay: values.deliveryMinDay,
        deliveryMaxDay: values.deliveryMaxDay,
        shortDescription: values.shortDescription,
        fullDescription: values.fullDescription,
        adminComment: values.adminComment,
        storeId: storeId,
        quantity: values.quantity,
        countryOfOrigin: country,
      };

      if (dataForUpdate) {
        fetchWrapper
          .put("api/product/updateproductinfo", data)
          .then((response) => {
            setIsLoading(false);
            setAddingData(true);
            setSuccess(response);
          })
          .catch((error) => {
            setIsLoading(false);
            setError(error);
            setAddingData(false);
          });
      } else {
        fetchWrapper
          .post("api/product/createproduct", data)
          .then((response) => {
            setIsLoading(false);
            setAddingData(true);
            navigate("/admin/products");
          })
          .catch((error) => {
            setIsLoading(false);
            setError(error);
            setAddingData(false);
          });
      }
    },
  });

  const handleStoreChange = (e) => {
    setStoreId(e.value);
  };

  const handleCountryChange = (e) => {
    setCountry(e.label);
  };

  return (
    <TabPane tabId={1}>
      {error ? <Error message={error} /> : null}
      {success ? <Success message={success.message} /> : null}
      <form
        className={"form-horizontal"}
        onSubmit={(e) => {
          e.preventDefault();
          validation.handleSubmit(e);
          return false;
        }}
      >
        <Row>
          <Col
            lg={12}
            className={"d-flex justify-content-between align-items-center mb-3"}
          >
            <Col lg={4}>
              <Label
                className={"form-label fs-16"}
                htmlFor={"name"}
                id={"name"}
              >
                Название
                <Popover
                  id={"name"}
                  placement={"top"}
                  text={"Название вашего продукта."}
                />
              </Label>
            </Col>
            <Col lg={8}>
              <Input
                type={"text"}
                className={"form-control"}
                name={"name"}
                placeholder={"Введите название продукта"}
                onChange={validation.handleChange}
                onBlur={validation.handleBlur}
                defaultValue={
                  validation.values.name || dataForUpdate?.name || ""
                }
                invalid={!!(validation.touched.name && validation.errors.name)}
              />
              {validation.touched.name && validation.errors.name ? (
                <FormFeedback type="invalid">
                  {validation.errors.name}
                </FormFeedback>
              ) : null}
            </Col>
          </Col>
          <Col
            lg={12}
            className={"d-flex justify-content-between align-items-center mb-3"}
          >
            <Col lg={4}>
              <Label className={"form-label fs-16"} htmlFor={"sku"} id={"sku"}>
                Артикул
                <Popover
                  id={"sku"}
                  placement={"top"}
                  text={"Артикул продукта, должен быть уникальным."}
                />
              </Label>
            </Col>
            <Col lg={8}>
              <Input
                type={"text"}
                className={"form-control"}
                name={"sku"}
                placeholder={"Введите артикул"}
                onChange={validation.handleChange}
                onBlur={validation.handleBlur}
                defaultValue={validation.values.sku || dataForUpdate?.sku || ""}
                invalid={!!(validation.touched.sku && validation.errors.sku)}
              />
              {validation.touched.sku && validation.errors.sku ? (
                <FormFeedback type="invalid">
                  {validation.errors.sku}
                </FormFeedback>
              ) : null}
            </Col>
          </Col>
          <Col
            lg={12}
            className={"d-flex justify-content-between align-items-center mb-3"}
          >
            <Col lg={4}>
              <Label
                className={"form-label fs-16"}
                htmlFor={"gtin"}
                id={"gtin"}
              >
                Номер продукта
                <Popover
                  id={"gtin"}
                  placement={"top"}
                  text={
                    "Номер или штрих код продукта, также должно быть уникальным."
                  }
                />
              </Label>
            </Col>
            <Col lg={8}>
              <Input
                type={"number"}
                className={"form-control"}
                name={"gtin"}
                placeholder={"Введите номер продукта"}
                onChange={validation.handleChange}
                onBlur={validation.handleBlur}
                defaultValue={
                  validation.values.gtin || dataForUpdate?.gtin || ""
                }
                invalid={!!(validation.touched.gtin && validation.errors.gtin)}
              />
              {validation.touched.gtin && validation.errors.gtin ? (
                <FormFeedback type="invalid">
                  {validation.errors.gtin}
                </FormFeedback>
              ) : null}
            </Col>
          </Col>
          <Col
            lg={12}
            className={"d-flex justify-content-between align-items-center mb-3"}
          >
            <Col lg={2}>
              <Label
                className={"form-label fs-16"}
                htmlFor={"quantity"}
                id={"quantity"}
              >
                Товаров на складе
                <Popover
                  id={"quantity"}
                  placement={"top"}
                  text={
                    "Укажите сколько товара существует в наличии/на складе."
                  }
                />
              </Label>
            </Col>
            <Col lg={8}>
              <Input
                type={"number"}
                className={"form-control"}
                name={"quantity"}
                placeholder={"Введите количетсво товара"}
                onChange={validation.handleChange}
                onBlur={validation.handleBlur}
                defaultValue={validation.values.quantity || ""}
                invalid={
                  !!(validation.touched.quantity && validation.errors.quantity)
                }
              />
              {validation.touched.quantity && validation.errors.quantity ? (
                <FormFeedback type="invalid">
                  {validation.errors.quantity}
                </FormFeedback>
              ) : null}
            </Col>
          </Col>
          <Col
            lg={12}
            className={"d-flex justify-content-between align-items-center mb-3"}
          >
            <Col lg={2}>
              <Label
                className={"form-label fs-16"}
                htmlFor={"storeId"}
                id={"storeId"}
              >
                Магазин
                <Popover
                  id={"storeId"}
                  placement={"top"}
                  text={
                    "Тут вы должны выбрать, в какой магазин хотите опубликовать."
                  }
                />
              </Label>
            </Col>
            <Col lg={8}>
              <Select
                name={"storeId"}
                // onChange={validation.handleChange}
                // onBlur={validation.handleBlur}
                options={myStoreOptions || []}
                defaultValue={myStoreOptions.filter(
                  (item) => item.name === dataForUpdate?.store
                )}
                onChange={handleStoreChange}
              />
            </Col>
          </Col>
          <Col
            lg={12}
            className={"d-flex justify-content-between align-items-center mb-3"}
          >
            <Col lg={2}>
              <Label
                className={"form-label fs-16"}
                htmlFor={"storeId"}
                id={"storeId"}
              >
                Страна производства
                <Popover
                  id={"storeId"}
                  placement={"top"}
                  text={
                    "Тут вы должны выбрать, в какой стране был произведен товар."
                  }
                />
              </Label>
            </Col>
            <Col lg={8}>
              <Select
                name={"storeId"}
                // onChange={validation.handleChange}
                // onBlur={validation.handleBlur}
                options={Countries || []}
                defaultValue={Countries.filter(
                  (item) => item.label === dataForUpdate?.countryOfOrigin
                )}
                onChange={handleCountryChange}
              />
            </Col>
          </Col>
          <Col
            lg={12}
            className={"d-flex justify-content-between align-items-center mb-3"}
          >
            <Col lg={2}>
              <Label
                className={"form-label fs-16"}
                htmlFor={"isPublished"}
                id={"isPublished"}
              >
                Опубликовать
                <Popover
                  id={"isPublished"}
                  placement={"top"}
                  text={"Перключив в публикуйете продукт."}
                />
              </Label>
            </Col>
            <Col lg={8}>
              <div
                className={
                  "form-check form-switch-warning form-switch form-switch-md"
                }
              >
                <Input
                  type={"checkbox"}
                  className={"form-check-input form-check-input"}
                  role={"switch"}
                  id={"SwitchCheck4"}
                  name={"isPublished"}
                  onChange={validation.handleChange}
                  onBlur={validation.handleBlur}
                  defaultChecked={
                    validation.values.isPublished ||
                    dataForUpdate?.isPublished ||
                    false
                  }
                />
              </div>
            </Col>
          </Col>
          <Col
            lg={12}
            className={"d-flex justify-content-between align-items-center mb-3"}
          >
            <Col lg={4}>
              <Label className={"fs-16"} htmlFor={"minMax"} id={"minMax"}>
                Доставка в днях
                <Popover
                  id={"minMax"}
                  placement={"top"}
                  text={
                    "Здесь в указываете за сколько дней доставите продукт. Например: (1-7) дней."
                  }
                />
              </Label>
            </Col>
            <Col lg={4} className={"me-2"}>
              <Input
                type={"number"}
                name={"deliveryMinDay"}
                placeholder={"Мин."}
                onChange={validation.handleChange}
                onBlur={validation.handleBlur}
                defaultValue={
                  // validation.values.deliveryMinDay ||
                  dataForUpdate?.deliveryMinDay || ""
                }
                invalid={
                  !!(
                    validation.touched.deliveryMinDay &&
                    validation.errors.deliveryMinDay
                  )
                }
              />
              {validation.touched.deliveryMinDay &&
              validation.errors.deliveryMinDay ? (
                <FormFeedback type="invalid">
                  {validation.errors.deliveryMinDay}
                </FormFeedback>
              ) : null}{" "}
            </Col>
            <Col lg={4}>
              <Input
                type={"number"}
                name={"deliveryMaxDay"}
                placeholder={"Макс."}
                onChange={validation.handleChange}
                onBlur={validation.handleBlur}
                defaultValue={
                  // validation.values.deliveryMaxDay ||
                  dataForUpdate?.deliveryMaxDay || ""
                }
                invalid={
                  !!(
                    validation.touched.deliveryMaxDay &&
                    validation.errors.deliveryMaxDay
                  )
                }
              />
              {validation.touched.deliveryMaxDay &&
              validation.errors.deliveryMaxDay ? (
                <FormFeedback type="invalid">
                  {validation.errors.deliveryMaxDay}
                </FormFeedback>
              ) : null}{" "}
            </Col>
          </Col>
          <Col
            lg={12}
            className={"d-flex justify-content-between align-items-center mb-3"}
          >
            <Col lg={4}>
              <Label
                className={"fs-16"}
                htmlFor={"adminComment"}
                id={"adminComment"}
              >
                Коментарии адимна
                <Popover
                  id={"shortDescription"}
                  placement={"top"}
                  text={"12312312312312312312."}
                />
              </Label>
            </Col>
            <Col lg={8}>
              <textarea
                className={"form-control"}
                name={"adminComment"}
                placeholder={"Коментарии адимна"}
                onChange={validation.handleChange}
                onBlur={validation.handleBlur}
                defaultValue={
                  validation.values.adminComment ||
                  dataForUpdate?.adminComment ||
                  ""
                }
              ></textarea>
            </Col>
          </Col>
          <Col
            lg={12}
            className={"d-flex justify-content-between align-items-center mb-3"}
          >
            <Col lg={4}>
              <Label
                className={"fs-16"}
                htmlFor={"shortDescription"}
                id={"shortDescription"}
              >
                Краткое описание
                <Popover
                  id={"shortDescription"}
                  placement={"top"}
                  text={"Краткое описание продукта."}
                />
              </Label>
            </Col>
            <Col lg={8}>
              <textarea
                className={"form-control"}
                name={"shortDescription"}
                placeholder={"Краткое описание продукта"}
                onChange={validation.handleChange}
                onBlur={validation.handleBlur}
                defaultValue={
                  validation.values.shortDescription ||
                  dataForUpdate?.shortDescription ||
                  ""
                }
              ></textarea>
            </Col>
          </Col>
          <Col
            lg={12}
            className={"d-flex justify-content-between align-items-center mb-3"}
          >
            <Col lg={4}>
              <Label className={"fs-16"} htmlFor={"name"} id={"name"}>
                Полное описание
                <Popover
                  id={"name"}
                  placement={"top"}
                  text={"Полное описание продукта."}
                />
              </Label>
            </Col>
            <Col lg={8}>
              <CKEditor
                editor={ClassicEditor}
                id="text"
                onChange={(event, editor) => {
                  validation.values.fullDescription = editor.getData();
                }}
                className={"snow-editor"}
                data={dataForUpdate?.fullDescription || ""}
              />
            </Col>
          </Col>
          <Col
            lg={12}
            className={"d-flex justify-content-end align-items-center"}
          >
            <Button
              type={"submit"}
              className={"btn btn-primary"}
              color={"primary"}
              disabled={isLoading}
            >
              {isLoading ? (
                <Spinner className={"me-2"} size={"sm"}>
                  Loading...
                </Spinner>
              ) : null}
              <i className={"ri-check-double-line"}></i> Сохранить
            </Button>
          </Col>
        </Row>
      </form>
    </TabPane>
  );
};

export default Info;
